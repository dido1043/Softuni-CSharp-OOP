using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            //Planet tests
            [Test]
            public void NameShouldBeValid()
            {
                Planet planet = new Planet("Planet", 22.5);
                Assert.AreEqual("Planet", planet.Name);
            }

            [Test]
            public void NameShouldBeNull()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 22.5);
                });
            }

            [Test]
            public void NameShouldBeEmptyString()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(String.Empty, 22.5);
                });
            }

            [Test]
            public void BudgetShouldBeValid()
            {
                const double budget = 22.5;
                Planet planet = new Planet("Planet", 22.5);
                Assert.AreEqual(budget, planet.Budget);
            }
            [Test]
            public void BudgetShouldThrowError()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("Planet", -1);
                });
            }

            [Test]
            public void AddingToBudget()
            {
                Planet planet = new Planet("Planet", 22.5);
                planet.Profit(10.5);
                Assert.AreEqual(33, planet.Budget);
            }

            [Test]
            public void SpendingBudget()
            {
                Planet planet = new Planet("Planet", 33);
                planet.SpendFunds(10.5);
                Assert.AreEqual(22.5, planet.Budget);
            }

            [Test]
            public void SpeningBudgetShouldThrowError()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Planet planet = new Planet("Planet", 33);
                    planet.SpendFunds(35);
                });
            }

            [Test]
            public void AddingWeapon()
            {
                Planet planet = new Planet("Planet", 33);
                Weapon weapon = new Weapon("Weapon", 22.5, 10);
                planet.AddWeapon(weapon);
                Assert.AreEqual(1, planet.Weapons.Count);
            }

            [Test]
            public void AddingWeaponShouldBeInvalid()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Planet planet = new Planet("Planet", 33);
                    Weapon weapon = new Weapon("Weapon", 22.5, 10);
                    Weapon weapon2 = new Weapon("Weapon", 22, 11);
                    planet.AddWeapon(weapon);
                    planet.AddWeapon(weapon2);
                });
            }

            [Test]
            public void RemovingWeaponShouldWork()
            {
                Planet planet = new Planet("Planet", 33);
                Weapon weapon = new Weapon("Weapon", 22.5, 10);
                planet.AddWeapon(weapon);
                planet.RemoveWeapon("Weapon");
                Assert.AreEqual(0, planet.Weapons.Count);
            }
            [Test]
            public void UpgradeWeapon()
            {
                Planet planet = new Planet("Planet", 33);
                Weapon weapon = new Weapon("Weapon", 22.5, 10);
                planet.AddWeapon(weapon);
                planet.UpgradeWeapon("Weapon");
                Assert.AreEqual(11, weapon.DestructionLevel);
            }
            [Test]
            public void UpgradeWeaponShouldThrowError()
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Planet planet = new Planet("Planet", 33);
                    Weapon weapon = new Weapon("Weapon", 22.5, 10);
                    planet.UpgradeWeapon("Weapon");
                });
            }

            
        }
    }
}
