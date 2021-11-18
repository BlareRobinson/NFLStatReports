using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace NFLReportsApp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var searchFile = new ReadFromFile();
            var searchEngine = new PlayerSearchEngine();
            // searchEngine.Initialize();

            var searching = true;
            while (searching)
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
                        var searchText = GetTextSearch();
                        var matchingFile = searchFile.SearchFiles(searchText);
                        break;

                    case 4:
                        searching = false;
                        break;
                        

                }

            }

        }

        private static object GetTextSearch()
        {
            throw new NotImplementedException();
        }

        public static void DisplayPlayers(List<DisplayPlayers> allPlayers)
        {
            if (allPlayers.Count == 0)
            {
                Console.WriteLine("No players found.");
            }
            var i = 0;
            foreach (var player in allPlayers)
            {
                Console.WriteLine($"{++i}) {player.strPlayer}");
            }
        }

        public static string GetPlayerSearchName()

        {

            while (true)
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

        public static int GetMenuOption()
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
                    Console.WriteLine($"Invalid solution {option}");

                    
                }

            }
        }



        public static void ShowMenu()
        {
            var reader = new ReadFromFile();
            var engine = new PlayerSearchEngine();
            var keepSearching = true;
            while (keepSearching)
            {
                Console.WriteLine("Type: Search NFL Player, Cleveland Browns or Quit?");

                var action = Console.ReadLine();
                if (action == "Search NFL Player")
                {
                    Console.WriteLine("Which player would you like to search for?");
                    var Name = Console.ReadLine();
                    engine.SearchPlayers(Name);
                    engine.GetAllPlayers();
                }
                else if (action == "Cleveland Browns")
                {
                    reader.ReadFromText();
                }
                else if (action == "Quit")
                {
                    Console.WriteLine("Thanks for using my App!");
                    keepSearching = false;
                    
                }
                else
                {
                    //IS THERE A WAY TO ADD PLAYERS NAME TO CODE BELOW SO IT RETURNS INVALID
                    Console.WriteLine(action + " is not a valid command");
                }
            }
      

        }


    }
}