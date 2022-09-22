using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace SignalR.Chat.Dimo.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public  async Task SendMessage(string user, string message)
        {
            var identity = (ClaimsIdentity)Context.User.Identity;
            var tmp = identity.FindFirst(ClaimTypes.NameIdentifier);
            await Clients.All.ReceiveMessage(tmp.Issuer, message);
        }
    }
}
