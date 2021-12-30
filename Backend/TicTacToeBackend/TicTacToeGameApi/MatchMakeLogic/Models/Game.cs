using TicTacToeGameApi.MatchMakeLogic.Enums;

namespace TicTacToeGameApi.MatchMakeLogic.Models
{
    internal sealed class Game
    {
        internal GameState GameState { get; private set; }
        internal object GameAlgorithm { get; }

        public Game()
        {
            GameState = GameState.WaitingPlayers;
            GameAlgorithm = new string("SomeAlgorithm");
        }

        internal void Start()
        {
            GameState = GameState.InProcess;
        }

        internal void ReStart()
        {
            GameState = GameState.InProcess;
        }

        internal void Pause()
        {
            GameState = GameState.Paused;
        }

        internal void Continue()
        {
            GameState = GameState.InProcess;
        }

        internal void Cancel()
        {
            GameState = GameState.Canceled;
        }

    }
}