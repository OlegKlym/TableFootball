using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TableFootball.Models
{
    public class GameEntity
    {
        [Key]
        public int GameId { get; set; }
        public string Date { get; set; }
        public int TeamWinnerId { get; set; }

        public List<TeamEntity> Teams { get; set; }
    }
}
