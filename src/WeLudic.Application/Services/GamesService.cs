using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Games;
using WeLudic.Application.Responses.Games;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Shared.AppSettings;
using WeLudic.Shared.Errors;
using WeLudic.Shared.Extensions;

namespace WeLudic.Application.Services;

public class GamesService : IGamesService
{
    private readonly IRouletteOptionsRepository _optionsRepository;
    private readonly IRouletteSessionRepository _sessionRepository;
    private readonly IRouletteSessionOptionRepository _sessionOptionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GamesService> _logger;

    private readonly SecuritySettings _settings;

    private readonly string _userId;

    public GamesService(
        IRouletteOptionsRepository optionsRepository,
        IRouletteSessionRepository sessionRepository,
        IRouletteSessionOptionRepository sessionOptionRepository,
        IMapper mapper,
        IHttpContextAccessor httpAccessor,
        ILogger<GamesService> logger,
        IOptions<SecuritySettings> options)
    {
        _optionsRepository = optionsRepository;
        _sessionRepository = sessionRepository;
        _sessionOptionRepository = sessionOptionRepository;
        _mapper = mapper;
        _logger = logger;
        _settings = options.Value;

        _userId = httpAccessor.HttpContext.User.Claims.FirstOrDefault(ac => ac.Type == _settings.ClaimKey)?.Value;
    }

    public async Task<Result<IEnumerable<RouletteOptionsResponse>>> GetRouletteOptions()
    {
        _logger.LogInformation("Validando informação recebida");

        if (string.IsNullOrWhiteSpace(_userId))
            return Result.Fail(new UnauthorizedError("Acesso negado"));

        var rouletteOptions = await _optionsRepository.GetOptionsAsync(Guid.Parse(_userId));
        if (!rouletteOptions.Any())
            return Result.Ok(Enumerable.Empty<RouletteOptionsResponse>());

        return Result.Ok(_mapper.Map<IEnumerable<RouletteOptionsResponse>>(rouletteOptions));
    }

    public async Task<Result<Guid>> CreateRouletteSessionAsync(CreateRouletteSessionRequest request)
    {
        _logger.LogInformation("Validando informações recebidas");

        await request.ValidateAsync();
        if (!request.IsValid)
            return request.ToFail();

        if (string.IsNullOrWhiteSpace(_userId))
            return Result.Fail(new UnauthorizedError("Acesso negado"));

        var session = new RouletteSession()
                     .SetRouletteSession(Guid.Parse(_userId));

        var sessionId = await _sessionRepository.CreateSessionAsync(session);
        await _sessionOptionRepository.CreateSessionOptionAsync(sessionId, request.Options);

        return Result.Ok(sessionId);
    }

    public async Task<Result<IEnumerable<RouletteOptionsResponse>>> GetGameOptions(Guid sessionId)
    {
        if (sessionId == Guid.Empty)
            return Result.Fail(new ValidationError("Informação inválida"));

        var sessionOptions = await _sessionOptionRepository.GetOptionsBySessionIdAsync(sessionId);
        var optionsId = ConvertComplexTypeIntoListOfInt(sessionOptions);

        var rouletteOptions = await _optionsRepository.GetOptionByIdAsync(optionsId);
        return Result.Ok(_mapper.Map<IEnumerable<RouletteOptionsResponse>>(rouletteOptions));
    }

    #region Private Methods

    private static List<int> ConvertComplexTypeIntoListOfInt(IEnumerable<RouletteSessionOption> sessionOptions)
    {
        var optionsId = new List<int>();
        foreach (var item in sessionOptions)
        {
            optionsId.Add(item.RouletteOptionId);
        }

        return optionsId;
    }

    #endregion

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
