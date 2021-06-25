using BlazorHostedIdentity.Server.Data;
using BlazorHostedIdentity.Server.Extensions;
using BlazorHostedIdentity.Server.Paging;
using BlazorHostedIdentity.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Server.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly ApplicationDbContext _context;
    private readonly ILogger<ProductRepository> _logger;

    public ProductRepository(ApplicationDbContext context, ILogger<ProductRepository> logger)
    {
      _context = context ?? throw new ArgumentNullException(nameof(context));
      _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    //public async Task<IEnumerable<Product>> GetProducts() => await _context.Products.ToListAsync();

    public async Task<PagedList<Product>> GetProducts(ProductParameters productParameters)
    {
      var products = await _context.Products
        .Search(productParameters.SearchTerm)
        .Sort(productParameters.OrderBy)
        .ToListAsync();

      return PagedList<Product>.ToPagedList(products, productParameters.PageNumber, productParameters.PageSize);
    }
  }
}