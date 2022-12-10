using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day10
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 10 --");

            /* Get the input */
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day10", "input.txt"));

            List<Tuple<string, int>> instructions = new List<Tuple<string, int>>();
            foreach(string line in fileLines)
            {
                List<string> lineSplit = line.Split().ToList();
                lineSplit.Add("0");
                instructions.Add(new Tuple<string, int>(lineSplit[0], int.Parse(lineSplit[1])));
            }

            /* Run the instructions */
            int x = 1;
            string crt = "\n";

            int cycle = 1;
            foreach(Tuple<string, int> instruction in instructions)
            {
                bool inCycle = true;

                runCycle:
                if(cycle % 40 == 1)
                {
                    crt += "\n";
                }

                bool spriteVisible = false;
                for(int i = x - 1; i <= x + 1 && !spriteVisible; i++)
                {
                    if(i == ((cycle - 1) % 40))
                    {
                        crt += "#";
                        spriteVisible = true;
                    }
                }

                if(!spriteVisible)
                {
                    crt += ".";
                }

                switch(instruction.Item1)
                {
                    case "noop":
                        cycle++;
                        inCycle = false;
                        break;

                    case "addx":
                        cycle++;
                        if(inCycle)
                        {
                            inCycle = false;
                            goto runCycle;
                        }

                        x += instruction.Item2;
                        break;

                    default:
                        continue;
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { crt }");
        }
    }
}
