﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TicTacToeGameApi.MatchMakeLogic.Models;

namespace TicTacToeGameApi.Hubs
{

    public class LobbysHub : Hub
    {
        //private static List<Game> _globalServerGamesPool = new List<Game>();        
        private readonly WaitingRoom _gameWaitingRoom;
        private List<Game> _matchServerGamePool;
        
        public LobbysHub()
        {
            _gameWaitingRoom = new WaitingRoom();
            _gameWaitingRoom = new List<Game>();
        }
        

        #region Public API

        public async Task AddNewPlayerToWaitingRoom(string userName, int clientId)
        {
            _gameWaitingRoom.WaitingRoomPlayersList.Add(new Player()); 
        }

        public async Task GetPlayersListInWaitingRoom()
        {
            Clients.AllExcept()
        }

        public async Task ServerSend(string message)
        {
            await Clients.All.SendAsync("ReceiveMessageOnClient", message);
        }

        public TestModel GetActualModel()
            => _model;

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

        #region Game Management

        //public async Task CreateGame(
        //    int playUntilPoints,
        //    int expectedNumberOfPlayers,
        //    GameMode gameMode,
        //    TypeOfDeck typeOfDeck,
        //    string password
        //    )
        //{
        //    await CleanupUserFromGames();

        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    var gameSetup = new GameSetup(playUntilPoints, expectedNumberOfPlayers, gameMode, password, typeOfDeck);

        //    var game = new Game(gameSetup);
        //    game.Players.Add(new Player(user));
        //    _games.Add(game);
        //    await GameUpdated(game);
        //    await UpdateAllGames();
        //    await SendMessageToAllChat("Server", $"User {user.Name} has created new game", TypeOfMessage.Server);
        //} //+

        //public async Task StartGame(string gameId)
        //{
        //    var game = _games.FirstOrDefault(x => x.GameSetup.Id == gameId);
        //    if (game == null) return;

        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    if (user == null) return;

        //    var success = game.StartGame();

        //    if (success)
        //        await GameUpdated(game);

        //    await UpdateAllGames();
        //} //+

        //public async Task JoinGame(string gameId, string password)
        //{
        //    await CleanupUserFromGamesExceptThisGame(gameId);


        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    if (user == null)
        //    {
        //        return;
        //    }


        //    var game = _games.SingleOrDefault(x => x.GameSetup.Id == gameId);
        //    if (game == null)
        //        return;

        //    var isAlreadySpectator = game.Spectators.Contains(user);

        //    if (!string.IsNullOrEmpty(game.GameSetup.Password) && !isAlreadySpectator)
        //        if (game.GameSetup.Password != password)
        //            return;

        //    if (!game.GameStarted)
        //    {
        //        if (isAlreadySpectator)
        //        {
        //            //join the gamt that hasn't started
        //            if (game.Players.Count == game.GameSetup.ExpectedNumberOfPlayers)
        //                return;
        //            game.Spectators.Remove(user);
        //            game.Players.Add(new Player(user));
        //        }
        //        else
        //        {
        //            //spectate game that hasn't started
        //            game.Spectators.Add(user);
        //            await SendMessageToGameChat(gameId, "Server", $"{user.Name} has joined the game room.", TypeOfMessage.Server);
        //        }
        //    }
        //    else
        //    {
        //        var playerLeftWithThisNickname = game.Players.FirstOrDefault(x => x.LeftGame && x.User.Name == user.Name);

        //        if (playerLeftWithThisNickname != null)
        //        {
        //            playerLeftWithThisNickname.User = user;
        //            playerLeftWithThisNickname.LeftGame = false;

        //            game.Teams.ForEach(t =>
        //            {
        //                t.Users.ForEach(u =>
        //                {
        //                    if (u.Name == user.Name)
        //                    {
        //                        u.ConnectionId = user.ConnectionId;
        //                    }
        //                });
        //            });
        //            if (game.UserTurnToPlay.Name == user.Name)
        //                game.UserTurnToPlay = user;
        //            await DisplayToastMessageToGame(gameId, $"PLAYER {user.Name} HAS RECONNECTED TO THE GAME");
        //            await SendMessageToGameChat(gameId, "Server", $"{user.Name} has joined the game room.", TypeOfMessage.Server);
        //        }
        //        else
        //        {
        //            game.Spectators.Add(user);
        //            await SendMessageToGameChat(gameId, "Server", $"{user.Name} has joined the game room.", TypeOfMessage.Server);
        //        }
        //    }


        //    await GameUpdated(game);
        //    await UpdateAllGames();
        //} //+

