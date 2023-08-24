using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WeLudic.Domain.Entities;

namespace WeLudic.Infrastructure.Data.Context;

public sealed class WeLudicContext : DbContext
{
    public WeLudicContext(DbContextOptions<WeLudicContext> options) : base(options)
    {
        //Desabilita JOIN automático.
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<RouletteOption> RouletteOptions => Set<RouletteOption>();
    public DbSet<RouletteSession> RouletteSessions => Set<RouletteSession>();
    public DbSet<RouletteSessionOption> RouletteSessionOptions => Set<RouletteSessionOption>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
