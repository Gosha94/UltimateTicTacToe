using System;
using System.Threading.Tasks;

namespace TicTacToeGameApi.Services
{
    public class GameLobbyService : IGameLobbyService
    {
        public Task<Guid> CreateGameLobby(string connectionId)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> GetGameLobbyForConnectionId(string connectionId)
        {
            throw new NotImplementedException();
        }
    }
}
