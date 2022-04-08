using System;
using MontrealHockeyTeamAPI.Models;

namespace MontrealHockeyTeamAPI.Interfaces
{
	public interface IPlayer
	{
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public Boolean IsCaptain { get; set; }
    }
}

