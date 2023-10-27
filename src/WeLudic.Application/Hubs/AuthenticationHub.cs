using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WeLudic.Application.Hubs;

[AllowAnonymous]
public sealed class AuthenticationHub : Hub
{
    public async Task SendMessageAsync()
    {
        await Clients.All.SendAsync("Connection", "Testando");
    }

    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("Connection", $"{Context.ConnectionId} has joined");
    }
}
