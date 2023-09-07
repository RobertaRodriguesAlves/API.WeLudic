using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSubstitute;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Profiles;
using WeLudic.Application.Requests.Games;
using WeLudic.Application.Responses.Games;
using WeLudic.Application.Services;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Shared.AppSettings;
using Xunit;
using Xunit.Categories;

namespace WeLudic.Tests.Application.Services;

[UnitTest]
public class GamesServiceTests
{
    private IRouletteOptionsRepository _optionsRepositoryMock;
    private IRouletteSessionRepository _sessionRepositoryMock;
    private IRouletteSessionOptionRepository _sessionOptionRepositoryMock;
    private IMapper _mapperMock;
    private IHttpContextAccessor _httpContextMock;
    private ILogger<GamesService> _loggerMock;

    [Fact]
    public async Task Should_ReturnsUnauthorizedError_WhenNotFoundUserAuthenticated()
    {
        // Arrange
        using var service = CreateService(success: false);
        const string errorMessage = "Acesso negado";

        // Act
        var act = await service.GetRouletteOptions();

        // Assert
        act.Should().BeFailure().And.HaveReason(errorMessage);
    }

    [Fact]
    public async Task Should_ReturnsEmptyList_WhenNoneOptionsIsFound()
    {
        // Arrange
        using var service = CreateService();

        _optionsRepositoryMock
            .GetOptionsAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(Enumerable.Empty<RouletteOption>());

        // Act
        var act = await service.GetRouletteOptions();

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task Should_ReturnsList_WhenOptionsIsFound()
    {
        // Arrange
        using var service = CreateService();

        var options = new List<RouletteOption>()
        {
            new RouletteOption().SetRouletteOptions(1, "PRIMEIRO JOGO"),
            new RouletteOption().SetRouletteOptions(2, "SEGUNDO JOGO")
        };

        _optionsRepositoryMock
            .GetOptionsAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
            .Returns(options);

        _mapperMock.Map<IEnumerable<RouletteOption>, IEnumerable<RouletteOptionsResponse>>(options);

        // Act
        var act = await service.GetRouletteOptions();

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().NotBeNullOrEmpty();
        act.Value.Should().HaveCount(options.Count);
    }

    [Fact]
    public async Task Should_ReturnsUnauthorizedErrorWhenCreateSession_WhenNotFoundUserAuthenticated()
    {
        // Arrange
        using var service = CreateService(success: false);
        const string errorMessage = "Acesso negado";

        var options = new List<int>() { 1, 5, 6, 7, 8 };
        var request = CreateRouletteSessionRequest(options);

        // Act
        var act = await service.CreateRouletteSessionAsync(request);

        // Assert
        act.Should().BeFailure().And.HaveReason(errorMessage);
    }

    [Fact]
    public async Task Should_ReturnsValidationError_WhenCreateRouletteSessionRequestIsInvalid()
    {
        // Arrange
        using var service = CreateService();

        var options = new List<int>() { 1, 5 };
        var request = CreateRouletteSessionRequest(options);

        // Act
        var act = await service.CreateRouletteSessionAsync(request);

        // Assert
        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task Should_ReturnsSessionId_WhenRouletteSessionIsCreateSuccessfully()
    {
        // Arrange
        using var service = CreateService();

        var options = new List<int>() { 1, 5, 8, 9, 15 };
        var request = CreateRouletteSessionRequest(options);
        var sessionId = Guid.NewGuid();

        _sessionRepositoryMock
            .CreateSessionAsync(Arg.Any<RouletteSession>(), Arg.Any<CancellationToken>())
            .Returns(sessionId);

        _sessionOptionRepositoryMock
            .CreateSessionOptionAsync(
                Arg.Is<Guid>(p => p == sessionId),
                Arg.Any<IEnumerable<int>>(),
                Arg.Any<CancellationToken>())
            .Wait();

        // Act
        var act = await service.CreateRouletteSessionAsync(request);

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Should_ReturnsValidationError_WhenSessionIdIsEmpty()
    {
        // Arrange
        using var service = CreateService();
        var sessionId = Guid.Empty;

        // Act
        var act = await service.GetGameOptions(sessionId);

        // Assert
        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task Should_ReturnsEmptySessionList_WhenSessionIdDoesNotHaveOptions()
    {
        // Arrange
        using var service = CreateService();
        var sessionId = Guid.NewGuid();

        _sessionOptionRepositoryMock
            .GetOptionsBySessionIdAsync(
                Arg.Is<Guid>(p => p == sessionId),
                Arg.Any<CancellationToken>())
            .Returns(Enumerable.Empty<RouletteSessionOption>());

        _optionsRepositoryMock
            .GetOptionByIdAsync(
                Arg.Any<IEnumerable<int>>(),
                Arg.Any<CancellationToken>())
            .Returns(Enumerable.Empty<RouletteOption>());

        _mapperMock.Map<IEnumerable<RouletteOption>, IEnumerable<RouletteOptionsResponse>>(Enumerable.Empty<RouletteOption>());

        // Act
        var act = await service.GetGameOptions(sessionId);

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task Should_ReturnsOptionsList_WhenSessionIdHasOptions()
    {
        // Arrange
        using var service = CreateService();
        var sessionId = Guid.NewGuid();

        var sessionOptions = new List<RouletteSessionOption>()
        {
            new RouletteSessionOption().SetRouletteSessionOption(sessionId, 5),
            new RouletteSessionOption().SetRouletteSessionOption(sessionId, 10),
            new RouletteSessionOption().SetRouletteSessionOption(sessionId, 15),
            new RouletteSessionOption().SetRouletteSessionOption(sessionId, 25)
        };

        var options = new List<RouletteOption>()
        {
            new RouletteOption().SetRouletteOptions(5, "PRIMEIRO JOGO"),
            new RouletteOption().SetRouletteOptions(10, "SEGUNDO JOGO"),
            new RouletteOption().SetRouletteOptions(15, "TERCEIRO JOGO"),
            new RouletteOption().SetRouletteOptions(25, "QUARTO JOGO"),
        };

        _sessionOptionRepositoryMock
            .GetOptionsBySessionIdAsync(
                Arg.Is<Guid>(p => p == sessionId),
                Arg.Any<CancellationToken>())
            .Returns(sessionOptions);

        _optionsRepositoryMock
            .GetOptionByIdAsync(
                Arg.Any<IEnumerable<int>>(),
                Arg.Any<CancellationToken>())
            .Returns(options);

        _mapperMock.Map<IEnumerable<RouletteOption>, IEnumerable<RouletteOptionsResponse>>(options);

        // Act
        var act = await service.GetGameOptions(sessionId);

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().NotBeNullOrEmpty();
        act.Value.Should().HaveCount(options.Count);
    }

    #region Private Methods

    private IGamesService CreateService(bool success = true)
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: false)
           .Build();

        var settings = Options.Create(configuration
            .GetSection(nameof(SecuritySettings))
            .Get<SecuritySettings>(opt => opt.BindNonPublicProperties = true));

        var key = success ? settings.Value.ClaimKey : "ClaimKey";
        var user = new ClaimsPrincipal(
                  new ClaimsIdentity(
                  new Claim[]
                  {
                       new Claim(key, Guid.NewGuid().ToString())
                  }));

        _optionsRepositoryMock = Substitute.For<IRouletteOptionsRepository>();
        _sessionRepositoryMock = Substitute.For<IRouletteSessionRepository>();
        _sessionOptionRepositoryMock = Substitute.For<IRouletteSessionOptionRepository>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile<DomainToResponseProfile>());
        _mapperMock = config.CreateMapper();
        _httpContextMock = Substitute.For<IHttpContextAccessor>();

        _httpContextMock.HttpContext.User.Returns(user);

        _loggerMock = Substitute.For<ILogger<GamesService>>();

        return new GamesService(
            _optionsRepositoryMock,
            _sessionRepositoryMock,
            _sessionOptionRepositoryMock,
            _mapperMock,
            _httpContextMock,
            _loggerMock,
            settings);
    }

    private static CreateRouletteSessionRequest CreateRouletteSessionRequest(IEnumerable<int> options)
        => new(options);

    #endregion
}
