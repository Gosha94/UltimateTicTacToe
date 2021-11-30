using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TicTacToeGameApi.Hubs
{
    public class LobbysHub : Hub
    {
        // Dummies
        
        public async Task SendBroadcastMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);

        public async Task SendPrivateMessageToUser(string user, string message)
            => await Clients.User(user).SendAsync("ReceiveMessage", message);

        public async Task SendMessageToLobby(string lobbyName, string message)
            => await Clients.Group(lobbyName).SendAsync("ReceiveMessage", message);


        // Groups
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has left the group {groupName}.");
        }


        //public async Task JoinToRoom

        //public async Task SendMessageToRoom(string roomName, string message)
        //    => await this.Groups

    }
}
