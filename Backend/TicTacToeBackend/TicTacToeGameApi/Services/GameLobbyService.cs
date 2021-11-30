using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeGameApi.Models;

namespace TicTacToeGameApi.Services
{
    public class GameLobbyService : IGameLobbyService
    {

        private readonly Dictionary<Guid, GameLobby> _lobbyInfo = new Dictionary<Guid, GameLobby>();


        public Task<Guid> CreateGameLobby(string connectionId)
        {
            var id = Guid.NewGuid();
            _lobbyInfo[id] = new GameLobby
            {
                OwnerConnectionId = connectionId
            };

            return Task.FromResult(id);
        }

        public Task<Guid> GetGameLobbyForConnectionId(string connectionId)
        {
            var foundRoom = _lobbyInfo.FirstOrDefault(
            x => x.Value.OwnerConnectionId == connectionId);

            if (foundRoom.Key == Guid.Empty)
                throw new ArgumentException("Invalid connection ID");

            return Task.FromResult(foundRoom.Key);
        }
    }
}
