using System;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    internal struct Player
    {
        internal bool IsReadyForGame { get; private set; }
        internal string PlayerName { get; }
        internal Guid PlayerGuid { get; }

        public Player(string playerName)
        {
            PlayerName = playerName;
            PlayerGuid = new Guid();
            // TODO fix for some randomize...
            IsReadyForGame = false;
        }

        internal void ChangeGameReadyState()
            => IsReadyForGame = !IsReadyForGame;

    }
}