using System;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    internal struct Player
    {

        private readonly string _playerName;
        public string PlayerName { get => _playerName; }

        private readonly Guid _playerGuid;
        public Guid PlayerGuid { get => _playerGuid; }

        public Player(string playerName)
        {
            _playerName = playerName;
            _playerGuid = new Guid();
        }
        
    }
}