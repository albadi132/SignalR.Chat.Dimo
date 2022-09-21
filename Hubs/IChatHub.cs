namespace SignalR.Chat.Dimo.Hubs
{
    public interface IChatHub
    {

        Task ReceiveMessage(string user, string message);
    }
}
