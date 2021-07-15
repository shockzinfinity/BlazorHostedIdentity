using BlazorHostedIdentity.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorHostedIdentity.Client.Components
{
  public partial class QuestionsAnswers
  {
    [Parameter] public ICollection<QA> QAs { get; set; }
  }
}