using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using MontrealHockeyTeamAPI.DAL.queries;
using MontrealHockeyTeamAPI.Interfaces.implements;
using MontrealHockeyTeamAPI.Models;
using MontrealHockeyTeamAPI.SqlDBContext;

namespace MontrealHockeyTeamAPI.DAL
{
    public class TeamData : ITeamDataAccess
    {
        
        public List<Team> GetAllTeamsWithPlayers()
        {
            List<Team> teams = new List<Team>();
            Team currentTeam = new Team(0, "", 0, new List<Player>());
            int yearFlag = 0;
            using (var connection = DBConnector.Connection())
            {
                connection.OpenAsync();
                var command = connection.CreateCommand();
                command.CommandText = TeamQueries.GET_ALL_YEARS;


                using (SqliteDataReader? reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (yearFlag == 0)
                        {
                            // INIT
                            yearFlag = reader.GetInt32(2);
                            currentTeam.Id = reader.GetInt32(0);
                            currentTeam.Coach = reader.GetString(1);
                            currentTeam.Year = reader.GetInt32(2);
                            currentTeam.Players = new List<Player>();
                        }
                        else if (yearFlag != reader.GetInt32(2))
                        {
                            // On change we stock the team and reinit on next year
                            teams.Add(currentTeam);
                            yearFlag = reader.GetInt32(2);
                            currentTeam = new Team(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), new List<Player>());
                        }
                        //DATA
                        Player player = new Player(
                            reader.GetInt32(3),
                            reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                            reader.IsDBNull(5) ? "" : reader.GetString(5),
                            reader.IsDBNull(6) ? "" : reader.GetString(6),
                            reader.IsDBNull(7) ? "" : reader.GetString(7),
                            reader.GetBoolean(8)
                            );
                        // Player
                        currentTeam.Players.Add(player);

                    }
                    // Adding final team
                    teams.Add(currentTeam);
                    reader.Close();

                }
                return teams;
            }
        }
        public Team GetTeamByYearWithPlayers(int year)
        {
            Team returnTeam = new Team(0, "", 0, new List<Player>());
            Boolean initFlag = true;
            using (var connection = DBConnector.Connection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = TeamQueries.GET_BY_YEAR;
                command.Parameters.AddWithValue("$year", year);

                using (SqliteDataReader? reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (initFlag)
                        {
                            // INIT
                            returnTeam.Id = reader.GetInt32(0);
                            returnTeam.Coach = reader.GetString(1);
                            returnTeam.Year = reader.GetInt32(2);
                            returnTeam.Players = new List<Player>();
                            initFlag = false;
                        }
                        //DATA
                        Player player = new Player(
                            reader.GetInt32(3),
                            reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                            reader.IsDBNull(5) ? "" : reader.GetString(5),
                            reader.IsDBNull(6) ? "" : reader.GetString(6),
                            reader.IsDBNull(7) ? "" : reader.GetString(7),
                            reader.GetBoolean(8)
                            );
                        // Player
                        returnTeam.Players.Add(player);

                    }
                    reader.Close();

                }
                return returnTeam;
            }
        }
    }
}