using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Components
{
  public partial class OnlineStatusIndicator
  {
    private string _color;
    [Inject] public IJSRuntime JSRuntime { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      if (firstRender) {
        var dotNetObjRef = DotNetObjectReference.Create(this);
        await JSRuntime.InvokeVoidAsync("jsFunctions.registerOnlineStatusHandler", dotNetObjRef);
      }
    }

    [JSInvokable]
    public void SetOnlineStatusColor(bool isOnline)
    {
      _color = isOnline ? "green" : "red";
      StateHasChanged();
    }
  }
}