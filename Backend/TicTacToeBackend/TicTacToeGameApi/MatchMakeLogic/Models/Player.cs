using System;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    public class Player
    {
        public string UserName { get; set; }
        public Guid ConnectionGuid { get; set; }
    }
}
