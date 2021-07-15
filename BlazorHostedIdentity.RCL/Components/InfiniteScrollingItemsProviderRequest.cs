using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.RCL.Components
{
  public sealed class InfiniteScrollingItemsProviderRequest
  {
    public int StartIndex { get; }
    public CancellationToken CancellationToken { get; }

    public InfiniteScrollingItemsProviderRequest(int startIndex, CancellationToken cancellationToken)
    {
      StartIndex = startIndex;
      CancellationToken = cancellationToken;
    }
  }

  public delegate Task<IEnumerable<T>> InfiniteScrollingItemsProviderRequestDelegate<T>(InfiniteScrollingItemsProviderRequest context);
}