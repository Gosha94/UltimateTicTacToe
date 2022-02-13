namespace TicTacBlazorServer.Data
{
    public class Player
    {
        public bool IsReadyForGame { get; private set; }
        public string PlayerName { get; }
        public Guid PlayerGuid { get; }

        public Player(string playerName)
        {
            PlayerName = playerName;
            PlayerGuid = new Guid();            
            IsReadyForGame = false;
        }

        public void ChangeReadyState()
            => IsReadyForGame = !IsReadyForGame;
    }
}
