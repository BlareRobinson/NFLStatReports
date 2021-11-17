using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace NFLReportsApp
{
    class Program
    {
        private static object searchEngine;
        private static bool keepTrying;

        static void Main(string[] args)
        {

            var searchEngine = new PlayerSearchEngine();
            // searchEngine.Initialize();

            var keepSearching = true;
            while (keepSearching)
            {
                ShowMenu();
                var option = GetMenuOption();
                switch (option)
                {
                    case 1:
                        var allPlayers = searchEngine.GetAllPlayers();
                        DisplayPlayers(allPlayers);
                        break;
                    case 2:
                        var searchName = GetPlayerSearchName();
                        var matchingPlayer = searchEngine.SearchPlayers(searchName);
                        DisplayPlayers(matchingPlayer);
                        break;
                    case 3:
                        keepSearching = false;
                        return;

                }

            }

        }

        private static void DisplayPlayers(object allPlayers)
        {
            throw new NotImplementedException();
        }

        public class Root
        {
            public List<Player> player { get; set; }
        }

        //private static void DisplayPlayers(object allPlayers)
        //{
        //    throw new NotImplementedException();
        //}

        public static void DisplayPlayers(List<Player> allPlayers)
        {
            if (allPlayers.Count == 0)
            {
                Console.WriteLine("No players found.");
            }
            var i = 0;
            foreach (var player in allPlayers)
            {
                Console.WriteLine($"{++i}) {player.idPlayer}");
            }
        }

        public static string GetPlayerSearchName()

        {

            while(true)
            {
                Console.WriteLine("Enter a players name:");
                var searchName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(searchName))
                {
                    return searchName;
                }
                else
                {
                    Console.WriteLine($"Invalid player name {searchName}");
                }
            }


        }

        public static object GetMenuOption()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (Int32.TryParse(input, out var option))
                {
                    return option;
                }
                else
                {                  
                   // Console.WriteLine($"Invalid player name {option}");
                    string answer = Console.ReadLine();
                    if (answer != "Y")
                    {
                        keepTrying = false;
                    }
                }
                         
            }
        }

        public static void ShowMenu()
        {
            // Console.WriteLine("Which NFL team would you like?");
            var engine = new PlayerSearchEngine();
           // var Team = Console.ReadLine();
            Console.WriteLine("1) Get a list of players by their first name");
            var Name = Console.ReadLine();
            engine.SearchPlayers(Name);
            Console.WriteLine("2) Search a player by full name");
            var fullName = Console.ReadLine();
            engine.SearchPlayers(Name);
            Console.WriteLine("3) Would you like to keep searching? (Y/N)");
            
            // display a player - return if null - write players to a file use serialize 


        }

        
    }
}

