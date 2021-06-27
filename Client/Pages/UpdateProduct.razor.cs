using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.Client.Shared;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class UpdateProduct
  {
    private Product _product;
    private SuccessNotification _notification;
    [Inject] private IProductHttpRepository ProductRepository { get; set; }
    [Parameter] public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
      _product = await ProductRepository.GetProduct(Id);
    }

    private async Task Update()
    {
      await ProductRepository.UpdateProduct(_product);
      _notification.Show();
    }

    private void AssignImageUrl(string imageUrl) => _product.ImageUrl = imageUrl;
  }
}