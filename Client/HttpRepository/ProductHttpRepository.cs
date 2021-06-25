﻿using BlazorHostedIdentity.Client.Features;
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
        { "searchTerm", productParameters.SearchTerm == null ? "" : productParameters.SearchTerm },
        { "orderBy", productParameters.OrderBy }
      };
      var response = await _client.GetAsync(QueryHelpers.AddQueryString("api/Products", queryStringParam));

      var pagingResponse = new PagingResponse<Product> {
        Items = await response.ReadContentAs<List<Product>>(),
        MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)
      };

      return pagingResponse;
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
  }
}