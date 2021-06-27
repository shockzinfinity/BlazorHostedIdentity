using BlazorHostedIdentity.Server.Paging;
using BlazorHostedIdentity.Shared;
using System;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Server.Repository
{
  public interface IProductRepository
  {
    Task<PagedList<Product>> GetProducts(ProductParameters productParameters);

    Task CreateProduct(Product product);

    Task<Product> GetProduct(Guid guid);

    Task UpdateProduct(Product product, Product dbProduct);

    Task DeleteProduct(Product product);
  }
}