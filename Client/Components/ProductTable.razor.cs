using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorHostedIdentity.Client.Components
{
  public partial class ProductTable
  {
    [Parameter] public List<Product> Products { get; set; }
  }
}