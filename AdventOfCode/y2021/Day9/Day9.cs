using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day9
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 9 --");

            /* Get the input */
            List<int[]> input = new List<int[]>();
            foreach(string line in File.ReadLines(Path.Combine("y2021", "Day9", "input.txt")))
            {
                int[] convertedLine = new int[line.Length];
                for(int i = 0; i < convertedLine.Length; i++)
                {
                    convertedLine[i] = int.Parse(line[i].ToString());
                }

                input.Add(convertedLine);
            }

            /* Loop through the map and determine the lowest points */
            for(int i = 0; i < input.Count(); i++)
            {
                for(int j = 0; j < input[i].Count(); j++)
                {
                    bool invalidate = false;

                    /* Above */
                    if(i != 0 && input[i - 1][j] <= input[i][j])
                    {
                        invalidate = invalidate || true;
                    }

                    /* Below */
                    if(i != input.Count() - 1 && input[i + 1][j] <= input[i][j])
                    {
                        invalidate = invalidate || true;
                    }

                    /* Left */
                    if(j != 0 && input[i][j - 1] <= input[i][j])
                    {
                        invalidate = invalidate || true;
                    }

                    /* Right */
                    if(j != input[i].Count() - 1 && input[i][j + 1] <= input[i][j])
                    {
                        invalidate = invalidate || true;
                    }

                    if(invalidate)
                    {
                        input[i][j] = int.MaxValue;
                    }
                }
            }

            /* Calculate the risk score */
            int riskLevel = 0;
            for(int i = 0; i < input.Count(); i++)
            {
                for(int j = 0; j < input[i].Count(); j++)
                {
                    if(input[i][j] != int.MaxValue)
                    {
                        riskLevel += input[i][j] + 1;
                    }
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { riskLevel }");
        }
    }
}
