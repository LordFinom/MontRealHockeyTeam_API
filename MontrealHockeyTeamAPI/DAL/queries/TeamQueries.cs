using System;
namespace MontrealHockeyTeamAPI.DAL.queries
{
	public static class TeamQueries
	{
        public static readonly string GET_BY_YEAR = "select teams.*, players.* from player_team inner join teams on teamid = teams.id inner join players on playerid = players.id WHERE teams.year = $year";
        public static readonly string GET_ALL_YEARS = "select teams.*, players.* from player_team inner join teams on teamid = teams.id inner join players on playerid = players.id";
    }
}

