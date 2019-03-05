using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TableFootball.Models
{
    public class TeamEntity
    {
        [Key]
        public int TeamId { get; set; }

        public int GameId { get; set; }
        public GameEntity Game { get; set; }

        public List<PlayerEntity> Players { get; set; }

        public TeamEntity()
        {
            Players = new List<PlayerEntity>();
        }
    }
}
