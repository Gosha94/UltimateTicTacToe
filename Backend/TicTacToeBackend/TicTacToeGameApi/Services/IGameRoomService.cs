using System;
using System.Threading.Tasks;

namespace TicTacToeGameApi.Services
{
    interface IGameRoomService
    {

        Task<Guid> CreateGameRoom(string connectionId);

        Task<Guid> GetGameRoomForConnectionId(string connectionId);

    }
}