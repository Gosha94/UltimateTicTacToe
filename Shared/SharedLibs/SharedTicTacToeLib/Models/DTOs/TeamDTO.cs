using System.Collections.Generic;

namespace TicTacToeGameApi.Models.DTOs
{
    public class TeamDTO
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public int CalculatedPoints { get; set; }
    }
}
