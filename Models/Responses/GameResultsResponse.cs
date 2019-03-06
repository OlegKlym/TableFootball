using System;
using System.Collections.Generic;

namespace TableFootball.Models.Responces
{
    public class GameResultsResponce : BaseResponce
    {
        public List<Player> Players { get; set; }

        public GameResultsResponce() { }
        public GameResultsResponce(string error) : base(error) { }
    }
}
