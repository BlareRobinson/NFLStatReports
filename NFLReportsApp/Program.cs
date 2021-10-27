using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace NFLReportsApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var browseEngine = new NFLBrowseEngine();
            browseEngine.Initialize();
                
            while(true)
            {
                ShowRootMenu();
                var option = GetRootMenuOption();
                switch (option)
                {

                }

            }

        }

        private static object GetRootMenuOption()
        {
            throw new NotImplementedException();
        }

        private static void ShowRootMenu()
        {
            throw new NotImplementedException();
        }

        private static void NFLBrowseEngine()
        {
            throw new NotImplementedException();
        }
    }
}

