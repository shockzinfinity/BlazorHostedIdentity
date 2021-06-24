﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorHostedIdentity.Server.Data
{
  public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
  {
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
      builder.HasData(
        new IdentityRole { Name = "Visitor", NormalizedName = "VISITOR" },
        new IdentityRole { Name = "Administorator", NormalizedName = "ADMINISTRATOR" }
        );
    }
  }
}