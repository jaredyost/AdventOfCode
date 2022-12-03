using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day3
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 3 --");

            /* Get the input line-by-line and calculate the sum of the priorities */
            int prioritySum = 0;
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day3", "input.txt"));
            for(int i = 0; i < fileLines.Count(); i += 3)
            {
                foreach(char item in fileLines.ElementAt(i))
                {
                    if(fileLines.ElementAt(i + 1).Contains(item) && fileLines.ElementAt(i + 2).Contains(item))
                    {
                        if(char.IsUpper(item))
                        {
                            prioritySum += (item % 'A') + 27;
                        }
                        else
                        {
                            prioritySum += (item % 'a') + 1;
                        }
                        break;
                    }
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { prioritySum }");
            Console.ReadKey();
        }
    }
}
