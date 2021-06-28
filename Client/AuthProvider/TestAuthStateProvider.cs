using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client.AuthProvider
{
  public class TestAuthStateProvider : AuthenticationStateProvider
  {
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
      var claims = new List<Claim> {
        new Claim(ClaimTypes.Name, "Jun Yu"),
        new Claim(ClaimTypes.Role, "Administrator")
      };

      var anonymous = new ClaimsIdentity();

      return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonymous)));
    }
  }
}