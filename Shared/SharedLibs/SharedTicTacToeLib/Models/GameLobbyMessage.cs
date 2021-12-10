using System;

namespace TicTacToeGameApi.Models
{

    public class GameLobbyMessage
    {
        public string SenderName { get; set; }

        public string Text { get; set; }

        public DateTimeOffset SentAt { get; set; }
    }
}
