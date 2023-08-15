using AutoMapper;
using FluentResults;
using Microsoft.Extensions.Logging;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Responses.Games;
using WeLudic.Domain.Interfaces;
using WeLudic.Shared.Errors;

namespace WeLudic.Application.Services;

public class GamesService : IGamesService
{
    private readonly IRouletteOptionsRepository _optionsRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GamesService> _logger;

    public GamesService(
        IRouletteOptionsRepository optionsRepository,
        IMapper mapper,
        ILogger<GamesService> logger)
    {
        _optionsRepository = optionsRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Result<IEnumerable<RouletteOptionsResponse>>> GetRouletteOptions()
    {
        _logger.LogInformation("Validando informação recebida");

        if (userId == Guid.Empty)
            return Result.Fail(new ValidationError("Informação inválida"));

        var rouletteOptions = await _optionsRepository.GetOptionsAsync(userId);
        if (!rouletteOptions.Any())
            return Result.Ok(Enumerable.Empty<RouletteOptionsResponse>());

        return Result.Ok(_mapper.Map<IEnumerable<RouletteOptionsResponse>>(rouletteOptions));
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
            _optionsRepository.Dispose();

        _disposed = true;
    }

    #endregion
}
