using System;
using Microsoft.Data.Sqlite;
using MontrealHockeyTeamAPI.Interfaces.implements;
using MontrealHockeyTeamAPI.Models;
using MontrealHockeyTeamAPI.SqlDBContext;
using MontrealHockeyTeamAPI.DAL.queries;
using System.Data;

namespace MontrealHockeyTeamAPI.DAL
{
    public class PlayerData : IPlayerDataAccess
    {
        public void AddPlayerOnTeamByYear(int year, Player player)
        {
            using (var connection = DBConnector.Connection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    SqliteCommand command = new SqliteCommand(PlayerQueries.ADD_TEAM_PLAYER_BY_YEAR, connection, transaction);
                    command.Parameters.AddWithValue("$year", year);
                    command.Parameters.AddWithValue("$number", player.Number);
                    command.Parameters.AddWithValue("$name", player.Name);
                    command.Parameters.AddWithValue("$lastname", player.LastName);
                    command.Parameters.AddWithValue("$position", player.Position);
                    command.Parameters.AddWithValue("$isCaptain", player.IsCaptain);
                    command.ExecuteScalar();
                    transaction.Commit();
                }
            }
        }
        public void UpdatePlayerAsCaptain(int id)
        {
            
            using (var connection = DBConnector.Connection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    SqliteCommand command = new SqliteCommand(PlayerQueries.UPDATE_PLAYER_CAPTAIN, connection, transaction);
                    command.Parameters.AddWithValue("$id", id);
                    command.ExecuteScalar();
                    transaction.Commit();
                }
            }
        }
    }
}

