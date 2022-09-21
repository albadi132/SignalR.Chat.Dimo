using Microsoft.AspNetCore.SignalR;

namespace SignalR.Chat.Dimo.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public  async Task SendMessage(string user, string message)
        {
            
            await Clients.All.ReceiveMessage( user, message);
        }
    }
}
