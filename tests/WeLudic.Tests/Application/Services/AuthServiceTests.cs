//using System;
//using System.IO;
//using System.Security.Claims;
//using System.Threading;
//using System.Threading.Tasks;
//using Bogus;
//using FluentAssertions;
//using FluentResults.Extensions.FluentAssertions;
//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Options;
//using NSubstitute;
//using WeLudic.Application.Interfaces;
//using WeLudic.Application.Requests.Auth;
//using WeLudic.Application.Services;
//using WeLudic.Domain.Entities;
//using WeLudic.Domain.Interfaces;
//using WeLudic.Infrastructure.Security.Interfaces;
//using WeLudic.Shared.AppSettings;
//using WeLudic.Shared.Models;
//using Xunit;
//using Xunit.Categories;

//namespace WeLudic.Tests.Application.Services;

//[UnitTest]
//public class AuthServiceTests
//{
//    private ITokenService _serviceMock;
//    private ICryptService _cryptMock;
//    private IUserRepository _repositoryMock;
//    private IPatientRepository _patientRepositoryMock;
//    private IRouletteSessionRepository _rouletteSessionRepositoryMock;
//    private ILogger<AuthService> _loggerMock;
//    private IHttpContextAccessor _httpContextMock;

//    private readonly Faker _faker = new("pt_BR");

//    [Theory]
//    [InlineData("", "", "", "")]
//    [InlineData("Reor", "", "reor@gmail.com", "lkshs")]
//    [InlineData("", "XtLh93dfUj", "example@gmail.com", "lkshs")]
//    [InlineData("Tuara", "XtLh93dfUj", "example@gmail.com", "lkshs")]
//    [InlineData("Tuara", "XtLh93dfUj", "Abc.example.com", "lkshs")] // No `@`
//    [InlineData("Tuara", "XtLh93dfUj", "A@b@c@example.com", "lkshs")] // multiple `@`
//    [InlineData("Tuara", "XtLh93dfUj", "ma...ma@jjf.co", "lkshs")] // continuous multiple dots in name
//    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf.c", "lkshs")] // only 1 char in extension
//    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf..com", "lkshs")] // continuous multiple dots in domain
//    [InlineData("Tuara", "XtLh93dfUj", "ma@@jjf.com", "lkshs")] // continuous multiple `@`
//    [InlineData("Tuara", "XtLh93dfUj", "@majjf.com", "lkshs")] // nothing before `@`
//    [InlineData("Tuara", "XtLh93dfUj", "ma.@jjf.com", "lkshs")] // nothing after `.`
//    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf.com", "lkshs")] // nothing after `_`
//    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf", "lkshs")] // no domain extension
//    [InlineData("Tuara", "XtLh93dfUj", "ma_@jjf.", "lkshs")] // nothing after `_` and .
//    [InlineData("Tuara", "XtLh93dfUj", "ma@jjf.", "lkshs")] // nothing after `.`
//    public async Task Should_ReturnsValidationError_WhenSignupRequestIsInvalid(string name, string password, string emailAddress, string confirmPassword)
//    {
//        // Arrange
//        using var service = CreateService(success: false);
//        var signUpRequest = CreateSignUpRequest(name, emailAddress, password, confirmPassword);

//        // Act
//        var act = await service.SignUpAsync(signUpRequest);

//        // Assert
//        act.Should().BeFailure();
//        act.Errors.Should().NotBeNullOrEmpty();
//    }

//    [Fact]
//    public async Task Should_ReturnsForbiddenError_WhenSignUpExistingEmail()
//    {
//        // Arrange
//        using var service = CreateService(success: false);
//        const string errorMessage = "Email já cadastrado.";

//        var emailAddress = _faker.Internet.Email();
//        var user = new Faker<User>("pt_BR")
//            .RuleFor(u => u.Name, f => f.Name.FullName())
//            .RuleFor(u => u.Email, f => f.Internet.Email())
//            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

//        var password = _faker.Internet.Password();
//        var signUpRequest = CreateSignUpRequest(_faker.Name.FullName(), emailAddress, password, password);

