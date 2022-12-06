using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day6
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 6 --");

            /* Get the input */
            string input = File.ReadLines(Path.Combine("y2022", "Day6", "input.txt")).ToArray()[0];

            /* Determine where we have unique characters */
            int countNeeded = -1;
            for(int i = 13; i < input.Count(); i++)
            {
                bool duplicate = false;
                char[] subString = input.Substring(i - 13, 14).ToCharArray();
                for(int j = 0; j < subString.Count() && !duplicate; j++)
                {
                    for(int k = j + 1; k < subString.Count() && !duplicate; k++)
                    {
                        duplicate = subString[j] == subString[k];
                    }
                }

                if(!duplicate)
                {
                    countNeeded = i + 1;
                    break;
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { countNeeded }");
        }
    }
}
