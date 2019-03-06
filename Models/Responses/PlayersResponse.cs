using System;
using System.Collections.Generic;

namespace TableFootball.Models.Responces
{
    public class PlayersResponce : BaseResponce
    {
        public List<Player> Players { get; set; }

        public PlayersResponce() { }
        public PlayersResponce(string error) : base(error) { }
    }
}
