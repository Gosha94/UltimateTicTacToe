namespace TicTacToeGameApi.Models.DTOs
{
    public class GameSetupDTO
    {
        public string Id { get; set; }
        public bool IsPasswordProtected { get; set; }
        public int PlayUntilPoints { get; set; }
        public int ExpectedNumberOfPlayers { get; set; }
        public TypeOfDeck TypeOfDeck { get; set; }
        public GameMode GameMode { get; set; }
    }
}
