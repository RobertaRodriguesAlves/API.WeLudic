using System;
using System.IO;
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
using Moq;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Services;
using WeLudic.Domain.Interfaces;
using WeLudic.Shared.AppSettings;
using Xunit;
using Xunit.Categories;

namespace WeLudic.Tests.Application.Services;

[UnitTest]
public class GamesServiceTests
{
    private Mock<IRouletteOptionsRepository> _repositoryMock;
    private Mock<IRouletteSessionRepository> _sessionRepositoryMock;
    private Mock<IRouletteSessionOptionRepository> _sessionOptionRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private Mock<IHttpContextAccessor> _httpContextMock;
    private Mock<ILogger<GamesService>> _loggerMock;

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
    public async Task Should_ReturnsEmptyList_WhenNoneOptionsWasFound()
    {
        // Arrange
        using var service = CreateService();
        _repositoryMock.Setup(p => p.GetOptionsAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()));

        // Act
        var act = await service.GetRouletteOptions();

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().BeNullOrEmpty();
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

        _repositoryMock = new Mock<IRouletteOptionsRepository>();
        _sessionRepositoryMock = new Mock<IRouletteSessionRepository>();
        _sessionOptionRepositoryMock = new Mock<IRouletteSessionOptionRepository>();
        _mapperMock = new Mock<IMapper>();
        _httpContextMock = new Mock<IHttpContextAccessor>();

        _httpContextMock.Setup(s => s.HttpContext.User).Returns(user);

        _loggerMock = new Mock<ILogger<GamesService>>();

        return new GamesService(
            _repositoryMock.Object,
            _sessionRepositoryMock.Object,
            _sessionOptionRepositoryMock.Object,
            _mapperMock.Object,
            _httpContextMock.Object,
            _loggerMock.Object,
            settings);
    }

    #endregion
}
