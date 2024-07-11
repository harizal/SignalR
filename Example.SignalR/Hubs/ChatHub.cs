using Example.SignalR.Utils;
using Microsoft.AspNetCore.SignalR;

namespace Example.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync(Constans.ReceiveMessage, user, message);
        }
    }
}