//        _repositoryMock
//            .GetByEmailAsync(Arg.Is<string>(p => p == emailAddress), Arg.Any<CancellationToken>())
//            .Returns(user);

//        // Act
//        var act = await service.SignUpAsync(signUpRequest);

//        // Assert
//        act.Should().BeFailure().And.HaveReason(errorMessage);
//    }

//    [Fact]
//    public async Task Should_ReturnsAccessKeysInformation_WhenSignupRequestIsValid()
//    {
//        // Arrange
//        using var service = CreateService(success: false);

//        var user = new Faker<User>("pt_BR")
//            .RuleFor(u => u.Name, f => f.Name.FullName())
//            .RuleFor(u => u.Email, f => f.Internet.Email())
//            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

//        var accessKeys = new AccessKeys()
//            .SetAccessToken(Guid.NewGuid().ToString(), DateTime.UtcNow, DateTime.UtcNow.AddHours(4))
//            .SetRefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow);

//        var password = _faker.Internet.Password();
//        var signUpRequest = CreateSignUpRequest(_faker.Name.FullName(), _faker.Internet.Email(), password, password);

//        _repositoryMock
//            .GetByEmailAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
//            .Returns((User)null);

//        _repositoryMock
//            .CreateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>())
//            .Returns(user);

//        _serviceMock
//            .CreateAccessKeys(Arg.Any<Guid>(), Arg.Any<string>())
//            .Returns(accessKeys);

//        await _repositoryMock
//            .UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());

//        // Act
//        var act = await service.SignUpAsync(signUpRequest);

//        // Assert
//        act.Should().BeSuccess();
//        act.Value.Should().NotBeNull();
//        act.Value.User.Email.Should().NotBeNullOrWhiteSpace();
//        act.Value.User.Name.Should().NotBeNullOrWhiteSpace();
//        act.Value.User.Id.Should().NotBeNull();
//        act.Value.AccessKeys.AccessToken.Should().NotBeNullOrWhiteSpace();
//        act.Value.AccessKeys.CreatedAt.Should().BeIn(DateTimeKind.Utc);
//        act.Value.AccessKeys.ExpiresAt.Should().BeIn(DateTimeKind.Utc);
//        act.Value.AccessKeys.RefreshToken.Should().NotBeNullOrWhiteSpace();
//    }

//    [Theory]
//    [InlineData(null, null)]
//    [InlineData("", "")]
//    [InlineData("", "reor@gmail.com")]
//    [InlineData("XtLh93dfUj", "example@gmail.com")]
//    [InlineData("XtLh93dfUj", "Abc.example.com")] // No `@`
//    [InlineData("XtLh93dfUj", "A@b@c@example.com")] // multiple `@`
//    [InlineData("XtLh93dfUj", "ma...ma@jjf.co")] // continuous multiple dots in name
//    [InlineData("XtLh93dfUj", "ma@jjf.c")] // only 1 char in extension
//    [InlineData("XtLh93dfUj", "ma@jjf..com")] // continuous multiple dots in domain
//    [InlineData("XtLh93dfUj", "ma@@jjf.com")] // continuous multiple `@`
//    [InlineData("XtLh93dfUj", "@majjf.com")] // nothing before `@`
//    [InlineData("XtLh93dfUj", "ma.@jjf.com")] // nothing after `.`
//    [InlineData("XtLh93dfUj", "ma_@jjf.com")] // nothing after `_`
//    [InlineData("XtLh93dfUj", "ma_@jjf")] // no domain extension
//    [InlineData("XtLh93dfUj", "ma_@jjf.")] // nothing after `_` and .
//    [InlineData("XtLh93dfUj", "ma@jjf.")] // nothing after `.`
//    public async Task Should_ReturnsValidationError_WhenSigninRequestIsInvalid(string emailAddress, string password)
//    {
//        // Arrange
//        using var service = CreateService(success: false);
//        var signInRequest = CreateSignInRequest(emailAddress, password);

//        // Act
//        var act = await service.SignInAsync(signInRequest);

//        // Assert
//        act.Should().BeFailure();
//        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
//    }

