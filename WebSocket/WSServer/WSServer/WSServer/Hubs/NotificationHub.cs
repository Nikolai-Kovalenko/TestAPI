using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace WSServer.Hubs
{
    public class NotificationHub : Hub
    {
        public ILogger<NotificationHub> Logger { get; }

        public NotificationHub(ILogger<NotificationHub> logger)
        {
           this.Logger = logger;
        }

        public async Task SendMassageToAllUser(string message)
        {
            await Clients.All.SendAsync("ReciveMassage", message);
        }
        
        public async Task SendMessageToCaller(string message)
        {
            await Clients.Caller.SendAsync("ReciveMassage", message);
        }

        public async Task SendMessageToClient(string clientId, string message)
        {
            await Clients.Client(clientId).SendAsync("ReciveMassage", message);
        }

        public async Task SendMessageToGroup(string group, string message)
        {
            await Clients.Group(group).SendAsync("ReciveMassage", message);
        }

        public async Task JoinGroup(string group)
        {
            await Groups.AddToGroupAsync(group, Context.ConnectionId);
        }

        public override async Task OnConnectedAsync()
        {
            Logger.LogInformation($"New user {Context.User.Identity.Name}({Context.ConnectionId}) connected.");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Logger.LogInformation($"The user {Context.User.Identity.Name}({Context.ConnectionId}) disconnected.");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
