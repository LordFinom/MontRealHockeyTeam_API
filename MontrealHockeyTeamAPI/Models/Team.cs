using System;
using System.ComponentModel.DataAnnotations.Schema;
using MontrealHockeyTeamAPI.Interfaces;

namespace MontrealHockeyTeamAPI.Models
{
    public class Team : ITeam
	{
        public Team(int id, string coach, int year, List<Player> players)
        {
            Id = id;
            Coach = coach;
            Year = year;
            Players = players;
        }

        public int Id { get; set; }
        public string Coach { get; set; }
        public int Year { get; set; }

        public List<Player> Players { get; set; }

    }
}

