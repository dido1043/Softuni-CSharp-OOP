
using System;
using System.Collections.Generic;

namespace NavalVessels.Models.Vessels
{
    using NavalVessels.Models.Contracts;
    using NavalVessels.Utilities.Messages;
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private List<string> targets;
        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {

            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;
            this.targets = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }

        public ICaptain Captain
        {
            get => captain;
           set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets => targets.AsReadOnly();

        public void Attack(IVessel target)
        {

            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.targets.Add(target.Name);
        }

        public void RepairVessel()
        {

        }
        public override string ToString()
        {
            var result = this.targets.Count > 0 ? String.Join(", ", this.targets) : "None";
            return $"- {Name}" + Environment.NewLine +
            $"*Type: {this.GetType().Name}" + Environment.NewLine +
            $"*Armor thickness: {ArmorThickness}" + Environment.NewLine +
            $"*Main weapon caliber: {MainWeaponCaliber}" + Environment.NewLine +
            $"*Speed: {Speed} knots" + Environment.NewLine +
            $"*Targets:  {result}";
        }
    }
}
