using Microsoft.AspNetCore.SignalR;
using RealTimeChatApp.Shared.Models;

namespace RealTimeChatApp.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(ChatMessage chatMessage)
        {
            if (string.IsNullOrWhiteSpace(chatMessage.Message))
                return;
            
            chatMessage.Message = chatMessage.Message.Trim();

            if(chatMessage.Message.Length > 500)
                return;
        
            chatMessage.Timestamp = DateTime.UtcNow;

            //chatMessage.User = Context.User?.Identity?.Name ?? "Anonymous"; - can be commented in if logged in users are expected, otherwise we can just use the user name sent from the client, with a fallback to "Anonymous"
            chatMessage.User = string.IsNullOrWhiteSpace(chatMessage.User)
                ? "Anonymous"
                : chatMessage.User;
            
            await Clients.All.SendAsync("ReceiveMessage", chatMessage);
        }
    }
}