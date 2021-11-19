using System;
using System.IO;

namespace NFLReportsApp
{

    class ReadFromFile
    {
        public void ReadFromText()
        {
            try
            {
                
                string fileName = "Cleveland.txt";
                string path = Path.Combine(Environment.CurrentDirectory, @"NFLReportsApp\", fileName);
                using (var sr = new StreamReader(path))
                {
                    
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        internal object SearchFiles(object searchText)
        {
            throw new NotImplementedException();
        }
    }
}