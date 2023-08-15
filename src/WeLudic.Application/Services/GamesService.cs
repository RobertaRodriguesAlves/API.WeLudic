using FluentResults;
using Microsoft.Extensions.Logging;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Responses.Games;

namespace WeLudic.Application.Services;

public class GamesService : IGamesService
{
    private readonly ILogger<GamesService> _logger;

    public GamesService(ILogger<GamesService> logger)
    {
        _logger = logger;
    }

    public Task<Result<RouletteOptionsResponse>> GetRouletteOptions(Guid userId)
    {
        //if (userId == Guid.Empty)
        //    return Result.Fail(new ValidationError("Informação inválida"));

        throw new NotImplementedException();
    }

    #region IDisposable


    // To detect redundant calls.
    private bool _disposed;

    // Public implementation of Dispose pattern callable by consumers.
    ~GamesService()
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
            //_repository.Dispose();

        _disposed = true;
    }

    #endregion
}
