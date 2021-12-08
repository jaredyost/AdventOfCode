using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day3
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 3 --");

            /* Get the input */
            List<string> input = File.ReadAllLines(Path.Combine("y2021", "Day3", "input.txt")).ToList();

            /* Calculate the oxygen generator rating */
            List<string> remainingValues = new List<string>(input);
            for(int i = 0; i < input[0].Length && remainingValues.Count() > 1; i++)
            {
                int zeroCount = remainingValues.Select(x => x[i]).Where(x => x == '0').Count();
                int oneCount = remainingValues.Select(x => x[i]).Where(x => x == '1').Count();

                remainingValues = remainingValues.Where(x =>x[i] == (zeroCount > oneCount ? '0' : '1')).ToList();
            }

            uint oxygenGeneratorRating = Convert.ToUInt32(remainingValues.First(), 2);

            /* Calculate the CO2 scrubber rating */
            remainingValues = new List<string>(input);
            for(int i = 0; i < input[0].Length && remainingValues.Count() > 1; i++)
            {
                int zeroCount = remainingValues.Select(x => x[i]).Where(x => x == '0').Count();
                int oneCount = remainingValues.Select(x => x[i]).Where(x => x == '1').Count();

                remainingValues = remainingValues.Where(x =>x[i] == (zeroCount <= oneCount ? '0' : '1')).ToList();
            }

            uint co2ScrubberRating = Convert.ToUInt32(remainingValues.First(), 2);

            /* Report the solution */
            Console.WriteLine($"Solution: { oxygenGeneratorRating * co2ScrubberRating }");
        }
    }
}