//    [Fact]
//    public async Task Should_ReturnsUnauthorizedError_WhenEmailInformedDoesNotExists()
//    {
//        // Arrange
//        using var service = CreateService(success: false);
//        const string errorMessage = "Acesso negado";

//        var emailAddress = _faker.Internet.Email();
//        var signInRequest = CreateSignInRequest(emailAddress, _faker.Internet.Password());

//        _repositoryMock
//            .GetByEmailAsync(Arg.Is<string>(p => p == emailAddress), Arg.Any<CancellationToken>())
//            .Returns((User)null);

//        // Act
//        var act = await service.SignInAsync(signInRequest);

//        // Assert
//        act.Should().BeFailure().And.HaveReason(errorMessage);
//    }

//    [Fact]
//    public async Task Should_ReturnsUnauthorizedError_WhenPasswordIsWrong()
//    {
//        // Arrange
//        using var service = CreateService(success: false);
//        const string errorMessage = "Acesso negado";

//        var user = new Faker<User>("pt_BR")
//            .RuleFor(u => u.Name, f => f.Name.FullName())
//            .RuleFor(u => u.Email, f => f.Internet.Email())
//            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

//        var emailAddress = _faker.Internet.Email();
//        var signInRequest = CreateSignInRequest(emailAddress, _faker.Internet.Password());

//        _repositoryMock
//            .GetByEmailAsync(Arg.Is<string>(p => p == emailAddress), Arg.Any<CancellationToken>())
//            .Returns(user);

//        // Act
//        var act = await service.SignInAsync(signInRequest);

//        // Assert
//        act.Should().BeFailure().And.HaveReason(errorMessage);
//    }

//    [Fact]
//    public async Task Should_ReturnsAccessKeysInformation_WhenSigninRequestIsValid()
//    {
//        // Arrange
//        using var service = CreateService(success: false);

//        var emailAddress = _faker.Internet.Email();
//        var password = _faker.Internet.Password();
//        var user = new User()
//            .SetUser(_faker.Name.FullName(), emailAddress, password);

//        var accessKeys = new AccessKeys()
//            .SetAccessToken(Guid.NewGuid().ToString(), DateTime.UtcNow, DateTime.UtcNow.AddHours(4))
//            .SetRefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow);

//        var signInRequest = CreateSignInRequest(emailAddress, password);

//        _repositoryMock
//            .GetByEmailAsync(Arg.Is<string>(p => p == emailAddress), Arg.Any<CancellationToken>())
//            .Returns(user);

//        _serviceMock
//            .CreateAccessKeys(Arg.Any<Guid>(), Arg.Is<string>(p => p == emailAddress))
//            .Returns(accessKeys);

//        await _repositoryMock
//            .UpdateAsync(Arg.Is<User>(p => p == user), Arg.Any<CancellationToken>());

//        _cryptMock.Verify(Arg.Any<string>(), Arg.Any<string>())
//            .Returns(true);

//        // Act
//        var act = await service.SignInAsync(signInRequest);

//        // Assert
//        act.Should().BeSuccess();
//        act.Value.Should().NotBeNull();
//        act.Value.User.Email.Should().NotBeNullOrWhiteSpace();
//        act.Value.User.Name.Should().NotBeNullOrWhiteSpace();
//        act.Value.User.Id.Should().NotBeNull();
//        act.Value.AccessKeys.AccessToken.Should().NotBeNullOrWhiteSpace();
//        act.Value.AccessKeys.CreatedAt.Should().BeIn(DateTimeKind.Utc);
//        act.Value.AccessKeys.ExpiresAt.Should().BeIn(DateTimeKind.Utc);
//        act.Value.AccessKeys.RefreshToken.Should().NotBeNullOrWhiteSpace();
//    }

//    [Fact]
//    public async Task Should_ReturnsUnauthorizedError_WhenUserDoesNotExists()
//    {
//        // Arrange
//        using var service = CreateService();

//        const string errorMesssage = "Acesso negado";
//        var refreshTokenRequest = CreateRefreshTokenRequest(Guid.NewGuid().ToString());

