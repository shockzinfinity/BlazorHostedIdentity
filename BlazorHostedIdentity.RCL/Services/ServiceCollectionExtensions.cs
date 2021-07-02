using Microsoft.Extensions.DependencyInjection;

namespace BlazorHostedIdentity.RCL.Services
{
  public static class ServiceCollectionExtensions
  {
    public static IServiceCollection AddBlazorToastr(this IServiceCollection services) => services.AddScoped<ToastrService>();
  }
}