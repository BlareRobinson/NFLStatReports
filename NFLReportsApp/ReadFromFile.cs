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
                // Open the text file using a stream reader.
                string fileName = "Cleveland.txt";
                string path = Path.Combine(Environment.CurrentDirectory, @"NFLReportsApp\", fileName);
                using (var sr = new StreamReader("path"))
                {
                    // Read the stream as a string, and write the string to the console.
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