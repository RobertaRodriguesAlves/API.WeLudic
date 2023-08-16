using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
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
    private Mock<IMapper> _mapperMock;
    private Mock<IHttpContextAccessor> _httpContextMock;
    private Mock<ILogger<GamesService>> _loggerMock;

    [Fact]
    public async Task Should_ReturnsUnauthorizedError_WhenNotFoundUserAuthenticated()
    {
        // Arrange
        using var service = CreateService();
        const string errorMessage = "Acesso negado";

        var user = new ClaimsPrincipal(
                   new ClaimsIdentity(
                   new Claim[]
                   {
                       new Claim("ClaimKey", Guid.NewGuid().ToString())
                   }));

        _httpContextMock.Setup(s => s.HttpContext.User).Returns(user);

        // Act
        var act = await service.GetRouletteOptions();

        // Assert
        act.Should().BeFailure().And.HaveReason(errorMessage);
    }

    #region Private Methods

    private IGamesService CreateService()
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: false)
           .Build();

        var settings = Options.Create(configuration
            .GetSection(nameof(SecuritySettings))
            .Get<SecuritySettings>(opt => opt.BindNonPublicProperties = true));

        _repositoryMock = new Mock<IRouletteOptionsRepository>();
        _mapperMock = new Mock<IMapper>();
        _httpContextMock = new Mock<IHttpContextAccessor>();
        _loggerMock = new Mock<ILogger<GamesService>>();

        return new GamesService(_repositoryMock.Object, _mapperMock.Object, _httpContextMock.Object, _loggerMock.Object, settings);
    }

    #endregion
}
