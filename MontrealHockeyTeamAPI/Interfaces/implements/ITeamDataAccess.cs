using System;
using Microsoft.AspNetCore.Mvc;
using MontrealHockeyTeamAPI.Models;

namespace MontrealHockeyTeamAPI.Interfaces.implements
{
	public interface ITeamDataAccess
	{
		/// <summary>
        /// Get all Teams with assiociate players
        /// </summary>
        /// <returns>The team list</returns>
		public List<Team> GetAllTeamsWithPlayers();
        /// <summary>
        /// Get one team with year parameter and assiociate players
        /// </summary>
        /// <param name="year"></param>
        /// <returns>one Team</returns>
        public Team GetTeamByYearWithPlayers(int year);
	}
}

