using System;
using System.IO;
using Bogus;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Infrastructure.Security.Services;
using WeLudic.Shared.AppSettings;
using Xunit;
using Xunit.Categories;

namespace WeLudic.Tests.Infrastructure.Security.Services;

[UnitTest]
public class TokenServiceTests
{
    private readonly Faker _faker = new("pt_BR");

    [Fact]
    public void Should_ReturnsAccessKeys_WhenUserIdAndEmailIsInformed()
    {
        // Arrange
        var service = CreateService();
        var userId = Guid.NewGuid();
        var emailAddress = _faker.Internet.Email();

        // Act
        var act = service.CreateAccessKeys(userId, emailAddress);

        // Assert
        act.Should().NotBeNull();
        act.RefreshToken.Should().NotBeNullOrWhiteSpace();
        act.AccessToken.Should().NotBeNullOrWhiteSpace();
    }

    #region Private Methods

    private static ITokenService CreateService()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: false)
            .Build();

        var settings = Options.Create(configuration
            .GetSection(nameof(SecuritySettings))
            .Get<SecuritySettings>(opt => opt.BindNonPublicProperties = true));

        return new TokenService(settings);
    }

    #endregion
}
