using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class Products
  {
    public List<Product> ProductList { get; set; } = new List<Product>();
    [Inject] public IProductHttpRepository ProductRepository { get; set; }

    protected override async Task OnInitializedAsync()
    {
      ProductList = await ProductRepository.GetProducts();

      foreach (var product in ProductList) {
        Console.WriteLine(product.Name);
      }
    }
  }
}