        //public async Task ExitGame(string gameid)
        //{
        //    var currentGame = _globalServerGamesPool.SingleOrDefault(x => x.GameSetup.Id == gameid);

        //    if (currentGame == null)
        //        return;

        //    var userForExit = _globalServerUsersPool.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

        //    //var allWatchersFromTheGame = GetSpectatorsFromGame(game);
        //    var allPlayersFromGame = GetPlayersFromGame(currentGame);

        //    //if (allSpectatorsFromTheGame.Contains(Context.ConnectionId))
        //    //{
        //    //    currentGame.Spectators.Remove(currentGame.Spectators.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId));
        //    //}

        //    if (allPlayersFromGame.Contains(Context.ConnectionId))
        //    {
        //        var player = currentGame.Players.FirstOrDefault(y => y.User.ConnectionId == Context.ConnectionId);
        //        if (currentGame.GameStarted)
        //        {
        //            player.LeftGame = true;
        //            await DisplayToastMessageToGame(gameid, $"USER {player.User.Name} HAS LEFT THE GAME.");
        //        }
        //        else
        //        {
        //            currentGame.Players.Remove(player);
        //        }
        //    }

        //    if (!currentGame.Players.Any(x => x.LeftGame == false) && !currentGame.Spectators.Any())
        //    {
        //        _globalServerGamesPool.Remove(currentGame);
        //    }

        //    await GameUpdated(currentGame);
        //    await UpdateAllGames();
        //    await SendMessageToGameChat(gameid, "Server", $"{userForExit.Name} has left the game.", TypeOfMessage.Server);
        //} //+

        //public async Task StartNewRound(string gameId)
        //{
        //    var game = _games.SingleOrDefault(x => x.GameSetup.Id == gameId);
        //    if (game == null)
        //        return;
        //    game.InitializeNewGame();
        //    await GameUpdated(game);
        //} //+

        //public async Task UpdateAllGames()
        //{
        //    var games = _mapper.Map<List<GameDto>>(_games);
        //    await Clients.All.SendAsync("UpdateAllGames", games);
        //} //+

        //public async Task UpdateGame(
        //    string gameId,
        //    int playUntilPoints,
        //    int expectedNumberOfPlayers,
        //    GameMode gameMode,
        //    TypeOfDeck typeOfDeck,
        //    string password
        //    )
        //{
        //    var gameForUpdate = _globalServerGamesPool.FirstOrDefault(x => x.GameSetup.Id == gameId);

        //    if (gameForUpdate == null) return;
        //    if (gameForUpdate.GameStarted) return;

        //    var user = _globalServerUsersPool.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

        //    if (user == null) return;
        //    if (gameForUpdate.Players.First().User != user) return;

        //    gameForUpdate.GameSetup.Password = password;
        //    gameForUpdate.GameSetup.ExpectedNumberOfPlayers = expectedNumberOfPlayers;
        //    gameForUpdate.GameSetup.GameMode = gameMode;
        //    gameForUpdate.GameSetup.PlayUntilPoints = playUntilPoints;
        //    gameForUpdate.GameSetup.TypeOfDeck = typeOfDeck;

        //    await GameUpdated(gameForUpdate);
        //    await UpdateAllGames();
        //} //+

        //public async Task CallAction(string action, string gameid)
        //{
        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

        //    var message = $"Player {user.Name} is calling on action: {action}";
        //    await DisplayToastMessageToGame(gameid, message);

        //    if (action == "KNOCK")
        //        await SendSoundCommandToGame(gameid, "KnockPlayer");
        //    else if (action == "SLIDE")
        //    {
        //        //TODO
        //    }
        //} //+

        //public async Task MakeMove(string gameId, Card card)
        //{
        //    bool isLastCardAceOfClubsInEvasionMode = false;
        //    var game = _games.SingleOrDefault(x => x.GameSetup.Id == gameId);
        //    lock (game)
        //    {
        //        if (game == null)
        //            return;
        //        if (game.GameEnded)
        //            return;
        //        var success = game.MakeMove(Context.ConnectionId, card);
        //        if (!success)
        //            return;
        //        isLastCardAceOfClubsInEvasionMode = game.IsLastCardAceOfClubsInEvasionMode;
        //    }
        //    await GameUpdated(game);
        //    if (isLastCardAceOfClubsInEvasionMode)
        //        await SendSoundCommandToGame(game.GameSetup.Id, "AceOfClubsPlayer");
        //} //+

