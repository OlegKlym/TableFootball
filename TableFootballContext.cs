using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TableFootball.Models;

namespace TableFootball
{
    public class TableFootballContext : DbContext
    {
        public DbSet<PlayerEntity> Players { get; set; }
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<TeamEntity> Teams { get; set; }

        public TableFootballContext(DbContextOptions<TableFootballContext> options)
            : base(options)
        { 

        }

        public TableFootballContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=football.db");
        }
    }
}
