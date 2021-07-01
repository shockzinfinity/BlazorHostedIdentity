using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class CallDotNetFromJavaScript
  {
    [Inject] public IJSRuntime JSRuntime { get; set; }
    private MouseCoordinates _coordinates = new MouseCoordinates();

    [JSInvokable]
    public static string CalculateSquareRoot(int number)
    {
      var result = Math.Sqrt(number);

      return $"The square root of {number} is {result}";
    }

    [JSInvokable("CalculateSquareRootWithJustResult")]
    public static string CallculateSquareRoot(int number, bool justResult)
    {
      var result = Math.Sqrt(number);

      return !justResult ?
        $"The square root of {number} is {result}" :
        result.ToString();
    }

    private async Task SendDotNetInstanceToJS()
    {
      var dotNetObjRef = DotNetObjectReference.Create(this);
      await JSRuntime.InvokeVoidAsync("jsFunctions.registerMouseCoordinatesHandler", dotNetObjRef);
    }

    [JSInvokable]
    public void ShowCoordinates(MouseCoordinates coordinates)
    {
      _coordinates = coordinates;
      StateHasChanged();
    }
  }

  public class MouseCoordinates
  {
    public int X { get; set; }
    public int Y { get; set; }
  }
}