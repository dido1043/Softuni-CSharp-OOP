using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace FootballTeamGenerator
{
    public class Program
    {
        private static List<Team> teams;
        static void Main(string[] args)
        {
            //Business Logic
            teams = new List<Team>();
            RunEngine();
        }

        private static void RunEngine()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(';');
                string operation = tokens[0];
                //Console.WriteLine(operation);
                var teamName = tokens[1];
                //todo
                try
                {
                    if (operation == "Team")
                    {
                        AddTeam(teamName);
                    }
                    else if (operation == "Add")
                    {
                        var playerName = tokens[2];
                        AddPlayer(teamName, playerName, int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                    }
                    else if (operation == "Remove")
                    {
                        var playerName = tokens[2];
                        Remove(teamName, playerName);
                    }
                    else if (operation == "Rating")
                    {
                        Rating(teamName);
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }

            }
        }

        private static void Rating(string teamName)
        {
            Team currentTeam = teams.FirstOrDefault(x => x.Name == teamName);
            if (currentTeam == null)
            {
                //TODO
                throw new ArgumentException(ErrorMessages.InexistingTeamMessage, teamName);
            }
            Console.WriteLine($"{teamName} - {currentTeam.Rating()}");
        }

        private static void Remove(string teamName, string playerName)
        {
            Team teamList = teams.FirstOrDefault(x => x.Name == teamName);
            teamList.Remove(playerName);
        }

        private static void AddPlayer(string teamName, string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
            Team teamList = teams.FirstOrDefault(x => x.Name == teamName);
            if (teamList == null)
            {
                //TODO
                throw new ArgumentException(ErrorMessages.InexistingTeamMessage,teamName);
            }
            teamList.AddPlayer(player);
        }

        private static void AddTeam(string name)
        {
            Team team = new Team(name);
            teams.Add(team);
        }
    }
}
