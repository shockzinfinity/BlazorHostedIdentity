using BlazorHostedIdentity.Shared;
using System.Collections.Generic;

namespace BlazorHostedIdentity.Client.Features
{
  public class PagingResponse<T> where T : class
  {
    public List<T> Items { get; set; }
    public MetaData MetaData { get; set; }
  }
}