        //public async Task AddExtraPoints(string gameId, List<Card> cards)
        //{
        //    var game = _games.SingleOrDefault(x => x.GameSetup.Id == gameId);
        //    if (game == null)
        //        return;
        //    if (game.GameEnded)
        //        return;

        //    var success = game.AddExtraPoints(Context.ConnectionId, cards);
        //    if (!success)
        //    {
        //        await DisplayToastMessageToUser(Context.ConnectionId, "You cannot add these extra points");
        //        return;
        //    }
        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    var message = $"Player {user.Name} added extra points:";
        //    cards.ForEach(x =>
        //    {
        //        message += $"{(CardColor)x.Color} {(CardNumber)x.Number},";
        //    });
        //    await DisplayToastMessageToGame(gameId, message);

        //    var usersToNotify = GetPlayersFromGame(game);
        //    usersToNotify.AddRange(GetSpectatorsFromGame(game));


        //    await SendMessageToGameChat(gameId, "Server", $"Player {user.Name} has added {cards.Count} extra points.", TypeOfMessage.Server);
        //    await GameUpdated(game);
        //} //+

        #endregion

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

        #region Messaging

        //public async Task SendMessageToAllChats(
        //    string username,
        //    string message,
        //    TypeOfMessage typeOfMessage = TypeOfMessage.Chat
        //    )
        //{
        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

        //    Regex regex = new Regex(@"^/(slap|buzz|alert) ([A-Za-z0-9\s]*)$");
        //    Match match = regex.Match(message);

        //    if (match.Success)
        //    {
        //        var targetedUsername = match.Groups[2].Value;
        //        var targetedUser = _users.FirstOrDefault(x => x.Name == targetedUsername);

        //        if (targetedUser != null)
        //        {
        //            var canBeBuzzedAfter = targetedUser.LastBuzzedUtc.AddSeconds(Constants.MINIMUM_TIME_SECONDS_BETWEEN_BUZZ);
        //            if (DateTime.Now > canBeBuzzedAfter)
        //            {
        //                targetedUser.LastBuzzedUtc = DateTime.Now;
        //                await Clients.Client(targetedUser.ConnectionId).SendAsync("BuzzPlayer");
        //                await SendMessageToAllChat("Server", $"User {user.Name} has buzzed player {targetedUser.Name} ", TypeOfMessage.Server);
        //            }
        //            else
        //            {
        //                var msgDto = new ChatMessage("Server", $"User {targetedUser.Name} was not buzzed! Wait {Constants.MINIMUM_TIME_SECONDS_BETWEEN_BUZZ} seconds.", TypeOfMessage.Server);
        //                await Clients.Caller.SendAsync("SendMessageToAllChat", msgDto);
        //            }
        //        }
        //        else
        //        {
        //            var msgDto = new ChatMessage("Server", $"User {targetedUsername} was not found!", TypeOfMessage.Server);
        //            await Clients.Caller.SendAsync("SendMessageToAllChat", msgDto);
        //        }
        //        return;
        //    }

        //    var msg = new ChatMessage(username, message, typeOfMessage);
        //    await Clients.All.SendAsync("SendMessageToAllChat", msg);
        //} //+

        //public async Task SendMessageToGameChat(
        //    string gameId,
        //    string username,
        //    string message,
        //    TypeOfMessage typeOfMessage = TypeOfMessage.Chat
        //    )
        //{
        //    var game = _games.FirstOrDefault(x => x.GameSetup.Id == gameId);
        //    if (game == null)
        //        return;

        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
        //    if (user == null)
        //        return;

        //    Regex regex = new Regex(@"^/(slap|buzz|alert) ([A-Za-z0-9\s]*)$");
        //    Match match = regex.Match(message);

        //    if (match.Success)
        //    {
        //        var targetedUsername = match.Groups[2].Value;
        //        var targetedUser = _users.FirstOrDefault(x => x.Name == targetedUsername);

        //        if (targetedUser != null)
        //        {
        //            var canBeBuzzedAfter = targetedUser.LastBuzzedUtc.AddSeconds(Constants.MINIMUM_TIME_SECONDS_BETWEEN_BUZZ);
        //            if (DateTime.Now > canBeBuzzedAfter)
        //            {
        //                targetedUser.LastBuzzedUtc = DateTime.Now;
        //                await Clients.Client(targetedUser.ConnectionId).SendAsync("BuzzPlayer");
        //                await SendMessageToGameChat(gameId, "Server", $"User {user.Name} has buzzed player {targetedUser.Name} ", TypeOfMessage.Server);
        //            }
        //            else
        //            {
        //                var msgDto = new ChatMessage("Server", $"User {targetedUser.Name} was not buzzed! Wait {Constants.MINIMUM_TIME_SECONDS_BETWEEN_BUZZ} seconds.", TypeOfMessage.Server);
        //                await Clients.Caller.SendAsync("SendMessageToGameChat", msgDto);
        //            }
        //        }
        //        else
        //        {
        //            var msgDto = new ChatMessage("Server", $"User {targetedUsername} was not found!", TypeOfMessage.Server);
        //            await Clients.Caller.SendAsync("SendMessageToGameChat", msgDto);
        //        }
        //        return;
        //    }

