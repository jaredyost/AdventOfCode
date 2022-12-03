using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day1
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 1 --");

            /* Get the input line-by-line and keep a running total */
            int elfCount = 0;
            List<int> calorieTotal = new List<int> { 0 };

            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day1", "input.txt"));
            foreach(string line in fileLines)
            {
                if(line.Trim() == "")
                {
                    calorieTotal.Add(0);
                    elfCount++;
                    continue;
                }

                calorieTotal[elfCount] += int.Parse(line);
            }

            /* Find the total calorie count for the top 3 elves */
            int totalCalorieCount = calorieTotal.OrderByDescending(x => x).Take(3).Sum();

            /* Report the solution */
            Console.WriteLine($"Solution: { totalCalorieCount }");
        }
    }
}
