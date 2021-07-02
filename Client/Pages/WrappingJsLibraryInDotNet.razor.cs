using BlazorHostedIdentity.RCL;
using BlazorHostedIdentity.RCL.Enumerations;
using BlazorHostedIdentity.RCL.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class WrappingJsLibraryInDotNet
  {
    [Inject] public ToastrService ToastrService { get; set; }

    private async Task ShowToastrInfo()
    {
      var message = "This is a message sent from the C# method";
      var options = new ToastrOptions {
        CloseButton = true,
        HideDuration = 300,
        HideMethod = ToastrHideMethod.SlideUp,
        ShowMethod = ToastrShowMethod.SlideDown,
        Position = ToastrPostion.BottomRight
      };

      await ToastrService.ShowInfoMessage(message, options);
    }
  }
}