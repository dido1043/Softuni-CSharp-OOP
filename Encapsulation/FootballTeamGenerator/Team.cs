using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string teamName;
        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name) : this()
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.teamName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidName);
                }
                this.teamName = value;
            }
        }
        public int Rating()
        {
            return this.players.Count > 0 ? (int)Math.Round(this.players.Average(p => p.SkillOfPlayer), 0) : 0;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void Remove(string playerName)
        {
            Player playerToRemove = this.players.FirstOrDefault(p => p.Name == playerName);
            if (playerToRemove == null)
            {
                throw new ArgumentException(String.Format(ErrorMessages.InvalidPlayer, playerName, this.Name));
            }
            this.players.Remove(playerToRemove);
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating()}";
        }
    }
}
