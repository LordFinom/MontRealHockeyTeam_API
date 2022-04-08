using System;
namespace MontrealHockeyTeamAPI.DAL.queries
{
	public static class PlayerQueries
	{
		public static string ADD_TEAM_PLAYER_BY_YEAR = "INSERT INTO players(number, name, lastname, position, is_Captain) VALUES($number,$name,$lastname,$position,$isCaptain); " +
													   "INSERT INTO player_team(playerId, teamId) VALUES((select id from players where id = last_insert_rowid()), (select id from teams where year = $year))";
		public static string UPDATE_PLAYER_CAPTAIN = "UPDATE players set is_captain = 0 where id IN(select playerId from player_team where teamId = (SELECT teamId from player_team where playerId = $id)); " +
													 "UPDATE players set is_captain = 1 where id = $id;";
	}
}

