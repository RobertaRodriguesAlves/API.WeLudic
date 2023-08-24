using Microsoft.EntityFrameworkCore;
using WeLudic.Infrastructure.Data.Context;

namespace WeLudic.Infrastructure.Data.Repositories.Common;

public abstract class BaseRepository<TEntity> : IDisposable where TEntity : class
{
    private readonly WeLudicContext _dbContext;
    protected readonly DbSet<TEntity> DbSet;

    protected BaseRepository(WeLudicContext context)
    {
        _dbContext = context;
        DbSet = _dbContext.Set<TEntity>();
    }

    protected async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);

    #region IDisposable

    // To detect redundant calls.
    private bool _disposed;

    // Public implementation of Dispose pattern callable by consumers.
    ~BaseRepository()
    {
        Dispose(false);
    }

    // Protected implementation of Dispose pattern.
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    // Protected implementation of Dispose pattern.
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        // Dispose managed state (managed objects).
        if (disposing)
            _dbContext.Dispose();

        _disposed = true;
    }

    #endregion
}