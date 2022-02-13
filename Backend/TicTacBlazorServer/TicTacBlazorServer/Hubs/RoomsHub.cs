using Microsoft.AspNetCore.SignalR;

namespace TicTacBlazorServer.Hubs
{
    public class RoomsHub : Hub
    {

        public void GetGameRoomsList() { }
        public void GetWaitingRoomsList() { }
        public void GetGameRoomsPlayersList() { }
        public void GetWaitingRoomsPlayersList() { }

        public void GetTotalPlayersInAllRooms() { }

    }
}
