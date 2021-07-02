using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorHostedIdentity.RCL.Components
{
  public partial class BusyButton
  {
    [Parameter] public string Icon { get; set; }
    [Parameter] public string Color { get; set; } = "primary";
    [Parameter] public bool IsBusy { get; set; } = false;
    [Parameter] public string Caption { get; set; }
    [Parameter] public string IsBusyCaption { get; set; }
    [Parameter] public EventCallback<MouseEventArgs> OnClickCallback { get; set; }

    private string DisplayCaption {
      get {
        if (IsBusy)
          return IsBusyCaption;
        return Caption;
      }
    }

    private bool PreventDefault {
      get {
        return OnClickCallback.HasDelegate;
      }
    }
  }
}