using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using TableFootball.Models;

namespace TableFootball.Services
{
    public class PlayersService : BaseService
    {
        public void AddNewPlayers(List<Player> players)
        {
            foreach (var player in players)
            {
                AddPlayer(player);
            }
        }

        public void AddPlayer(Player player)
        {
            using (var connection = new SQLiteConnection("Data Source=football.db"))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var insertCommand = connection.CreateCommand();
                        insertCommand.Transaction = transaction;
                        insertCommand.CommandText = "INSERT INTO Players ( Id, Name, Games, Points ) VALUES ( $id, $name, $games, $points)";
                        insertCommand.Parameters.AddWithValue("$name", player.Name);
                        insertCommand.Parameters.AddWithValue("$games", player.Games);
                        insertCommand.Parameters.AddWithValue("$points", player.Points);
                        insertCommand.ExecuteNonQuery();
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }

                    transaction.Commit();
                }
            }
        }

        public Player GetPlayerById(int playerId)
        {
            var player = new Player();

            using (var connection = new SQLiteConnection
           (
               new SQLiteConnectionStringBuilder
               {
                   DataSource = "football.db"
               }
               .ToString()))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var selectCommand = connection.CreateCommand();
                        selectCommand.Transaction = transaction;
                        selectCommand.CommandText = "SELECT * FROM Players WHERE Id == $id";
                        selectCommand.Parameters.AddWithValue("$id", playerId);
                        using (var reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                player.PlayerId = reader.GetInt32(0);
                                player.Name = reader.GetString(1);
                                player.Games = reader.GetInt32(2);
                                player.Points = reader.GetInt32(3);
                                player.AvatarUrl = reader.GetString(4);
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }

                    transaction.Commit();
                }

                return player;
            }
        }

        public List<Player> GetAllPlayers()
        {
            var players = new List<Player>();

            using (var connection = new SQLiteConnection
            (
                new SQLiteConnectionStringBuilder
                {
                    DataSource = "football.db"
                }
                .ToString()))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var selectCommand = connection.CreateCommand();
                        selectCommand.Transaction = transaction;
                        selectCommand.CommandText = "SELECT * FROM Players";
                        using (var reader = selectCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var player = new Player();
                                player.PlayerId = reader.GetInt32(0);
                                player.Name = reader.GetString(1);
                                player.Games = reader.GetInt32(2);
                                player.Points = reader.GetInt32(3);
                                player.AvatarUrl = reader.GetString(4);

                                players.Add(player);
                            }
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }

                    transaction.Commit();
                }
            }

            return players;
        }

        public void ClearPlayersPoints()
        {
            var players = GetAllPlayers();

            foreach (var player in players)
            {
                player.Games = 0;
                player.Points = 0;

                UpdatePlayer(player);
            }
        }

        public void UpdatePlayer(Player player)
        {
            using (var connection = new SQLiteConnection("Data Source=football.db"))
            {
                var updateCommand = connection.CreateCommand();
                updateCommand.CommandText = "UPDATE Players SET Games = $games, Points = $points WHERE id = $id";
                updateCommand.Parameters.AddWithValue("$id", player.PlayerId);
                updateCommand.Parameters.AddWithValue("$games", player.Games);
                updateCommand.Parameters.AddWithValue("$points", player.Points);

                connection.Open();
                updateCommand.ExecuteNonQuery();
            }
        }

        public void UpdatePlayersPoints(List<Game> games)
        {
            foreach (var game in games)
            {
                var winner = game.Teams.FirstOrDefault(t => t.TeamId == game.TeamWinnerId);

                foreach (var player in winner.Players)
                {
                    var playerFromDB = GetPlayerById(player.PlayerId);

                    playerFromDB.Points++;
                    playerFromDB.Games++;

                    UpdatePlayer(playerFromDB);
                }

                var looser = game.Teams.FirstOrDefault(t => t.TeamId != game.TeamWinnerId);

                foreach (var player in looser.Players)
                {
                    var playerFromDB = GetPlayerById(player.PlayerId);

                    playerFromDB.Games++;

                    UpdatePlayer(playerFromDB);
                }
            }
        }
    }
}
