using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Infrastructure.Database.Configuration
{
    public class GameEntityConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PublishedOn).IsRequired();
            builder.Property(x => x.Author).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Copies).IsRequired();
            builder.HasOne(x => x.GamingMode)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.GamingModeId);
            builder.HasOne(x => x.Category)
              .WithMany(x => x.Games)
              .HasForeignKey(x => x.CategoryId);
        }
    }
}

