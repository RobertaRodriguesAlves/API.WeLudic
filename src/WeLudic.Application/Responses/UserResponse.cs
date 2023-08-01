namespace WeLudic.Application.Responses;

public sealed class UserResponse
{
    public UserResponse(Guid? id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public Guid? Id { get; }
    public string Name { get; }
    public string Email { get; }
}