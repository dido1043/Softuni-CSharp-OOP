using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models.Vessels
{
    public class Battleship : Vessel
    {
        private const double ARMORThickness = 300;
        public bool SonarMode { get; private set; }
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            :base(name,mainWeaponCaliber,speed,ARMORThickness)
        {
            SonarMode = false;
        }

        public void ToggleSonarMode()
        {
            SonarMode = !SonarMode;
            if (SonarMode == true)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
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
            var result = SonarMode == true ? "ON" : "OFF" ;
           return base.ToString() + " " + $"*Sonar mode: {result}"; ;
             
        }
    }
}
