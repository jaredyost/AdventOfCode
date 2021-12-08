using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day2
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 2 --");

            /* Get the input */
            List<Tuple<string, int>> input = File.ReadAllLines(Path.Combine("y2021", "Day2", "input.txt"))
                .Select(x => x.Split(' ')).Select(x => new Tuple<string, int>(x[0], int.Parse(x[1]))).ToList();

            /* Calculate the horizontal and vertical positions */
            int x = 0;
            int y = 0;
            int aim = 0;
            for(int i = 0; i < input.Count(); i++)
            {
                switch(input[i].Item1)
                {
                    case "down":
                        aim += input[i].Item2;
                        break;

                    case "up":
                        aim -= input[i].Item2;
                        break;

                    case "forward":
                        x += input[i].Item2;
                        y += input[i].Item2 * aim;
                        break;

                    default:
                        break;
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { x * y }");
        }
    }
}
