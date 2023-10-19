
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WeLudic.Application.Hubs;

[Authorize]
public sealed class AuthenticationHub : Hub
{
    public async Task SendConnectionAsync(string message)
    {
        await Clients.User(Context.UserIdentifier).SendAsync("Connection", message);
    }
}
