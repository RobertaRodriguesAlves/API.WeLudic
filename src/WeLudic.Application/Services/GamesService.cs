using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Responses.Games;
using WeLudic.Domain.Interfaces;
using WeLudic.Shared.AppSettings;
using WeLudic.Shared.Errors;

namespace WeLudic.Application.Services;

public class GamesService : IGamesService
{
    private readonly IRouletteOptionsRepository _optionsRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpAccessor;
    private readonly ILogger<GamesService> _logger;

    private readonly SecuritySettings _settings;

    public GamesService(
        IRouletteOptionsRepository optionsRepository,
        IMapper mapper,
        IHttpContextAccessor httpAccessor,
        ILogger<GamesService> logger,
        IOptions<SecuritySettings> options)
    {
        _optionsRepository = optionsRepository;
        _mapper = mapper;
        _httpAccessor = httpAccessor;
        _logger = logger;
        _settings = options.Value;
    }

    public async Task<Result<IEnumerable<RouletteOptionsResponse>>> GetRouletteOptions()
    {
        _logger.LogInformation("Validando informação recebida");

        var userId = _httpAccessor.HttpContext.User.Claims.FirstOrDefault(ac => ac.Type == _settings.ClaimKey)?.Value;

        if (string.IsNullOrWhiteSpace(userId))
            return Result.Fail(new UnauthorizedError("Acesso negado"));

        var rouletteOptions = await _optionsRepository.GetOptionsAsync(Guid.Parse(userId));
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
