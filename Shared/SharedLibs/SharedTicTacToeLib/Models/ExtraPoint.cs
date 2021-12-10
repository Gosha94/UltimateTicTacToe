using System.Collections.Generic;

namespace TicTacToeGameApi.Models
{
    public class ExtraPoint
    {
        public ExtraPoint(List<Card> cards, TypeOfExtraPoint typeOfExtraPoint)
        {
            TypeOfExtraPoint = typeOfExtraPoint;
            Cards = cards;
        }
        public List<Card> Cards { get; set; }
        public TypeOfExtraPoint TypeOfExtraPoint { get; set; }
    }
}
