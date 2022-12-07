using System;
using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System.Linq;
using System.Text;
namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        public Controller()
        {
            planets = new PlanetRepository();
        }
        public string AddUnit(string unitTypeName, string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }
            if (unitTypeName != typeof(AnonimousImpactUnit).Name &&
                unitTypeName != typeof(SpaceForces).Name &&
                unitTypeName != typeof(StormTroopers).Name)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }
            if (planet.Army.Any(x => x.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            IMilitaryUnit military = null;
            if (unitTypeName == nameof(AnonimousImpactUnit))
            {
                military = new AnonimousImpactUnit();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                military = new SpaceForces();
            }
            else if (unitTypeName == nameof(StormTroopers))
            {
                military = new StormTroopers();
            }


            planet.Spend(military.Cost);
            planet.AddUnit(military);

            return String.Format(OutputMessages.UnitAdded, military.GetType().Name, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (planet.Weapons.Any(x => x.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != nameof(BioChemicalWeapon) &&
                weaponTypeName != nameof(NuclearWeapon) &&
                weaponTypeName != nameof(SpaceMissiles))
            {
                throw new InvalidOperationException();
            }

            IWeapon weapon = null;
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(SpaceMissiles))
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);

        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }
            var planet = new Planet(name, budget);
            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in planets.Models.OrderBy(x => x.Name))
            {
                sb.AppendLine(planet.PlanetInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = planets.FindByName(planetOne);
            var secondPlanet = planets.FindByName(planetTwo);

            bool firstWins = false;
            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                firstPlanet.Spend(firstPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Budget / 2);
                firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(y => y.Price));


                planets.RemoveItem(planetTwo);
                return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);

            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                secondPlanet.Spend(secondPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Budget / 2);
                secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(y => y.Price));

                planets.RemoveItem(planetOne);
                return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
            }
            else
            {
                if (firstPlanet.Weapons.Any(n => n.GetType().Name == nameof(NuclearWeapon)) &&
                    secondPlanet.Weapons.Any(n => n.GetType().Name == nameof(NuclearWeapon)))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }

                if (firstPlanet.Weapons.Any(n => n.GetType().Name == nameof(NuclearWeapon)))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Budget / 2);
                    firstPlanet.Profit(secondPlanet.Army.Sum(x => x.Cost) + secondPlanet.Weapons.Sum(y => y.Price));

                    planets.RemoveItem(planetTwo);
                    return String.Format(OutputMessages.WinnigTheWar, planetOne, planetTwo);
                }
                else
                {
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Budget / 2);
                    secondPlanet.Profit(firstPlanet.Army.Sum(x => x.Cost) + firstPlanet.Weapons.Sum(y => y.Price));

                    planets.RemoveItem(planetOne);
                    return String.Format(OutputMessages.WinnigTheWar, planetTwo, planetOne);
                }
            }
        }

        public string SpecializeForces(string planetName)
        {
            var planet = planets.FindByName(planetName);
            if (planet == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnexistingPlanet, planetName));
            }

            if (!planet.Army.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }

            planet.Spend(1.25);
            planet.TrainArmy();
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
