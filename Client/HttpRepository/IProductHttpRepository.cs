using BlazorHostedIdentity.Client.Features;
using BlazorHostedIdentity.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.HttpRepository
{
  public interface IProductHttpRepository
  {
    //Task<List<Product>> GetProducts();
    Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);

    Task CreateProduct(Product product);

    Task<string> UploadProductImage(MultipartFormDataContent content);

    Task<Product> GetProduct(string id);

    Task UpdateProduct(Product product);

    Task DeleteProduct(Guid id);
  }
}