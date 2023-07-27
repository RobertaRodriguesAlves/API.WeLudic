using WeLudic.Domain.ValueObjects;
using WeLudic.Shared.Responses;

namespace WeLudic.Application.Responses;

public sealed class UserResponse : BaseResponse
{
    public UserResponse(Guid id, string name, Email email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid Id { get; }
    public string Name { get; }
    public Email Email { get; }
}