//        _repositoryMock
//            .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
//            .Returns((User)null);

//        // Act
//        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

//        // Assert
//        act.Should().BeFailure();
//        act.Should().HaveReason(errorMesssage);
//    }

//    [Fact]
//    public async Task Should_ReturnsUnauthorizedError_WhenRefreshTokenInformedIsInvalid()
//    {
//        // Arrange
//        using var service = CreateService();

//        const string errorMesssage = "Acesso negado";
//        var refreshTokenRequest = CreateRefreshTokenRequest(Guid.NewGuid().ToString());

//        var user = new Faker<User>("pt_BR")
//            .RuleFor(u => u.Name, f => f.Name.FullName())
//            .RuleFor(u => u.Email, f => f.Internet.Email())
//            .RuleFor(u => u.HashedPassword, f => f.Internet.Password())
//            .RuleFor(u => u.AccessToken, f => f.Random.GetHashCode().ToString())
//            .RuleFor(u => u.RefreshToken, f => f.Random.GetHashCode().ToString());

//        _repositoryMock
//            .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
//            .Returns(user);

//        // Act
//        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

//        // Assert
//        act.Should().BeFailure();
//        act.Should().HaveReason(errorMesssage);
//    }

//    [Fact]
//    public async Task Should_ReturnsUnauthorizedError_WhenRefreshTokenIsExpired()
//    {
//        // Arrange
//        using var service = CreateService();

//        const string errorMesssage = "Acesso negado";
//        var refreshToken = Guid.NewGuid().ToString();
//        var refreshTokenRequest = CreateRefreshTokenRequest(refreshToken);

//        var user = new User()
//            .SetUser(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password());

//        user.SetRefreshToken(refreshToken, DateTime.UtcNow.AddDays(-2));

//        _repositoryMock
//            .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
//            .Returns(user);

//        // Act
//        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

//        // Assert
//        act.Should().BeFailure();
//        act.Should().HaveReason(errorMesssage);
//    }

//    [Fact]
//    public async Task Should_ReturnsAccessKeysInformation_WhenRefreshTokenRequestIsValid()
//    {
//        // Arrange
//        using var service = CreateService();

//        var refreshToken = Guid.NewGuid().ToString();
//        var refreshTokenRequest = CreateRefreshTokenRequest(refreshToken);

//        var user = new User()
//            .SetUser(_faker.Name.FullName(), _faker.Internet.Email(), _faker.Internet.Password());

//        user.SetRefreshToken(refreshToken, DateTime.UtcNow.AddHours(2));

//        _repositoryMock
//            .GetByRefreshTokenAsync(Arg.Any<string>(), Arg.Any<CancellationToken>())
//            .Returns(user);

//        var accessKeys = new AccessKeys()
//            .SetAccessToken(Guid.NewGuid().ToString(), DateTime.UtcNow, DateTime.UtcNow.AddHours(4))
//            .SetRefreshToken(Guid.NewGuid().ToString(), DateTime.UtcNow);

//        _serviceMock
//            .CreateAccessKeys(Arg.Any<Guid>(), Arg.Any<string>())
//            .Returns(accessKeys);

//        await _repositoryMock
//            .UpdateAsync(Arg.Is<User>(p => p == user), Arg.Any<CancellationToken>());

//        // Act
//        var act = await service.RefreshAuthenticationAsync(refreshTokenRequest);

//        // Assert
//        act.Should().BeSuccess();
//        act.Value.Should().NotBeNull();
//        act.Value.AccessToken.Should().NotBeNullOrWhiteSpace();
//        act.Value.CreatedAt.Should().BeIn(DateTimeKind.Utc);
//        act.Value.ExpiresAt.Should().BeIn(DateTimeKind.Utc);
//        act.Value.RefreshToken.Should().NotBeNullOrWhiteSpace();
//    }

//    [Fact]
//    public async Task Should_ReturnsNotFoundError_WhenUserIdDoesNotExists()
//    {
//        // Arrange
//        using var service = CreateService(success: false);
//        const string errorMesssage = "Usuário não encontrado";

//        _repositoryMock
//            .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
//            .Returns((User)null);

