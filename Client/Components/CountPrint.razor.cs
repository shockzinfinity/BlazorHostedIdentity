using Microsoft.AspNetCore.Components;
using System;

namespace BlazorHostedIdentity.Client.Components
{
  public partial class CountPrint
  {
    [Parameter] public string Title { get; set; }
    [Parameter] public int CurrentCount { get; set; }

    protected override void OnInitialized()
    {
      Console.WriteLine($"OnInitialized => Title: {Title}, CurrentCount: {CurrentCount}");
    }

    protected override void OnParametersSet()
    {
      Console.WriteLine($"OnParametersSet => Title: {Title}, CurrentCount: {CurrentCount}");
    }

    protected override void OnAfterRender(bool firstRender)
    {
      if (firstRender) {
        Console.WriteLine($"This is the first render of the component.");
      }
      else {
        Console.WriteLine($"This is NOT the first render of the component.");
      }
    }

    protected override bool ShouldRender()
    {
      //return false;
      return true;
    }
  }
}