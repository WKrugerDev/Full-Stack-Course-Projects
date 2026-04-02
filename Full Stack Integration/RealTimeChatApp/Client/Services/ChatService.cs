using Microsoft.AspNetCore.SignalR.Client;
using RealTimeChatApp.Shared.Models;

namespace RealTimeChatApp.Client.Services
{
    public class ChatService
    {
        private HubConnection _hubConnection;

        public event Action<ChatMessage>? OnMessageReceived;

        public ChatService()
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5076/chathub", options =>
                {
                    options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets | Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;
                    options.SkipNegotiation = false;
                    
                })
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<ChatMessage>("ReceiveMessage", (message) =>
            {
                OnMessageReceived?.Invoke(message);
            });
        }

        public async Task StartAsync()
        {
            try
            {
                if (_hubConnection.State == HubConnectionState.Disconnected)
                {
                    Console.WriteLine("Connecting to chat hub...");
                    await _hubConnection.StartAsync();
                    Console.WriteLine("Connected to chat hub.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error starting connection: {ex.Message}");
            }
            
        }

        public async Task SendMessage(ChatMessage message) => await _hubConnection.SendAsync("SendMessage", message);
    }
}