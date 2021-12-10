using System;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    public class Game
    {

        public Guid GameGuid { get; set; }
        
        public object GameAlgorithm { get; set; }

    }
}
