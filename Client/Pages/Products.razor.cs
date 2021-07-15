using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class Products
  {
    private MudTable<Product> _table;
    private ProductParameters _productParameters = new ProductParameters();
    private readonly int[] _pageSizeOptions = { 4, 6, 10 };
    [Inject] public IProductHttpRepository ProductRepository { get; set; }

    private async Task<TableData<Product>> GetServerData(TableState state)
    {
      _productParameters.PageSize = state.PageSize;
      _productParameters.PageNumber = state.Page + 1;

      var response = await ProductRepository.GetProducts(_productParameters);

      return new TableData<Product> {
        Items = response.Items,
        TotalItems = response.MetaData.TotalCount
      };
    }

    private void OnSearch(string searchTerm)
    {
      _productParameters.SearchTerm = searchTerm;
      _table.ReloadServerData();
    }
  }
}