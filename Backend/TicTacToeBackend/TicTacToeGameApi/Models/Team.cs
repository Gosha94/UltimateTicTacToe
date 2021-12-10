using System.Linq;
using System.Collections.Generic;

namespace TicTacToeGameApi.Models
{
    public class Team
    {
        public Team(List<User> users)
        {
            Users = users;
            Name = string.Join(" & ", users.Select(y => y.Name));
        }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public int Points { get; set; } = 0;
        public int CalculatedPoints { get; set; }
    }
}