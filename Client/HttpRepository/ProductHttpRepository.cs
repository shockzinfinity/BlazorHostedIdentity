using BlazorHostedIdentity.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

    public async Task<List<Product>> GetProducts()
    {
      var response = await _client.GetAsync("api/Products");
      var content = await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode) {
        throw new ApplicationException(content);
      }

      var products = JsonSerializer.Deserialize<List<Product>>(content, _options);

      return products;
    }
  }
}