using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        private ILogger<ChatHub> _logger;
        public ChatHub(ILogger<ChatHub> logger) {
            _logger = logger;
        }
        public async Task SendMessage(string user, string message)
        {
            _logger.LogDebug($"{user} says {message}");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}