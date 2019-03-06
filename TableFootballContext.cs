using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TableFootball.Models;

namespace TableFootball
{
    public class TableFootballContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }

        public TableFootballContext(){}

        public TableFootballContext(DbContextOptions<TableFootballContext> options)
            : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=football.db");
        }
    }
}
