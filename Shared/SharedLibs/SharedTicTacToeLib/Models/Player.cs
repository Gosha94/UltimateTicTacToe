using System.Linq;
using System.Collections.Generic;

namespace TicTacToeGameApi.Models
{
    public class Player
    {
        private List<Card> _cards;
        public Player(User user)
        {
            User = user;
            ExtraPoints = new List<ExtraPoint>();
        }
        public List<Card> Cards
        {
            get
            {
                _cards = _cards.OrderBy(y => y.Color).ThenBy(y => y.Number).ToList();
                return _cards;
            }
            set { _cards = value; }
        }
        public User User { get; set; }
        public bool LeftGame { get; set; }
        public List<ExtraPoint> ExtraPoints { get; set; }
    }
}
