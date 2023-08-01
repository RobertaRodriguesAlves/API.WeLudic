using System.Threading;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Requests.Auth;
using WeLudic.Application.Services;
using WeLudic.Domain.Entities;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Security.Interfaces;
using Xunit;
using Xunit.Categories;

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
    public async Task Should_ReturnsValidationError_WhenSignupRequestIsInvalid(string name, string emailAddress, string passoword)
    {
        // Arrange
        var service = CreateService();
        var signUpRequest = CreateSignUpRequest(name, emailAddress, passoword);

        // Act
        var act = await service.SignUpAsync(signUpRequest);

        // Assert
        act.Should().NotBeNull();
        act.IsSuccess.Should().BeFalse();
        act.Errors.Should().NotBeNullOrEmpty().And.OnlyHaveUniqueItems();
    }

    [Fact]
    public async Task Should_ReturnsForbiddenError_WhenSignUpExistingEmail()
    {
        // Arrange
        var service = CreateService();

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
        act.Errors.Should().HaveCountGreaterThan(0);
        act.Reasons.Should().HaveCountGreaterThan(0);
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

    #endregion
}
