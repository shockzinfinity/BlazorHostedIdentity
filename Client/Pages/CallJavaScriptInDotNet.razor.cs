using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class CallJavaScriptInDotNet
  {
    [Inject] public IJSRuntime JSRuntime { get; set; }

    public async Task ShowAlertWindow()
    {
      await JSRuntime.InvokeVoidAsync("showAlert", "JS function called from .NET");
    }
  }
}