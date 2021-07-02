using Microsoft.AspNetCore.Components;
using System.Threading;

namespace BlazorHostedIdentity.RCL.Components
{
  public partial class Search
  {
    public string SearchTerm { get; set; }
    [Parameter] public EventCallback<string> OnSearchChanged { get; set; }
    private Timer _timer;

    private void SearchChanged()
    {
      if (_timer != null)
        _timer.Dispose();

      _timer = new Timer(OnTimeElapsed, null, 500, 0);
    }

    private void OnTimeElapsed(object sender)
    {
      OnSearchChanged.InvokeAsync(SearchTerm);
      _timer.Dispose();
    }
  }
}