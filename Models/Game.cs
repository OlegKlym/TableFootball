using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TableFootball.Models
{
    public class Game
    {
        [Key]
        public int Id           { get; set; }
        public string Date      { get; set; }
        public int TeamWinnerId { get; set; }

        public List<Team> Teams { get; set; }
    }
}
