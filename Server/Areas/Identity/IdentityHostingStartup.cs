using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(BlazorHostedIdentity.Server.Areas.Identity.IdentityHostingStartup))]

namespace BlazorHostedIdentity.Server.Areas.Identity
{
  public class IdentityHostingStartup : IHostingStartup
  {
    public void Configure(IWebHostBuilder builder)
    {
      builder.ConfigureServices((context, services) => { });
    }
  }
}