using BlazorHostedIdentity.Client.Features;
using BlazorHostedIdentity.Common;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.HttpRepository
{
  public class ProductHttpRepository : IProductHttpRepository
  {
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public ProductHttpRepository(HttpClient client)
    {
      _client = client ?? throw new ArgumentNullException(nameof(client));
      _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    //public async Task<List<Product>> GetProducts()
    //{
    //  var response = await _client.GetAsync("api/Products");
    //  var content = await response.Content.ReadAsStringAsync();

    //  if (!response.IsSuccessStatusCode) {
    //    throw new ApplicationException(content);
    //  }

    //  var products = JsonSerializer.Deserialize<List<Product>>(content, _options);

    //  return products;
    //}

    public async Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters)
    {
      var queryStringParam = new Dictionary<string, string> {
        { "pageNumber", productParameters.PageNumber.ToString() },
        { "pageSize", productParameters.PageSize.ToString() },
        { "searchTerm", productParameters.SearchTerm ?? "" },
        { "orderBy", productParameters.OrderBy ?? "name" }
      };

      using (var response = await _client.GetAsync(QueryHelpers.AddQueryString("api/Products", queryStringParam))) {
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync();

        var pagingResponse = new PagingResponse<Product> {
          Items = await JsonSerializer.DeserializeAsync<List<Product>>(stream, _options),
          MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
        };

        return pagingResponse;
      }
    }

    public async Task CreateProduct(Product product)
    {
      var content = JsonSerializer.Serialize(product);
      var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

      var response = await _client.PostAsync("api/Products", bodyContent);
      var postResult = await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode) {
        throw new ApplicationException(postResult);
      }
    }

    public async Task<string> UploadProductImage(MultipartFormDataContent content)
    {
      var response = await _client.PostAsync("api/Upload", content);
      var postContent = await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode) {
        throw new ApplicationException(postContent);
      }
      else {
        var imageUrl = Path.Combine("https://localhost:6001/", postContent);

        return imageUrl;
      }
    }

    public async Task<Product> GetProduct(string id)
    {
      var url = Path.Combine("api/Products", id);
      var response = await _client.GetAsync(url);
      var product = await response.ReadContentAs<Product>();

      return product;
    }

    public async Task UpdateProduct(Product product)
    {
      var content = JsonSerializer.Serialize(product);
      var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
      var url = Path.Combine("api/Products", product.Id.ToString());

      var putResult = await _client.PutAsync(url, bodyContent);
      var putContent = await putResult.Content.ReadAsStringAsync();

      if (!putResult.IsSuccessStatusCode)
        throw new ApplicationException(putContent);
    }

    public async Task DeleteProduct(Guid id)
    {
      var url = Path.Combine("api/Products", id.ToString());
      var deleteResult = await _client.DeleteAsync(url);
    }
  }
}