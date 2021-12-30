using System;
using System.Threading.Tasks;
using TicTacToeGameApi.Services;
using Microsoft.AspNetCore.SignalR;

namespace TicTacToeGameApi.Hubs
{

    public class LobbysHub : Hub
    {
        private readonly GameManagementService _gameManagementService;
        
        public LobbysHub()
        {
            _gameManagementService = new GameManagementService();
        }

        #region Public API

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //var user = _globalServerUsersPool.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

            //if (user == null)
            //    return;

            //await SendMessageToAllChats("Server", $"{user.Name} has left the server.", TypeOfMessage.Server);

            //await CleanupUserFromGames();
            //await CleanupUserFromUsersList();

            await base.OnDisconnectedAsync(exception);
        }

        #region User Management

        //public async Task AddUser(string name)
        //{
        //    User user;
        //    lock (_users)
        //    {
        //        name = Regex.Replace(name, @"\s+", "").ToLower();

        //        if (name.Length > 10)
        //            name = name.Substring(0, 10);

        //        var nameExists = _users.Any(x => x.Name == name);
        //        if (nameExists)
        //        {
        //            Random rnd = new Random();
        //            name = name + rnd.Next(1, 100);
        //        }


        //        user = new User(Context.ConnectionId, name);

        //        _users.Add(user);
        //    }


        //    await GetAllPlayers();
        //    await Clients.Client(Context.ConnectionId).SendAsync("GetCurrentUser", user);
        //    await SendMessageToAllChat("Server", $"{user.Name} has connected to the server.", TypeOfMessage.Server);
        //    await base.OnConnectedAsync();
        //} //+

        //public async Task GetAllPlayers()
        //{
        //    await Clients.All.SendAsync("GetAllPlayers", _users);
        //} //+

        //public async Task KickUserFromGame(string connectionId, string gameId)
        //{
        //    var game = _games.FirstOrDefault(x => x.GameSetup.Id == gameId);
        //    if (game == null) return;

        //    var user = _users.FirstOrDefault(x => x.ConnectionId == connectionId);
        //    if (user == null) return;

        //    game.Players.Remove(game.Players.SingleOrDefault(y => y.User.ConnectionId == connectionId));

        //    await GameUpdated(game);
        //    await UpdateAllGames();
        //    await Clients.Client(connectionId).SendAsync("KickUSerFromGame");
        //} //+

        #endregion

        #endregion

    }
}