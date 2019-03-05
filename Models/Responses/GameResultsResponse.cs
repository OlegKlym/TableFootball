using System;
using System.Collections.Generic;

namespace TableFootball.Models.Responces
{
    public class GameResultsResponce : BaseResponce
    {
        public List<PlayerEntity> Players { get; set; }

        public GameResultsResponce() { }
        public GameResultsResponce(string error) : base(error) { }
    }
}
