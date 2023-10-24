using Microsoft.AspNetCore.SignalR;

namespace WeLudic.Application.Hubs;

public sealed class AuthenticationHub : Hub
{
    public async Task SendConnectionAsync(string message)
    {
        await Clients.User(Context.UserIdentifier).SendAsync("Connection", message);
    }
}
