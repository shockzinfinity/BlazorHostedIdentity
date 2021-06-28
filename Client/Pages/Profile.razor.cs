using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.Pages
{
  public partial class Profile
  {
    [CascadingParameter] private Task<AuthenticationState> _authenticationStateTask { get; set; }
    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    private ClaimsPrincipal _authenticationStateUser { get; set; }
    private ClaimsPrincipal _authenticationStateProviderUser { get; set; }

    protected override async Task OnParametersSetAsync()
    {
      AuthenticationState authenticationState;

      authenticationState = await _authenticationStateTask;
      _authenticationStateUser = authenticationState.User;

      authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
      _authenticationStateProviderUser = authenticationState.User;
    }
  }
}