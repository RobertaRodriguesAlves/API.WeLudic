using Microsoft.Extensions.Logging;
using Moq;
using WeLudic.Application.Interfaces;
using WeLudic.Application.Services;
using WeLudic.Domain.Interfaces;
using WeLudic.Infrastructure.Security.Interfaces;
using Xunit.Categories;

namespace WeLudic.Tests.Application.Services;

[UnitTest]
public class AuthServiceTests
{
    private Mock<ITokenService> _serviceMock;
    private Mock<IUserRepository> _repositoryMock;
    private Mock<ILogger<AuthService>> _loggerMock;


    #region Private Methods

    private IAuthService CreateService()
    {
        _serviceMock = new Mock<ITokenService>();
        _repositoryMock = new Mock<IUserRepository>();
        _loggerMock = new Mock<ILogger<AuthService>>();
        return new AuthService(_serviceMock.Object, _repositoryMock.Object, _loggerMock.Object);
    }

    #endregion
}
