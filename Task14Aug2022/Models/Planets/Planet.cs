using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
namespace PlanetWars.Models.Planets
{


    public class Planet : IPlanet
    {
        private string name;
        private double budget;

        private WeaponRepository weaponRepository;
        private UnitRepository unitRepository;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            this.weaponRepository = new WeaponRepository();
            this.unitRepository = new UnitRepository();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get => budget;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budget = value;
            }
        }

        public double MilitaryPower => CalculateMilitaryPowerValues();

        public IReadOnlyCollection<IMilitaryUnit> Army => unitRepository.Models;

        public IReadOnlyCollection<IWeapon> Weapons => weaponRepository.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            unitRepository.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weaponRepository.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            var result = "";
            Queue<string> list = new Queue<string>();
            if (unitRepository.Models.Count > 0)
            {
                foreach (var item in unitRepository.Models)
                {
                    list.Enqueue(item.GetType().Name);
                }
                result = String.Join(", ", list);
            }
            else
            {
                result = "No units";
            }

            var resultTwo = "";
            Queue<string> queue = new Queue<string>();
            if (weaponRepository.Models.Count > 0)
            {
                foreach (var item in weaponRepository.Models)
                {
                    queue.Enqueue(item.GetType().Name);
                }
                resultTwo = String.Join(", ", queue);
            }
            else
            {
                resultTwo = "No weapons";
            }

            return $"Planet: {name}" + Environment.NewLine +
            $"--Budget: {budget} billion QUID" + Environment.NewLine +
            $"--Forces: {result}" + Environment.NewLine +
            $"--Combat equipment: {resultTwo}" + Environment.NewLine +
            $"--Military Power: {MilitaryPower}";


        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (Budget < amount)
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var item in unitRepository.Models)
            {
                item.IncreaseEndurance();
            }
        }

        private double CalculateMilitaryPowerValues()
        {
            double result = unitRepository.Models.Sum(x => x.EnduranceLevel) + weaponRepository.Models.Sum(x => x.DestructionLevel);

            if (unitRepository.Models.Any(x => x.GetType().Name == typeof(AnonimousImpactUnit).Name))
            {
                result *= 1.3;
            }
            if (weaponRepository.Models.Any(y => y.GetType().Name == typeof(NuclearWeapon).Name))
            {
                result *= 1.45;
            }
            return result;
        }
    }
}