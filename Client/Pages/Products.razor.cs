using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class Products
  {
    public List<Product> ProductList { get; set; } = new List<Product>();
    public MetaData MetaData { get; set; } = new MetaData();
    private ProductParameters _productParameters = new ProductParameters();
    [Inject] public IProductHttpRepository ProductRepository { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await GetProducts();
    }

    private async Task SelectedPage(int page)
    {
      _productParameters.PageNumber = page;
      await GetProducts();
    }

    private async Task GetProducts()
    {
      var pagingResponse = await ProductRepository.GetProducts(_productParameters);
      ProductList = pagingResponse.Items;
      MetaData = pagingResponse.MetaData;
    }
  }
}