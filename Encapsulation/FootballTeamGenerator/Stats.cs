using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            set
            {
                if (IsInvalidStat(value))
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidStat,nameof(this.Endurance)));
                }
                this.endurance = value;
            }
        }



        public int Sprint
        {
            get => this.sprint;
            set
            {
                if (IsInvalidStat(value))
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidStat, nameof(this.Sprint)));
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get => this.dribble;
            set
            {
                if (IsInvalidStat(value))
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidStat, nameof(this.Dribble)));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get => this.passing;
            set
            {
                if (IsInvalidStat(value))
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidStat, nameof(this.Passing)));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get => this.shooting;
            set
            {
                if (IsInvalidStat(value))
                {
                    throw new ArgumentException(String.Format(ErrorMessages.InvalidStat, nameof(this.Shooting)));
                }
                this.shooting = value;
            }
        }

        private bool IsInvalidStat(int stat)
        {
            return stat < 0 || stat > 100;
        }

    }
}
