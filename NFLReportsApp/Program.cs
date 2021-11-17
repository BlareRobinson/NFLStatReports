﻿using System;
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
                        string answer = Console.ReadLine();
                        if (answer != "Y")
                        {
                            keepTrying = false;
                        }
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
                    //  Console.WriteLine($"Invalid player name {option}");
                    Console.WriteLine("Would you like to keep searching? (Y/N)");
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
            var engine = new PlayerSearchEngine();
            var keepSearching = true;
            while(keepSearching)
            {
                Console.WriteLine("Search Player or Quit?");
                var action = Console.ReadLine();
                if(action == "Search Player")
                {
                    Console.WriteLine("Which player would you like to search for?");
                    var Name = Console.ReadLine();
                    engine.SearchPlayers(Name);
                }
                else if(action == "Quit")
                {
                    keepSearching = false;
                }
                else
                {
                    Console.WriteLine(action + " is not a valid command");
                }
            }
            //var engine = new PlayerSearchEngine();
            //// var Team = Console.ReadLine();     
            //Console.WriteLine("Which player would you like to search for?");
            //var Name = Console.ReadLine();
            //engine.SearchPlayers(Name);
            //Console.WriteLine("Would you like to keep searching? (Y/N)");
            //string answer = Console.ReadLine();
            //if (answer != "Y")
            //{
            //    keepTrying = false;
            //}


            // display a player - return if null - write players to a file use serialize 


        }

        
    }
}

