using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BlazorWithRedisBackPlane.Chat
{
    public class ChatHub: Hub
    {
        public const string HubUrl = "/chat";

        public async Task SendMessageToAll(string username, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"{Context.ConnectionId} connected");
            return base.OnConnectedAsync();
        }

        public override  async Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"Disconnected {exception?.Message} {Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }

    }
}
