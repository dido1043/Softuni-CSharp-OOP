﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.Weapons
{
    public class BioChemicalWeapon : Weapon
    {
        public BioChemicalWeapon( int destructionLevel) : base(3.2, destructionLevel)
        {
        }
    }
}