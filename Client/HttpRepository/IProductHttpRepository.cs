﻿using BlazorHostedIdentity.Client.Features;
using BlazorHostedIdentity.Shared;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.HttpRepository
{
  public interface IProductHttpRepository
  {
    //Task<List<Product>> GetProducts();
    Task<PagingResponse<Product>> GetProducts(ProductParameters productParameters);
    Task CreateProduct(Product product);
  }
}