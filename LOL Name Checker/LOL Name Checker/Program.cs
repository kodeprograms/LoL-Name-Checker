using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace LOL_Name_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LOL Name Checker v1");
            Console.WriteLine("By BoysWhoCry");
            Console.WriteLine("Source Found Here: https://github.com/BoysWhoCryPrograms");
            Console.WriteLine("League of legends Icon by Icons8 on Iconscout.com");
            Console.WriteLine("");
            Console.WriteLine("Please make sure 'config.txt' contains the names you'd like to check.");
            Console.WriteLine("Press 'Enter' to start...");
            Console.ReadLine();
            WebClient wc = new WebClient();
            string filePath = "config.txt";
            List<string> nameList = new List<string>();
            List<string> avaliableNames = new List<string>();
            string[] fileContent = System.IO.File.ReadAllLines(filePath);
            nameList.AddRange(fileContent);
            Console.WriteLine("Amount of Names to Check: " + nameList.Count());
            Console.WriteLine("");
            foreach (string a in nameList)
            {
                string webData = wc.DownloadString("https://lolnames.gg/en/na/" + a);
                if (webData.Contains("card bg-success"))
                {
                    Console.WriteLine(a + " is Available");
                    avaliableNames.Add(a);
                }
                else
                {
                    Console.WriteLine(a + " is Not Available");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Done Checking!");
            Console.WriteLine("");
            Console.WriteLine("Writing All Avaliable names to Available.txt");
            using (TextWriter tw = new StreamWriter("Available.txt"))
            {
                foreach (string s in avaliableNames)
                    tw.WriteLine(s);
            }
            Console.WriteLine("Process Complete! " + avaliableNames.Count() + " LOL names were saved to Available.txt");
            Console.WriteLine("Press Enter to Exit");
            Console.ReadKey();
        }
    }
}
