using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForInterview;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var csv = new StringBuilder(); //new
            string filePath = @"D:\test.csv"; //new

            String fileData = File.ReadAllText(@"nba.json");
            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(fileData);
            List<Player> filteredPlayers = new List<Player>();

            players = players.OrderByDescending(p => p.rating).ThenBy(p => p.name).ToList();

            Console.WriteLine("Enter maximun number of years");
            string input = Console.ReadLine();
            int maxYears;
            Int32.TryParse(input, out maxYears);

            Console.WriteLine("enter minimun rating");
            input = Console.ReadLine();
            int minRating;
            Int32.TryParse(input, out minRating);

            foreach (Player player in players)
            {
                if (DateTime.Now.Year - player.playerSince > maxYears || player.rating < minRating)
                {
                    continue;
                }

                filteredPlayers.Add(player);
            }
            
            foreach (Player player in filteredPlayers)
            {
               
                Console.WriteLine(player.name);
                Console.WriteLine(player.playerSince);
                Console.WriteLine(player.position);
                Console.WriteLine(player.rating);
                Console.WriteLine("");

                var first = player.name.ToString(); //new
                var second = player.rating.ToString(); //new

                var newLine = string.Format("{0} , {1}", first, second); //new
                csv.AppendLine(newLine); //new
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(filePath);
            Console.ResetColor();

            File.AppendAllText(filePath, csv.ToString()); //new
            Console.ReadLine();
        }
    }
}