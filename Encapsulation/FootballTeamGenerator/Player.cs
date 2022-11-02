using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string playerName;
        public Player(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = playerName;
            this.Stats = new Stats(endurance, sprint, dribble, passing, shooting);
        }
        public string Name
        {
            get => this.playerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ErrorMessages.InvalidName);
                }
                this.playerName = value;
            }
        }
        public Stats Stats { get; private set; }

        public double SkillOfPlayer  =>  (this.Stats.Endurance + this.Stats.Shooting + this.Stats.Sprint + this.Stats.Dribble + this.Stats.Passing) / 5.00;
        
    }
}
