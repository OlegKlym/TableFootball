using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TableFootball.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public int GameId { get; set; }

        public List<Player> Players { get; set; }

        public Team()
        {
            Players = new List<Player>();
        }
    }
}
