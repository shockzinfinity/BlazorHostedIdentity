using BlazorHostedIdentity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Server.Repository
{
  public interface IProductRepository
  {
    Task<IEnumerable<Product>> GetProducts();
  }
}
