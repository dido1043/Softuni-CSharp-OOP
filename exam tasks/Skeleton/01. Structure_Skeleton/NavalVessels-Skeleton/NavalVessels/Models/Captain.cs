using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    public class Captain : ICaptain
    {
        private string name;
        private int combatExperience;
        private List<IVessel> vessels;
        public Captain(string fullName)
        {
            name = fullName; 
            combatExperience = 0;
            vessels = new List<IVessel>();
        }
        public string FullName
        {
            get => name;
            private  set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidCaptainName);
                }
                name = value;
            }
        }
        public int CombatExperience 
        {
            get => combatExperience;
            private set
            {
                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels => vessels.AsReadOnly();

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            combatExperience += 10;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {vessels.Count} vessels.");

            if (vessels.Any())
            {
                foreach (IVessel vl in vessels)
                {
                    sb.AppendLine();
                    vl.ToString(); 
                }
            }
            return sb.ToString();
        }
    }
}
