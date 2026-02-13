using FlightBase.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightBase.Data;

public class FlightBaseContext : DbContext
{
    public FlightBaseContext(DbContextOptions<FlightBaseContext> options) : base(options)
    {
    }

    public DbSet<Flight> Flights => Set<Flight>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasIndex(f => new { f.IcaoAirlineCode, f.FlightNumber });
            entity.HasIndex(f => f.OriginIcao);
            entity.HasIndex(f => f.DestinationIcao);
            entity.HasIndex(f => f.IsCurrentlyOperated);
        });
    }

    public override int SaveChanges()
    {
        SetTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetTimestamps()
    {
        var now = DateTime.UtcNow;

        foreach (var entry in ChangeTracker.Entries<Flight>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = now;
                entry.Entity.UpdatedAt = now;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = now;
            }
        }
    }
}
