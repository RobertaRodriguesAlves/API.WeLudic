using System;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Services;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Security.Interfaces;
using WeLudic.Shared.AppSettings;
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
    private Mock<IHttpContextAccessor> _httpContextMock;

    private readonly Faker _faker = new("pt_BR");

    [Theory]
    [InlineData("", "", "", "")]
    [InlineData("Reor", "", "reor@gmail.com", "lkshs")]
    [InlineData("", "XtLh93dfUj", "example@gmail.com", "lkshs")]
    [InlineData("Tuara", "XtLh93dfUj", "example@gmail.com", "lkshs")]
    [InlineData("Tuara", "XtLh93dfUj", "Abc.example.com", "lkshs")] // No `@`
    [InlineData("Tuara", "XtLh93dfUj", "A@b@c@example.com", "lkshs")] // multiple `@`
    [InlineData("Tuara", "XtLh93dfUj", "ma...ma@jjf.co", "lkshs")] // continuous multiple dots in name
    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf.c", "lkshs")] // only 1 char in extension
    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf..com", "lkshs")] // continuous multiple dots in domain
    [InlineData("Tuara", "XtLh93dfUj", "ma@@jjf.com", "lkshs")] // continuous multiple `@`
    [InlineData("Tuara", "XtLh93dfUj", "@majjf.com", "lkshs")] // nothing before `@`
    [InlineData("Tuara", "XtLh93dfUj", "ma.@jjf.com", "lkshs")] // nothing after `.`
    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf.com", "lkshs")] // nothing after `_`
    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf", "lkshs")] // no domain extension
    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf.", "lkshs")] // nothing after `_` and .
    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf.", "lkshs")] // nothing after `.`
    public async Task Should_ReturnsValidationError_WhenSignupRequestIsInvalid(string name, string password, string emailAddress, string confirmPassword)
    {
        // Arrange
        using var service = CreateService();
        var signUpRequest = CreateSignUpRequest(name, emailAddress, password, confirmPassword);

        var user = new ClaimsPrincipal(
                  new ClaimsIdentity(
                  new Claim[]
                  {
                       new Claim("ClaimKey", Guid.NewGuid().ToString())
                  }));

        _httpContextMock.Setup(s => s.HttpContext.User).Returns(user);

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
        using var service = CreateService();
        const string errorMessage = "Email já cadastrado.";

        var emailAddress = _faker.Internet.Email();
        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

        var password = _faker.Internet.Password();
        var signUpRequest = CreateSignUpRequest(_faker.Name.FullName(), emailAddress, password, password);

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
        using var service = CreateService();

        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

        var accessKeys = new AccessKeys()
            .SetAccessToken(Guid.NewGuid().ToString(), DateTime.UtcNow, DateTime.UtcNow.AddHours(4))
            .SetRefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow);

        var password = _faker.Internet.Password();
        var signUpRequest = CreateSignUpRequest(_faker.Name.FullName(), _faker.Internet.Email(), password, password);

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
        using var service = CreateService();
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
        using var service = CreateService();
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
        using var service = CreateService();
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
        using var service = CreateService();

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
    [InlineData("00000000-0000-0000-0000-000000000000")]
    [InlineData("6870CB1D-711C-4381-A3CE-FC622C94A6D5")]
    public async Task Should_ReturnsValidationError_WhenRefreshAuthenticationRequestIsInvalid(string refreshToken)
    {
        // Arrange
        using var service = CreateService();
        var refreshTokenRequest = CreateRefreshTokenRequest(refreshToken);

        // Act
        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

        // Assert
        act.Should().BeFailure();
        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task Should_ReturnsUnauthorizedError_WhenUserDoesNotExists()
    {
        // Arrange
        using var service = CreateService();

        const string errorMesssage = "Acesso negado";
        var userId = Guid.NewGuid();
        var refreshTokenRequest = CreateRefreshTokenRequest(Guid.NewGuid().ToString());

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null)
            .Verifiable();

        // Act
        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

        // Assert
        act.Should().BeFailure();
        act.Should().HaveReason(errorMesssage);
    }

    [Fact]
    public async Task Should_ReturnsUnauthorizedError_WhenRefreshTokenInformedIsInvalid()
    {
        // Arrange
        using var service = CreateService();

        const string errorMesssage = "Acesso negado";
        var userId = Guid.NewGuid();
        var refreshTokenRequest = CreateRefreshTokenRequest(Guid.NewGuid().ToString());

        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => f.Internet.Password())
            .RuleFor(u => u.AccessToken, f => BC.BCrypt.HashPassword(f.Random.GetHashCode().ToString()))
            .RuleFor(u => u.RefreshToken, f => BC.BCrypt.HashPassword(f.Random.GetHashCode().ToString()));

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        // Act
        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

        // Assert
        act.Should().BeFailure();
        act.Should().HaveReason(errorMesssage);
    }

    [Fact]
    public async Task Should_ReturnsUnauthorizedError_WhenRefreshTokenIsExpired()
    {
        // Arrange
        using var service = CreateService();

        const string errorMesssage = "Acesso negado";
        var userId = Guid.NewGuid();
        var refreshToken = Guid.NewGuid().ToString();
        var refreshTokenRequest = CreateRefreshTokenRequest(refreshToken);

        var user = new User()
            .SetUser(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password());

        user.SetRefreshToken(BC.BCrypt.HashPassword(refreshToken), DateTime.UtcNow.AddDays(-2));

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        // Act
        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

        // Assert
        act.Should().BeFailure();
        act.Should().HaveReason(errorMesssage);
    }

    [Fact]
    public async Task Should_ReturnsAccessKeysInformation_WhenRefreshTokenRequestIsValid()
    {
        // Arrange
        using var service = CreateService();

        var userId = Guid.NewGuid();
        var refreshToken = Guid.NewGuid().ToString();
        var refreshTokenRequest = CreateRefreshTokenRequest(refreshToken);

        var user = new User()
            .SetUser(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password());

        user.SetRefreshToken(BC.BCrypt.HashPassword(refreshToken), DateTime.UtcNow.AddHours(2));

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        var accessKeys = new AccessKeys()
            .SetAccessToken(Guid.NewGuid().ToString(), DateTime.UtcNow, DateTime.UtcNow.AddHours(4))
            .SetRefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow);

        _serviceMock
            .Setup(s => s.CreateAccessKeys(It.IsAny<Guid>(), It.IsAny<string>()))
            .Returns(accessKeys)
            .Verifiable();

        _repositoryMock
            .Setup(r => r.UpdateAsync(It.Is<User>(p => p == user), It.IsAny<CancellationToken>()))
            .Verifiable();

        // Act
        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

        // Assert
        act.Should().BeSuccess();
        act.Value.Should().NotBeNull();
        act.Value.AccessToken.Should().NotBeNullOrWhiteSpace();
        act.Value.CreatedAt.Should().BeIn(DateTimeKind.Utc);
        act.Value.ExpiresAt.Should().BeIn(DateTimeKind.Utc);
        act.Value.RefreshToken.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Should_ReturnsValidationError_WhenUserIdIsInvalid()
    {
        // Arrange
        using var service = CreateService();
        const string errorMesssage = "Informação inválida";

        // Act
        var act = await service.LogoutAsync();

        // Assert
        act.Should().BeFailure();
        act.Should().HaveReason(errorMesssage);
    }

    [Fact]
    public async Task Should_ReturnsNotFoundError_WhenUserIdDoesNotExists()
    {
        // Arrange
        using var service = CreateService();
        var userId = Guid.NewGuid();
        const string errorMesssage = "Usuário não encontrado";

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null)
            .Verifiable();

        // Act
        var act = await service.LogoutAsync();

        // Assert
        act.Should().BeFailure();
        act.Should().HaveReason(errorMesssage);
    }

    [Fact]
    public async Task Should_ReturnsLogoutSuccess_WhenUserIdIsValid()
    {
        // Arrange
        using var service = CreateService();
        var userId = Guid.NewGuid();

        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        _repositoryMock
            .Setup(r => r.UpdateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .Verifiable();

        // Act
        var act = await service.LogoutAsync();

        // Assert
        act.Should().BeSuccess();
    }

    [Fact]
    public async Task Should_ReturnsGetCurrentUserValidationError_WhenUserIdIsInvalid()
    {
        // Arrange
        using var service = CreateService();
        const string errorMesssage = "Informação inválida";

        // Act
        var act = await service.GetCurrentUserAsync();

        // Assert
        act.Should().BeFailure();
        act.Should().HaveReason(errorMesssage);
    }

    [Fact]
    public async Task Should_ReturnsGetCurrentUserNotFoundError_WhenUserIdDoesNotExists()
    {
        // Arrange
        using var service = CreateService();
        var userId = Guid.NewGuid();
        const string errorMesssage = "Usuário não encontrado";

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync((User)null)
            .Verifiable();

        // Act
        var act = await service.GetCurrentUserAsync();

        // Assert
        act.Should().BeFailure();
        act.Should().HaveReason(errorMesssage);
    }

    [Fact]
    public async Task Should_ReturnsGetCurrentUserSucess_WhenUserIdIsValid()
    {
        // Arrange
        using var service = CreateService();
        var userId = Guid.NewGuid();

        var user = new Faker<User>("pt_BR")
            .RuleFor(u => u.Name, f => f.Name.FullName())
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

        _repositoryMock
            .Setup(r => r.GetByIdAsync(It.Is<Guid>(p => p == userId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(user)
            .Verifiable();

        // Act
        var act = await service.GetCurrentUserAsync();

        // Assert
        act.Should().BeSuccess();
    }


    #region Private Methods

    private IAuthService CreateService()
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: false)
           .Build();

        var settings = Options.Create(configuration
            .GetSection(nameof(SecuritySettings))
            .Get<SecuritySettings>(opt => opt.BindNonPublicProperties = true));

        _serviceMock = new Mock<ITokenService>();
        _repositoryMock = new Mock<IUserRepository>();
        _loggerMock = new Mock<ILogger<AuthService>>();
        _httpContextMock = new Mock<IHttpContextAccessor>();

        return new AuthService(
            _serviceMock.Object,
            _repositoryMock.Object,
            _httpContextMock.Object,
            _loggerMock.Object,
            settings);
    }

    private static SignUpRequest CreateSignUpRequest(string name, string emailAddress, string password, string confirmPassword)
        => new(name, emailAddress, password, confirmPassword, true);

    private static SignInRequest CreateSignInRequest(string email, string password)
        => new(email, password);

    private static RefreshAuthenticationRequest CreateRefreshTokenRequest(string refreshToken)
        => new(refreshToken);

    #endregion
}
