using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;

namespace NFLReportsApp
{
    public class PlayerSearchEngine
    {
        

        public List<DisplayPlayers> AllPlayers { get; private set; }

        public PlayerSearchEngine()
        {
           // Initialize();
        }

        public void Initialize()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.thesportsdb.com/api/v1/json/1/");
                var playerJson = client.GetStringAsync("search_all_teams.php?l=NFL").Result;
                var result = JsonConvert.DeserializeObject<PlayerQueryResult>(playerJson);
                //https://www.thesportsdb.com/api/v1/json/1/searchplayers.php?p=Danny%20Welbeck
                AllPlayers = result.player;
            }
        }

        public List<DisplayPlayers> GetAllPlayers()
        {
            return AllPlayers;
        }

        public List<DisplayPlayers> SearchPlayers(string searchName)
        {
            var safeSearch = System.Uri.EscapeDataString(searchName);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.thesportsdb.com/api/v1/json/2/");
                var playerJson = client.GetStringAsync("searchplayers.php?p="+safeSearch).Result;
                var result = JsonConvert.DeserializeObject<PlayerQueryResult>(playerJson);
                //https://www.thesportsdb.com/api/v1/json/1/searchplayers.php?p=Danny%20Welbeck
                AllPlayers = result.player;
            }
            return AllPlayers.Where(t => t.strPlayer.Contains(searchName)).ToList();
        }
    }
}