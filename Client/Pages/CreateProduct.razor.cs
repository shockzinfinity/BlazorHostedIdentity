using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.Client.Shared;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class CreateProduct
  {
    private Product _product = new Product();
    [Inject] public IProductHttpRepository ProductRepository { get; set; }
    private SuccessNotification _notification;

    private void Create()
    {
      ProductRepository.CreateProduct(_product);
      _notification.Show();
    }
  }
}