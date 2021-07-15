using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.Client.Shared;
using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class CreateProduct
  {
    private Product _product = new Product();
    [Inject] public IProductHttpRepository ProductRepository { get; set; }
    private DateTime? _date = DateTime.Today;

    //private SuccessNotification _notification;
    [Inject] public IDialogService Dialog { get; set; }

    [Inject] public NavigationManager NavigationManager { get; set; }

    private async Task Create()
    {
      _product.ManufactureDate = (DateTime)_date;
      await ProductRepository.CreateProduct(_product);
      //_notification.Show();
      await ExecuteDialog();
    }

    private void AssignImageUrl(string imageUrl) => _product.ImageUrl = imageUrl;

    private async Task ExecuteDialog()
    {
      var parameters = new DialogParameters {
        { "Content", "You have successfully created a new product." },
        { "ButtonColor", Color.Primary },
        { "ButtonText", "OK" }
      };

      var dialog = Dialog.Show<DialogNotification>("Success", parameters);

      var result = await dialog.Result;
      if (!result.Cancelled) {
        bool.TryParse(result.Data.ToString(), out bool shouldNavigate);
        if (shouldNavigate) NavigationManager.NavigateTo("/products");
      }
    }
  }
}