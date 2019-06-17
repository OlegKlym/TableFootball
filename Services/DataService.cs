using System;
using System.Collections.Generic;
using TableFootball.Models;

namespace TableFootball.Services
{
    public static class DataService
    {
        public static List<Player> GetPlayers()
        {
            return new List<Player>
            {
                new Player
                {

                    PlayerId = 4,                    
                    Name = "Oleg",
                    Points = 12,
                    Games = 18
                },
                new Player
                {
                    PlayerId = 2,
                    Name = "Andrew",
                    Points = 11,
                    Games = 18
                },
                new Player
                {
                    PlayerId = 5,
                    Name = "Andriy Petrenko",
                    Points = 8,
                    Games = 12
                },
                new Player
                {
                    PlayerId = 1,
                    Name = "Andriy Andrushko",
                    Points = 8,
                    Games = 18
                },
                new Player
                {
                    PlayerId = 3,
                    Name = "Taras",
                    Points = 8,
                    Games = 14
                },
                new Player
                {
                    PlayerId = 6,
                    Name = "Nazar",
                    Points = 7,
                    Games = 16
                },
                new Player
                {
                    PlayerId = 8,
                    Name = "Vitaliy",
                    Points = 0,
                    Games = 12
                }
            };
        }
    }
}
