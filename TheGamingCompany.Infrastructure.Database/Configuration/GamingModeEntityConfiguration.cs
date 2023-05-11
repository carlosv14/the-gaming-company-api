using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Infrastructure.Database.Configuration
{
    public class GamingModeEntityConfiguration : IEntityTypeConfiguration<GamingMode>
    {
        public void Configure(EntityTypeBuilder<GamingMode> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();

            builder.HasData(new GamingMode
            {
                Id = 1,
                Name = "Multi-Player"
            },
            new GamingMode
            {
                Id = 2,
                Name = "Single-Player"
            });
        }
    }
}

