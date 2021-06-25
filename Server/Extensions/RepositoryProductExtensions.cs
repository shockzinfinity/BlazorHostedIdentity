using BlazorHostedIdentity.Shared;
using System.Linq;

namespace BlazorHostedIdentity.Server.Extensions
{
  public static class RepositoryProductExtensions
  {
    public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
    {
      if (string.IsNullOrWhiteSpace(searchTerm))
        return products;

      var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

      return products.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
    }
  }
}