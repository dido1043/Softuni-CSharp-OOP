using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
    public class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;
        public MilitaryUnit(double cost)
        {
            Cost = cost;
            EnduranceLevel = 1;
        }

        public double Cost
        {
            get => cost;
            private set
            {
                cost = value;
            }
        }

        public int EnduranceLevel
        {
            get => enduranceLevel;
            private set
            {
                enduranceLevel = value;
            }

        }

        public void IncreaseEndurance()
        {
            EnduranceLevel++;
            if (EnduranceLevel == 20)
            {
                throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            }
        }
    }
}
