using System;
using System.Threading.Tasks;

namespace TicTacToeGameApi.Services
{
    public interface IGameLobbyService
    {

        Task<Guid> CreateGameLobby(string connectionId);

        Task<Guid> GetGameLobbyForConnectionId(string connectionId);

    }
}