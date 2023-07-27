using WeLudic.Domain.ValueObjects;
using WeLudic.Shared.Models;

namespace WeLudic.Infrastructure.Security.Interfaces;

public interface ITokenService
{
    AccessKeys CreateAccessKeys(Guid id, Email email);
}
