using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Autopark
{
    class CarParts
    {
        public string[] AutoParts { get; }

        public CarParts(string autoParts)
        {
            AutoParts = LoadAutoParts(autoParts);
        }

        public string[] LoadAutoParts(string inFile)
        {
            List<string> tempList = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(inFile, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(';');
                        tempList.AddRange(fields);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error! File {inFile} not found!");
            }
            string[] tempArray = new string[tempList.Count];
            tempArray = tempList.ToArray();
            return tempArray;
        }
    }
}
