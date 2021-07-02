using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.RCL.Services
{
  public class ToastrService
  {
    private IJSRuntime _jsRuntime;

    public ToastrService(IJSRuntime jsRuntime)
    {
      _jsRuntime = jsRuntime ?? throw new ArgumentNullException(nameof(jsRuntime));
    }

    public async Task ShowInfoMessage(string message, object options)
    {
      await _jsRuntime.InvokeVoidAsync("toastrFunctions.showToastrInfo", message, options);
    }
  }
}