using BlazorHostedIdentity.Server.Repository;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Server.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
      _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ProductParameters productParameters)
    {
      //var products = await _repository.GetProducts();
      var products = await _repository.GetProducts(productParameters);

      Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(products.MetaData));

      return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
      if (product == null)
        return BadRequest();

      // validation

      await _repository.CreateProduct(product);

      return Created("", product);
    }
  }
}