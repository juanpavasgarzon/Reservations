using Core.Reservations;
using Core.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; init; }
    public DbSet<Reservation> Reservations { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresDbContext).Assembly);
        modelBuilder.HasDefaultSchema(PostgresSchemas.Default);
    }
}