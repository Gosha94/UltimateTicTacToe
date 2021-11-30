using System;
using System.Threading.Tasks;

namespace TicTacToeGameApi.Services
{
    interface IGameLobbyService
    {

        Task<Guid> CreateGameLobby(string connectionId);

        Task<Guid> GetGameLobbyForConnectionId(string connectionId);

    }
}