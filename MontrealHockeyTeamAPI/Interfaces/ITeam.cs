using System;
using MontrealHockeyTeamAPI.Models;

namespace MontrealHockeyTeamAPI.Interfaces
{
	public interface ITeam
	{
        public int Id { get; set; }
        public string Coach { get; set; }
        public int Year { get; set; }

        // EF DB Link
        public List<Player> Players { get; set; }
    }
}

