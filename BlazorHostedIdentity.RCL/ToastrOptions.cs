using BlazorHostedIdentity.RCL.Enumerations;
using System.Text.Json.Serialization;

namespace BlazorHostedIdentity.RCL
{
  public class ToastrOptions
  {
    [JsonConverter(typeof(CustomEnumDescriptionConverter<ToastrPostion>))]
    [JsonPropertyName("positionClass")]
    public ToastrPostion Position { get; set; }

    [JsonConverter(typeof(CustomEnumDescriptionConverter<ToastrHideMethod>))]
    [JsonPropertyName("hideMethod")]
    public ToastrHideMethod HideMethod { get; set; }

    [JsonConverter(typeof(CustomEnumDescriptionConverter<ToastrShowMethod>))]
    [JsonPropertyName("showMethod")]
    public ToastrShowMethod ShowMethod { get; set; }

    [JsonPropertyName("closeButton")]
    public bool CloseButton { get; set; }

    [JsonPropertyName("hideDuration")]
    public int HideDuration { get; set; }
  }
}