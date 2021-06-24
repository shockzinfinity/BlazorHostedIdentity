using Microsoft.AspNetCore.Components;
using System;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class CustomNotFound
  {
    [Inject] public NavigationManager NavigationManager { get; set; }

    protected override void OnInitialized()
    {
      Console.WriteLine($"Request Uri: {NavigationManager.Uri}");
    }

    public void NavigateHome()
    {
      NavigationManager.NavigateTo("/");
    }
  }
}