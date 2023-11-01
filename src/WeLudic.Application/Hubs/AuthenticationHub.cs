using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WeLudic.Application.Hubs;

[AllowAnonymous]
public sealed class AuthenticationHub : Hub
{
    public async Task SendNotification(string message)
    {
        await Clients.All.SendAsync("Connection", message);
    }
}
