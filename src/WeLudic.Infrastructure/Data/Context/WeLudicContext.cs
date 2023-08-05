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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
