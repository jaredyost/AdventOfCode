using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day1
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 1 --");

            /* Get the input */
            List<int> input = File.ReadAllLines(Path.Combine("y2021", "Day1", "input.txt"))
                .Select(int.Parse).ToList();

            /* Count how many times the depth increases in a 3-measurement window */
            int numDepthIncreases = 0;
            for(int i = 0; i < input.Count() - 3; i++)
            {
                int window1 = input[i] + input[i + 1] + input[i + 2];
                int window2 = input[i + 1] + input[i + 2] + input[i + 3];
                if(window2 > window1)
                {
                    numDepthIncreases++;
                }
            }

            /* Report the solution */
            Console.Write($"Solution: { numDepthIncreases }");
        }
    }
}
