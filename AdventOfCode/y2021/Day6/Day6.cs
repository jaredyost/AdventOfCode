using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day6
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 6 --");

            /* Get the input */
            List<int> input = File.ReadAllLines(Path.Combine("y2021", "Day6", "input.txt"))
                .SelectMany(x => x.Split(',')).Where(x => !String.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();

            /* Model the fish reproduction */
            long[] fishLifeCycle = new long[10];
            for(int i = 0; i < fishLifeCycle.Count(); i++)
            {
                fishLifeCycle[i] = input.Where(x => x == i).LongCount();
            }

            for(int i = 0; i < 256; i++)
            {
                fishLifeCycle[9] = fishLifeCycle[0];
                fishLifeCycle[7] += fishLifeCycle[0];

                for(int j = 0; j < fishLifeCycle.Count() - 1; j++)
                {
                    fishLifeCycle[j] = fishLifeCycle[j + 1];
                }

                fishLifeCycle[9] = 0;
            }

            /* Report the solution */
            Console.Write($"Solution: { fishLifeCycle.Sum() }");
        }
    }
}
