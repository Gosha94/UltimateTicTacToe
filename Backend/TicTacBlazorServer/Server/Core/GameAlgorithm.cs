namespace UltimateTicTacToeServer.Core
{
    public class GameAlgorithm
    {
        public readonly string botPlayer = "O";
        public readonly string humanPlayer = "X";

        public Move GetBestSpot(string[] board, string player)
        {
            Move bestMove = null;
            var availableSpots = GetAvailableSpots(board);
            foreach (var spot in availableSpots)
            {
                string[] newboard = (string[])board.Clone();
                var newMove = new Move();
                newMove.index = spot;
                newboard[int.Parse(spot)] = player;

                if (!IsWon(newboard, player) && GetAvailableSpots(newboard).Length > 0)
                {
                    if (player == botPlayer)
                    {
                        var result = GetBestSpot(newboard, humanPlayer);
                        newMove.index = result.index;
                        newMove.score = result.score;
                    }
                    else
                    {
                        var result = GetBestSpot(newboard, botPlayer);
                        newMove.index = result.index;
                        newMove.score = result.score;
                    }
                }
                else
                {
                    if (IsWon(newboard, botPlayer))
                        newMove.score = 1;
                    else if (IsWon(newboard, humanPlayer))
                        newMove.score = -1;
                    else
                        newMove.score = 0;
                }

                if (bestMove == null ||
                    (player == botPlayer && newMove.score < bestMove.score) ||
                    (player == humanPlayer && newMove.score > bestMove.score))
                {
                    bestMove = newMove;
                }
            }
            return bestMove;
        }

        public string[] GetAvailableSpots(string[] board) => board.Where(i => !IsPlayed(i)).ToArray();

        public bool IsWon(string[] board, string player)
        {
            if (
                   // Hardcode all combinations
                   (board[0] == player && board[1] == player && board[2] == player) ||
                   (board[3] == player && board[4] == player && board[5] == player) ||
                   (board[6] == player && board[7] == player && board[8] == player) ||
                   (board[0] == player && board[3] == player && board[6] == player) ||
                   (board[1] == player && board[4] == player && board[7] == player) ||
                   (board[2] == player && board[5] == player && board[8] == player) ||
                   (board[0] == player && board[4] == player && board[8] == player) ||
                   (board[2] == player && board[4] == player && board[6] == player)
                   )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsPlayed(string input) => input == "X" || input == "O";

    }

    public class Move
    {
        public int score { get; set; }
        public string index { get; set; }
    }

}
