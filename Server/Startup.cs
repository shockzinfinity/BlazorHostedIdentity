using BlazorHostedIdentity.Server.Data;
using BlazorHostedIdentity.Server.Models;
using BlazorHostedIdentity.Server.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;

namespace BlazorHostedIdentity.Server
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      services.AddScoped<IProductRepository, ProductRepository>();

      services.AddCors();

      services.AddDatabaseDeveloperPageExceptionFilter();

      services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();

      services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
      {
        options.IdentityResources["openid"].UserClaims.Add("role");
        options.ApiResources.Single().UserClaims.Add("role");
      });

      JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

      services.AddAuthentication()
        .AddIdentityServerJwt()
        .AddGoogle("google", opt =>
        {
          opt.ClientId = Configuration["Authentication:Google:ClientId"];
          opt.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
        })
        .AddFacebook(fo =>
        {
          fo.AppId = Configuration["Authentication:Facebook:AppId"];
          fo.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
        });

      services.AddControllersWithViews();
      services.AddRazorPages();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseMigrationsEndPoint();
        app.UseWebAssemblyDebugging();
      }
      else {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseCors(builder => builder.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithExposedHeaders("X-Pagination"));

      app.UseHttpsRedirection();
      app.UseBlazorFrameworkFiles();
      app.UseStaticFiles();
      app.UseStaticFiles(new StaticFileOptions() {
        FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
        RequestPath = new PathString("/StaticFiles")
      });

      app.UseRouting();

      app.UseIdentityServer();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapRazorPages();
        endpoints.MapControllers();
        endpoints.MapFallbackToFile("index.html");
      });
    }
  }
}