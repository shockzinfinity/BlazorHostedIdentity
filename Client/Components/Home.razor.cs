using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorHostedIdentity.Client.Components
{
  public partial class Home
  {
    [Parameter] public string Title { get; set; }
    [Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> AdditionalAttributes { get; set; }
    [CascadingParameter(Name = "HeadingColor")] public string HeadingColor { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
    [Parameter] public RenderFragment ContactMe { get; set; }
  }
}