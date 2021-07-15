﻿using BlazorHostedIdentity.Server.Models;
using BlazorHostedIdentity.Shared;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BlazorHostedIdentity.Server.Data
{
  public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
  {
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.ApplyConfiguration(new RoleConfiguration());
      builder.ApplyConfiguration(new ProductConfiguration());
      builder.ApplyConfiguration(new QAConfiguration());
      builder.ApplyConfiguration(new DeclarationConfiguration());
      builder.ApplyConfiguration(new ReviewConfiguration());
    }

    public DbSet<Product> Products { get; set; }
  }
}