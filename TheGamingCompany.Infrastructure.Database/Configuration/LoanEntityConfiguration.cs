using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheGamingCompany.Core.Entities;

namespace TheGamingCompany.Infrastructure.Database.Configuration
{
	public class LoanEntityConfiguration : IEntityTypeConfiguration<Loan>
	{
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsReturnOperation).IsRequired();
            builder.HasOne(x => x.Game)
                .WithMany(x => x.Loans)
                .HasForeignKey(x => x.GameId);
        }
    }
}

