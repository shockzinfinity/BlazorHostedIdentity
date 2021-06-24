using BlazorHostedIdentity.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.HttpRepository
{
  public interface IProductHttpRepository
  {
    Task<List<Product>> GetProducts();
  }
}