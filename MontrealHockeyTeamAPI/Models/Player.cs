using System;
using System.Security.Cryptography.X509Certificates;
using MontrealHockeyTeamAPI.Interfaces;

namespace MontrealHockeyTeamAPI.Models
{
    public class Player : IPlayer
    {
        public Player(int id, int number, string name, string lastName, string position, bool isCaptain)
        {
            Id = id;
            Number = number;
            Name = name;
            LastName = lastName;
            Position = position;
            IsCaptain = isCaptain;
        }

        public int Id { get; set; }
        public int Number { get; set; } = 0;
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Position { get; set; } = "";
        public Boolean IsCaptain { get; set; } = false;

    }
}

