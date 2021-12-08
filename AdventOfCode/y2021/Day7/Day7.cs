using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day7
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 7 --");

            /* Get the input */
            List<int> input = File.ReadAllLines(Path.Combine("y2021", "Day7", "input.txt"))
                .SelectMany(x => x.Split(',')).Where(x => !String.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();

            /* Find the minimum fuel needed */
            int minFuel = int.MaxValue;
            for(int proposedPosition = input.Min(); proposedPosition <= input.Max(); proposedPosition++)
            {
                int currentFuel = 0;
                foreach(int currentPosition in input.Where(x => x != proposedPosition).Distinct())
                {
                    int tempFuel = 0;
                    bool moreExpensive = false;
                    for(int i = 1; i <= Math.Abs(proposedPosition - currentPosition); i++)
                    {
                        tempFuel += i;
                        if(tempFuel >= minFuel)
                        {
                            moreExpensive = true;
                            break;
                        }
                    }

                    currentFuel += tempFuel * input.Where(x => x == currentPosition).Count();
                    if(moreExpensive || currentFuel >= minFuel)
                    {
                        break;
                    }
                }

                if(currentFuel < minFuel)
                {
                    minFuel = currentFuel;
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { minFuel }");
        }
    }
}