//        // Act
//        var act = await service.LogoutAsync();

//        // Assert
//        act.Should().BeFailure();
//        act.Should().HaveReason(errorMesssage);
//    }

//    [Fact]
//    public async Task Should_ReturnsLogoutSuccess_WhenUserIdIsValid()
//    {
//        // Arrange
//        using var service = CreateService();

//        var user = new Faker<User>("pt_BR")
//            .RuleFor(u => u.Name, f => f.Name.FullName())
//            .RuleFor(u => u.Email, f => f.Internet.Email())
//            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

//        _repositoryMock
//            .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
//            .Returns(user);

//        await _repositoryMock
//            .UpdateAsync(Arg.Any<User>(), Arg.Any<CancellationToken>());

//        // Act
//        var act = await service.LogoutAsync();

//        // Assert
//        act.Should().BeSuccess();
//    }

//    [Fact]
//    public async Task Should_ReturnsGetCurrentUserNotFoundError_WhenNoneUserIsLogged()
//    {
//        // Arrange
//        using var service = CreateService(success: false);
//        const string errorMesssage = "Usuário não encontrado";

//        _repositoryMock
//            .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
//            .Returns((User)null);

//        // Act
//        var act = await service.GetCurrentUserAsync();

//        // Assert
//        act.Should().BeFailure();
//        act.Should().HaveReason(errorMesssage);
//    }

//    [Fact]
//    public async Task Should_ReturnsGetCurrentUserSucess_WhenUserIdIsValid()
//    {
//        // Arrange
//        using var service = CreateService();

//        var user = new Faker<User>("pt_BR")
//            .RuleFor(u => u.Name, f => f.Name.FullName())
//            .RuleFor(u => u.Email, f => f.Internet.Email())
//            .RuleFor(u => u.HashedPassword, f => f.Internet.Password());

//        _repositoryMock
//            .GetByIdAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>())
//            .Returns(user);

//        // Act
//        var act = await service.GetCurrentUserAsync();

//        // Assert
//        act.Should().BeSuccess();
//    }

//    #region Private Methods

//    private IAuthService CreateService(bool success = true)
//    {
//        var configuration = new ConfigurationBuilder()
//           .SetBasePath(Directory.GetCurrentDirectory())
//           .AddJsonFile("appsettings.Testing.json", optional: false, reloadOnChange: false)
//           .Build();

//        var settings = Options.Create(configuration
//            .GetSection(nameof(SecuritySettings))
//            .Get<SecuritySettings>(opt => opt.BindNonPublicProperties = true));

//        var key = success ? settings.Value.ClaimKey : "ClaimKey";
//        var user = new ClaimsPrincipal(
//                  new ClaimsIdentity(
//                  new Claim[]
//                  {
//                       new Claim(key, Guid.NewGuid().ToString())
//                  }));

//        _serviceMock = Substitute.For<ITokenService>();
//        _cryptMock = Substitute.For<ICryptService>();
//        _repositoryMock = Substitute.For<IUserRepository>();
//        _patientRepositoryMock = Substitute.For<IPatientRepository>();
//        _rouletteSessionRepositoryMock = Substitute.For<IRouletteSessionRepository>();
//        _loggerMock = Substitute.For<ILogger<AuthService>>();
//        _httpContextMock = Substitute.For<IHttpContextAccessor>();

//        _httpContextMock.HttpContext.User.Returns(user);

//        return new AuthService(
//            _serviceMock,
//            _cryptMock,
//            _repositoryMock,
//            _patientRepositoryMock,
//            _rouletteSessionRepositoryMock,
//            _httpContextMock,
//            _loggerMock,
//            settings);
//    }

//    private static SignUpRequest CreateSignUpRequest(string name, string emailAddress, string password, string confirmPassword)
//        => new(name, emailAddress, password, confirmPassword, true);

//    private static SignInRequest CreateSignInRequest(string email, string password)
//        => new(email, password);

//    private static RefreshAuthenticationRequest CreateRefreshTokenRequest(string refreshToken)
//        => new(refreshToken);

//    #endregion
//}
