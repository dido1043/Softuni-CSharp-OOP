using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    using NavalVessels.Models.Contracts;
    public class Submarine : Vessel
    {
        private const double ARMORThickness = 200;
        public bool SubmergeMode { get; private set; }
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, ARMORThickness)
        {
            SubmergeMode = false;
        }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = !SubmergeMode;
            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 4;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 4;
            }
        }
        public void RepairVessel()
        {
            if (ArmorThickness < ARMORThickness)
            {
                ArmorThickness = ARMORThickness;
            }
        }

        public override string ToString()
        {
            var result = SubmergeMode == true ? "ON" : "OFF";
            return base.ToString() + Environment.NewLine + $"*Submerge mode: {result}";
        }
    }
}
