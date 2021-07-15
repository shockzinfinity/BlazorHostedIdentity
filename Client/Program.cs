using BlazorHostedIdentity.Client.HttpRepository;
using BlazorHostedIdentity.RCL.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorHostedIdentity.Client
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddHttpClient("BlazorHostedIdentity.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)).AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

      // Supply HttpClient instances that include access tokens when making requests to the server project
      builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorHostedIdentity.ServerAPI"));
      builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();
      builder.Services.AddBlazorToastr();

      builder.Services.AddApiAuthorization().AddAccountClaimsPrincipalFactory<CustomUserFactory>();

      builder.Services.AddMudServices(config =>
      {
        config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
        config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
        config.SnackbarConfiguration.ShowCloseIcon = true;
        config.SnackbarConfiguration.MaxDisplayedSnackbars = 2;
      });

      await builder.Build().RunAsync();
    }
  }
}