using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;

namespace TicTacToeGameApi.Hubs
{
    public class LobbysHub : Hub
    {
        private static List<Game> _games = new List<Game>();
        private static List<User> _users = new List<User>();
        private readonly IMapper _mapper;

        public LobbysHub(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Public API

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

            if (user == null)
                return;

            await SendMessageToAllChats("Server", $"{user.Name} has left the server.", TypeOfMessage.Server);

            await CleanupUserFromGames();
            await CleanupUserFromUsersList();

            await base.OnDisconnectedAsync(exception);
        }

        #region Game Management

        public async Task CreateGame(int playUntilPoints, int expectedNumberOfPlayers, GameMode gameMode, TypeOfDeck typeOfDeck, string password) { }
        public async Task StartGame(string gameId) { }
        public async Task JoinGame(string gameId, string password) { }
        public async Task ExitGame(string gameid) { }
        public async Task StartNewRound(string gameId) { }
        public async Task UpdateAllGames() { }
        public async Task UpdateGame(string gameId, int playUntilPoints, int expectedNumberOfPlayers, GameMode gameMode, TypeOfDeck typeOfDeck, string password) { }

        #endregion

        #region User Management

        public async Task AddUser(string name) { }
        public async Task GetAllPlayers() { }

        #endregion

        #region Messaging

        public async Task SendMessageToAllChats(string username, string message, TypeOfMessage typeOfMessage = TypeOfMessage.Chat) { }
        public async Task SendMessageToGameChat(string gameId, string username, string message, TypeOfMessage typeOfMessage = TypeOfMessage.Chat) { }

        #endregion

        public async Task CallAction(string action, string gameid) { }

        
        public async Task KickUserFromGame(string connectionId, string gameId) { }

        public async Task MakeMove(string gameId, Card card) { }
        
        public async Task AddExtraPoints(string gameId, List<Card> cards) { }


        #endregion

        #region Private Methods

        private async Task DisplayToastMessageToGame(string gameid, string message) { }
        private async Task DisplayToastMessageToUser(string connectionId, string message) { }
        private async Task SendSoundCommandToGame(string gameid, string sound) { }
        private async Task GameUpdated(Game game) { }
        private List<string> GetPlayersFromGame(Game game) { }
        //private List<string> GetSpectatorsFromGame(Game game) { }
        private async Task CleanupUserFromGames() { }
        private async Task CleanupUserFromGamesExceptThisGame(string gameId) { }
        private async Task CleanupUserFromUsersList() { }


        #endregion

    }
}