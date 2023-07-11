using WeLudic.Shared.Models;

namespace WeLudic.Infrastructure.Security.Interfaces;

public interface ITokenService
{
    AccessKeys CreateAccessKeys(Guid id, bool isAdmin);
}
