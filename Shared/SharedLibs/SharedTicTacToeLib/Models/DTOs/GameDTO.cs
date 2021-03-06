using System.Collections.Generic;

namespace TicTacToeGameApi.Models.DTOs
{
    public class GameDTO
    {
        public GameSetupDto GameSetup { get; set; }
        public List<PlayerDto> Players { get; set; }
        public List<User> Spectators { get; set; }
        public List<Card> MyCards { get; set; }
        public List<TeamDto> Teams { get; set; }
        public User UserTurnToPlay { get; set; }
        public List<CardAndUser> CardsPlayed { get; set; }
        public List<CardAndUser> CardsPlayedPreviousRound { get; set; }
        public List<CardAndUser> CardsDrew { get; set; }
        public int DeckSize { get; set; }
        public bool GameEnded { get; set; } = false;
        public bool GameStarted { get; set; } = false;
        public bool IsFirstRound { get; set; } = false;
        public bool RoundEnded { get; set; } = false;
    }
}
