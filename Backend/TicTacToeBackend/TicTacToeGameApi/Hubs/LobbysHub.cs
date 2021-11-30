using System;
using System.Threading.Tasks;
using TicTacToeGameApi.Services;
using Microsoft.AspNetCore.SignalR;
using TicTacToeGameApi.Models;

namespace TicTacToeGameApi.Hubs
{
    public class LobbysHub : Hub
    {
        
        private readonly IGameLobbyService _gameLobbyService;

        public LobbysHub(IGameLobbyService gameLobbyServiceFromDi)
        {
            _gameLobbyService = gameLobbyServiceFromDi;
        }

        public override async Task OnConnectedAsync()
        {
            var roomId = await _gameLobbyService.CreateGameLobby(Context.ConnectionId);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());

            await Clients.Caller.SendAsync(
                "ReceiveMessage",
                "Foo",
                DateTimeOffset.UtcNow,
                "bar");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string name, string text)
        {
            var roomId = await _gameLobbyService.GetGameLobbyForConnectionId(Context.ConnectionId);

            var message = new GameLobbyMessage
            {
                SenderName = name,
                Text = text,
                SentAt = DateTimeOffset.UtcNow
            };

            // Broadcast to all clients
            await Clients.Group(roomId.ToString()).SendAsync(
                "ReceiveMessage",
                message.SenderName,
                message.SentAt,
                message.Text);
        }

        //public async Task SendBroadcastMessage(string user, string message)
        //    => await Clients.All.SendAsync("ReceiveMessage", user, message);

        //public async Task SendPrivateMessageToUser(string user, string message)
        //    => await Clients.User(user).SendAsync("ReceiveMessage", message);

        //public async Task SendMessageToLobby(string lobbyName, string message)
        //    => await Clients.Group(lobbyName).SendAsync("ReceiveMessage", message);


        // Groups Example

        //public async Task AddToGroup(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        //}

        //public async Task RemoveFromGroup(string groupName)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        //}


        //public async Task JoinToRoom

        //public async Task SendMessageToRoom(string roomName, string message)
        //    => await this.Groups

    }
}
