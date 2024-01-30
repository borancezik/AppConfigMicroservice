using Microsoft.AspNetCore.SignalR;

public class SocketServerService : Hub
{
    public async Task Register(string applicationId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, applicationId);
    }
}

