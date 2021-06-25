using BlazorHostedIdentity.Server.Paging;
using BlazorHostedIdentity.Shared;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Server.Repository
{
  public interface IProductRepository
  {
    Task<PagedList<Product>> GetProducts(ProductParameters productParameters);
    Task CreateProduct(Product product);
  }
}