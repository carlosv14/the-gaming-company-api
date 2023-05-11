using Microsoft.EntityFrameworkCore;
using TheGamingCompany.Core.Entities;
using TheGamingCompany.Infrastructure.Database.Configuration;

namespace TheGamingCompany.Infrastructure.Database;
public class TheGamingCompanyContext
    : DbContext
{
    public TheGamingCompanyContext(DbContextOptions<TheGamingCompanyContext> options)
        : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<GamingMode> GamingModes { get; set; }

    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GameEntityConfiguration());
        modelBuilder.ApplyConfiguration(new GamingModeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LoanEntityConfiguration());
    }
}

