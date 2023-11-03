using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SoccerLeagueTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"football.dat");

            List<Goals> goalList = new List<Goals>();
            string[] files = File.ReadAllLines(path);

            for (int m = 1; m < files.Length; m++)
            {
                string[] row = files[m].Replace("-","").Trim().Split(' ');
                row = row.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                if (row.Length != 0)
                {
                    goalList.Add(new Goals()
                    {
                        team = row[1],
                        goalsFor = Convert.ToInt16(row[6]),
                        goalsAgainst = Convert.ToInt16(row[7]),
                        difference = Convert.ToInt16(row[6]) - Convert.ToInt16(row[7])
                    });
                }
            }

            var result = goalList.OrderBy(a => a.difference);

            var smallestDiff = result.Select(x => x.team).First();

            Console.WriteLine(smallestDiff + " had the smallest difference in for and against goals");
            Console.ReadKey();
        }
    }
}
