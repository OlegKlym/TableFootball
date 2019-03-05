using System;
using System.Collections.Generic;

namespace TableFootball.Models.Requests
{
    public class GameResultsRequest
    {
        public List<GameEntity> Games { get; set; }
    }
}
