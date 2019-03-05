﻿using System;
using System.Collections.Generic;
using TableFootball.Models;

namespace TableFootball.Services
{
    public static class DataService
    {
        public static List<PlayerEntity> GetPlayers()
        {
            return new List<PlayerEntity>
            {
                new PlayerEntity
                {
                    PlayerId = 4,
                    Name = "Oleg",
                    Points = 12,
                    Games = 18
                },
                new PlayerEntity
                {
                    PlayerId = 2,
                    Name = "Andrew",
                    Points = 11,
                    Games = 18
                },
                new PlayerEntity
                {
                    PlayerId = 5,
                    Name = "Andriy Petrenko",
                    Points = 8,
                    Games = 12
                },
                new PlayerEntity
                {
                    PlayerId = 1,
                    Name = "Andriy Andrushko",
                    Points = 8,
                    Games = 18
                },
                new PlayerEntity
                {
                    PlayerId = 3,
                    Name = "Taras",
                    Points = 8,
                    Games = 14
                },
                new PlayerEntity
                {
                    PlayerId = 6,
                    Name = "Nazar",
                    Points = 7,
                    Games = 16
                },
                new PlayerEntity
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
