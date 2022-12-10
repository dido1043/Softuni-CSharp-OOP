using NUnit.Framework;
using System;

namespace FootballTeam.Tests
{
    public class Tests
    {
        [Test]
        public void FootballPlayerNameShouldBeValid()
        {
            FootballPlayer player = new FootballPlayer("Name", 8, "Forward");
            Assert.IsNotNull(player.Name);
        }
        [Test]
        public void FootballPlayerNameShouldNotBeValid()
        {

            Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer(null, 8, "Forward");
            });
        }

        [Test]
        public void NameShouldBeValid()
        {
            FootballTeam team = new FootballTeam("Name", 15);
            Assert.AreEqual("Name", team.Name);
        }
        [Test]
        public void NameShouldBeNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(null, 15);
            });
        }
        [Test]
        public void NameShouldBeEmptyString()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(String.Empty, 15);
            });
        }

        [Test]
        public void CapacityShouldBeValid()
        {
            FootballTeam team = new FootballTeam("Name", 15);
            Assert.AreEqual(15, team.Capacity);
        }
        [Test]
        public void CapacityShouldNotBeValid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("Name", 13);
            });
        }

        [Test]
        public void AddingNewPlayerShouldWork()
        {
            var team = new FootballTeam("Name", 15);
            FootballPlayer player = new FootballPlayer("Name", 8, "Forward");
            team.AddNewPlayer(player);
            Assert.AreEqual(1, team.Players.Count);
        }
        [Test]
        public void PickAPlayer()
        {
            var team = new FootballTeam("Name", 15);
            FootballPlayer player = new FootballPlayer("Name", 8, "Forward");
            FootballPlayer player2 = new FootballPlayer("Name1", 9, "Midfielder");
            team.AddNewPlayer(player);
            team.AddNewPlayer(player2);
            Assert.AreEqual(player2, team.PickPlayer("Name1"));
        }
        [Test]
        public void ScoreGoalShouldWork()
        {
            var team = new FootballTeam("Name", 15);
            FootballPlayer player = new FootballPlayer("Name", 8, "Forward");
            team.AddNewPlayer(player);
            var footballPlayer = team.PickPlayer("Name");

            Assert.AreEqual("Name scored and now has 1 for this season!", team.PlayerScore(8));
        }
    }
}