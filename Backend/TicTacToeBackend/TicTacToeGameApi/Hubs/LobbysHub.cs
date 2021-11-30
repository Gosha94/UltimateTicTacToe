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

        public async Task SendMessageToRoom(string roomName, string message)
            => await Clients.Group(roomName).SendAsync("ReceiveMessage", message);

        public async Task JoinToRoom

        //public async Task SendMessageToRoom(string roomName, string message)
        //    => await this.Groups

    }
}
