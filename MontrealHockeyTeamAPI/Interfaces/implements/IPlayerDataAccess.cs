using System;
using MontrealHockeyTeamAPI.Models;

namespace MontrealHockeyTeamAPI.Interfaces.implements
{
	public interface IPlayerDataAccess
	{
        public void AddPlayerOnTeamByYear(int year, Player player);
		public void UpdatePlayerAsCaptain(int id);
	}
}