        //    var msg = new ChatMessage(username, message, typeOfMessage);

        //    var usersToNotify = GetPlayersFromGame(game);
        //    usersToNotify.AddRange(GetSpectatorsFromGame(game));

        //    await Clients.Clients(usersToNotify).SendAsync("SendMessageToGameChat", msg);
        //} //+

        #endregion

        #endregion

        #region Private Methods

        //private async Task DisplayToastMessageToGame(string gameid, string message)
        //{
        //    var game = _games.FirstOrDefault(x => x.GameSetup.Id == gameid);
        //    if (game == null)
        //        return;
        //    var usersToNotify = GetPlayersFromGame(game);
        //    usersToNotify.AddRange(GetSpectatorsFromGame(game));

        //    await Clients.Clients(usersToNotify).SendAsync("DisplayToastMessage", message);
        //}

        private async Task DisplayToastMessageToUser(string connectionId, string message)
        {
            await Clients.Client(connectionId).SendAsync("DisplayToastMessage", message);
        }

        private async Task SendSoundCommandToGame(string gameid, string sound)
        {
            //var game = _games.FirstOrDefault(x => x.GameSetup.Id == gameid);
            //if (game == null)
            //    return;
            //var usersToNotify = GetPlayersFromGame(game);
            //usersToNotify.AddRange(GetSpectatorsFromGame(game));

            //await Clients.Clients(usersToNotify).SendAsync(sound);
        }

        //private async Task GameUpdated(Game game)
        //{
        //    var allPlayersInTheGame = GetPlayersFromGame(game);
        //    var gameDto = _mapper.Map<GameDto>(game);

        //    var allSpectatorsInTheGame = GetSpectatorsFromGame(game);
        //    await Clients.Clients(allSpectatorsInTheGame).SendAsync("GameUpdate", gameDto);

        //    if (game.GameStarted)
        //    {
        //        foreach (var connectionId in allPlayersInTheGame)
        //        {
        //            gameDto.MyCards = game.Players.FirstOrDefault(x => x.User.ConnectionId == connectionId).Cards;
        //            await Clients.Client(connectionId).SendAsync("GameUpdate", gameDto);
        //        }
        //    }
        //    else
        //    {
        //        await Clients.Clients(allPlayersInTheGame).SendAsync("GameUpdate", gameDto);
        //    }
        //}

        //private List<string> GetPlayersFromGame(Game game)
        //    => game.Players
        //            .Where(x => !x.LeftGame)
        //            .Select(y => y.User.ConnectionId)
        //            .ToList();

        //private List<string> GetSpectatorsFromGame(Game game)
        //    => game.Spectators
        //        .Select(y => y.ConnectionId)
        //        .ToList();

        //private async Task CleanupUserFromGames()
        //{
        //    List<Game> games = _games.Where(x => GetPlayersFromGame(x).Where(y => y == Context.ConnectionId).Any()).ToList();

        //    games.AddRange(_games.Where(x => GetSpectatorsFromGame(x).Where(y => y == Context.ConnectionId).Any()).ToList());

        //    foreach (var game in games)
        //    {
        //        await ExitGame(game.GameSetup.Id);
        //    }
        //}

        //private async Task CleanupUserFromGamesExceptThisGame(string gameId)
        //{
        //    List<Game> games = _games.Where(x => x.GameSetup.Id != gameId && GetPlayersFromGame(x).Where(y => y == Context.ConnectionId).Any()).ToList();

        //    games.AddRange(_games.Where(x => x.GameSetup.Id != gameId && GetSpectatorsFromGame(x).Where(y => y == Context.ConnectionId).Any()).ToList());

        //    foreach (var game in games)
        //    {
        //        await ExitGame(game.GameSetup.Id);
        //    }
        //}

        //private async Task CleanupUserFromUsersList()
        //{
        //    var user = _users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);

        //    if (user != null)
        //    {
        //        _users.Remove(user);
        //    }
        //    await GetAllPlayers();
        //}

        #endregion

    }
}