using System.ComponentModel;

namespace BlazorHostedIdentity.RCL.Enumerations
{
  public enum ToastrShowMethod
  {
    [Description("fadeIn")] FadeIn,
    [Description("slideDown")] SlideDown
  }

  public enum ToastrHideMethod
  {
    [Description("fadeOut")] FadeOut,
    [Description("slideUp")] SlideUp
  }

  public enum ToastrPostion
  {
    [Description("toast-top-left")] TopLeft,
    [Description("toast-top-right")] TopRight,
    [Description("toast-bottom-left")] BottomLeft,
    [Description("toast-bottom-right")] BottomRight
  }
}