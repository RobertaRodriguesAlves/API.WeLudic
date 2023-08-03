using System;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Services;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Shared.Models;
using Xunit;
using Xunit.Categories;
using BC = BCrypt.Net;

namespace WeLudic.Tests.Application.Services;

[UnitTest]
public class AuthServiceTests
{
    private Mock<ITokenService> _serviceMock;
    private Mock<IUserRepository> _repositoryMock;
    private Mock<ILogger<AuthService>> _loggerMock;

    private readonly Faker _faker = new("pt_BR");

    [Theory]
    [InlineData(null, null, null)]
    [InlineData("", "", "")]
    [InlineData("Reor", "", "reor@gmail.com")]
    [InlineData("", "XtLh93dfUj", "example@gmail.com")]
    [InlineData("Tuara", "XtLh93dfUj", "example@gmail.com")]
    [InlineData("Tuara", "XtLh93dfUj", "Abc.example.com")] // No `@`
    [InlineData("Tuara", "XtLh93dfUj", "A@b@c@example.com")] // multiple `@`
    [InlineData("Tuara", "XtLh93dfUj", "ma...ma@jjf.co")] // continuous multiple dots in name
    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf.c")] // only 1 char in extension
    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf..com")] // continuous multiple dots in domain
    [InlineData("Tuara", "XtLh93dfUj", "ma@@jjf.com")] // continuous multiple `@`
    [InlineData("Tuara", "XtLh93dfUj", "@majjf.com")] // nothing before `@`
    [InlineData("Tuara", "XtLh93dfUj", "ma.@jjf.com")] // nothing after `.`
    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf.com")] // nothing after `_`
    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf")] // no domain extension
    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf.")] // nothing after `_` and .
    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf.")] // nothing after `.`
    public async Task Should_ReturnsValidationError_WhenSignupRequestIsInvalid(string name, string emailAddress, string password)
    {
        // Arrange
        var service = CreateService();
        var signUpRequest = CreateSignUpRequest(name, emailAddress, password);

        // Act
        var act = await service.SignUpAsync(signUpRequest);

        // Assert
        act.Should().BeFailure();
        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task Should_ReturnsForbiddenError_WhenSignUpExistingEmail()
    {
        // Arrange
        var service = CreateService();
        const string errorMessage = "Email já cadastrado.";

        var emailAddress = _faker.Internet.Email();
        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

        var signUpRequest = CreateSignUpRequest(_faker.Name.FullName(), emailAddress, _faker.Internet.Password());

        _repositoryMock
            .Setup(r => r.GetByEmailAsync(It.Is<string>(p => p == emailAddress), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        // Act
        var act = await service.SignUpAsync(signUpRequest);

        // Assert
        act.Should().BeFailure().And.HaveReason(errorMessage);
    }

    [Fact]
    public async Task Should_ReturnsAccessKeysInformation_WhenSignupRequestIsValid()
    {
        // Arrange
        var service = CreateService();

        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

        var accessKeys = new AccessKeys()
            .SetAccessToken(Guid.NewGuid().ToString(), DateTime.UtcNow, DateTime.UtcNow.AddHours(4))
            .SetRefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow);

        var signUpRequest = CreateSignUpRequest(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password());

        _repositoryMock
            .Setup(r => r.GetByEmailAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null)
            .Verifiable();

        _repositoryMock
            .Setup(r => r.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        _serviceMock
            .Setup(s => s.CreateAccessKeys(It.IsAny<Guid>(), It.IsAny<string>()))
            .Returns(accessKeys)
            .Verifiable();

        _repositoryMock
            .Setup(r => r.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        // Act
        var act = await service.SignUpAsync(signUpRequest);

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().NotBeNull();
        act.Value.User.Email.Should().NotBeNullOrWhiteSpace();
        act.Value.User.Name.Should().NotBeNullOrWhiteSpace();
        act.Value.User.Id.Should().NotBeNull();
        act.Value.AccessKeys.AccessToken.Should().NotBeNullOrWhiteSpace();
        act.Value.AccessKeys.CreatedAt.Should().BeIn(DateTimeKind.Utc);
        act.Value.AccessKeys.ExpiresAt.Should().BeIn(DateTimeKind.Utc);
        act.Value.AccessKeys.RefreshToken.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("", "reor@gmail.com")]
    [InlineData("XtLh93dfUj", "example@gmail.com")]
    [InlineData("XtLh93dfUj", "Abc.example.com")] // No `@`
    [InlineData("XtLh93dfUj", "A@b@c@example.com")] // multiple `@`
    [InlineData("XtLh93dfUj", "ma...ma@jjf.co")] // continuous multiple dots in name
    [InlineData("XtLh93dfUj", "ma@jjf.c")] // only 1 char in extension
    [InlineData("XtLh93dfUj", "ma@jjf..com")] // continuous multiple dots in domain
    [InlineData("XtLh93dfUj", "ma@@jjf.com")] // continuous multiple `@`
    [InlineData("XtLh93dfUj", "@majjf.com")] // nothing before `@`
    [InlineData("XtLh93dfUj", "ma.@jjf.com")] // nothing after `.`
    [InlineData("XtLh93dfUj", "ma_@jjf.com")] // nothing after `_`
    [InlineData("XtLh93dfUj", "ma_@jjf")] // no domain extension
    [InlineData("XtLh93dfUj", "ma_@jjf.")] // nothing after `_` and .
    [InlineData("XtLh93dfUj", "ma@jjf.")] // nothing after `.`
    public async Task Should_ReturnsValidationError_WhenSigninRequestIsInvalid(string emailAddress, string password)
    {
        // Arrange
        var service = CreateService();
        var signInRequest = CreateSignInRequest(emailAddress, password);

        // Act
        var act = await service.SignInAsync(signInRequest);

        // Assert
        act.Should().BeFailure();
        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task Should_ReturnsUnauthorizedError_WhenEmailInformedDoesNotExists()
    {
        // Arrange
        var service = CreateService();
        const string errorMessage = "Acesso negado";

        var emailAddress = _faker.Internet.Email();
        var signInRequest = CreateSignInRequest(emailAddress, _faker.Internet.Password());

        _repositoryMock
            .Setup(r => r.GetByEmailAsync(It.Is<string>(p => p == emailAddress), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null)
            .Verifiable();

        // Act
        var act = await service.SignInAsync(signInRequest);

        // Assert
        act.Should().BeFailure().And.HaveReason(errorMessage);
    }

    [Fact]
    public async Task Should_ReturnsUnauthorizedError_WhenPasswordIsWrong()
    {
        // Arrange
        var service = CreateService();
        const string errorMessage = "Acesso negado";

        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => BC.BCrypt.HashPassword(f.Internet.Password()));

        var emailAddress = _faker.Internet.Email();
        var signInRequest = CreateSignInRequest(emailAddress, _faker.Internet.Password());

        _repositoryMock
            .Setup(r => r.GetByEmailAsync(It.Is<string>(p => p == emailAddress), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        // Act
        var act = await service.SignInAsync(signInRequest);

        // Assert
        act.Should().BeFailure().And.HaveReason(errorMessage);
    }

    [Fact]
    public async Task Should_ReturnsAccessKeysInformation_WhenSigninRequestIsValid()
    {
        // Arrange
        var service = CreateService();

        var emailAddress = _faker.Internet.Email();
        var password = _faker.Internet.Password();
        var user = new User()
            .SetUser(_faker.Name.FullName(), emailAddress, BC.BCrypt.HashPassword(password));

        var accessKeys = new AccessKeys()
            .SetAccessToken(Guid.NewGuid().ToString(), DateTime.UtcNow, DateTime.UtcNow.AddHours(4))
            .SetRefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow);

        var signInRequest = CreateSignInRequest(emailAddress, password);

        _repositoryMock
            .Setup(r => r.GetByEmailAsync(It.Is<string>(p => p == emailAddress), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        _serviceMock
            .Setup(s => s.CreateAccessKeys(It.IsAny<Guid>(), It.Is<string>(p => p == emailAddress)))
            .Returns(accessKeys)
            .Verifiable();

        _repositoryMock
            .Setup(r => r.UpdateAsync(It.Is<User>(p => p == user), It.IsAny<CancellationToken>()))
            .Verifiable();

        // Act
        var act = await service.SignInAsync(signInRequest);

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().NotBeNull();
        act.Value.User.Email.Should().NotBeNullOrWhiteSpace();
        act.Value.User.Name.Should().NotBeNullOrWhiteSpace();
        act.Value.User.Id.Should().NotBeNull();
        act.Value.AccessKeys.AccessToken.Should().NotBeNullOrWhiteSpace();
        act.Value.AccessKeys.CreatedAt.Should().BeIn(DateTimeKind.Utc);
        act.Value.AccessKeys.ExpiresAt.Should().BeIn(DateTimeKind.Utc);
        act.Value.AccessKeys.RefreshToken.Should().NotBeNullOrWhiteSpace();
    }

    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000", "")]
    [InlineData("6870CB1D-711C-4381-A3CE-FC622C94A6D5", "")]
    [InlineData("00000000-0000-0000-0000-000000000000", "6870CB1D-711C-4381-A3CE-FC622C94A6D5")]
    public async Task Should_ReturnsValidationError_WhenRefreshAuthenticationRequestIsInvalid(Guid userId, string refreshToken)
    {
        // Arrange
        var service = CreateService();
        var refreshTokenRequest = CreateRefreshTokenRequest(userId, refreshToken);

        // Act
        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

        // Assert
        act.Should().BeFailure();
        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
    }

    #region Private Methods

    private IAuthService CreateService()
    {
        _serviceMock = new Mock<ITokenService>();
        _repositoryMock = new Mock<IUserRepository>();
        _loggerMock = new Mock<ILogger<AuthService>>();
        return new AuthService(_serviceMock.Object, _repositoryMock.Object, _loggerMock.Object);
    }

    private static SignUpRequest CreateSignUpRequest(string name, string emailAddress, string password)
        => new(name, emailAddress, password);

    private static SignInRequest CreateSignInRequest(string email, string password)
        => new(email, password);

    private static RefreshAuthenticationRequest CreateRefreshTokenRequest(Guid userId, string refreshToken)
        => new(userId, refreshToken);

    #endregion
}
