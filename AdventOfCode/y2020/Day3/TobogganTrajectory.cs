using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2020
{
    public class TobogganTrajectory
    {
        /// <summary>
        /// Error Codes associated with Toboggan Trajectory
        /// </summary>
        public enum ErrorCodes : int
        {
            INVALID_RESULT  = -1,
        }

        /// <summary>
        /// Find the number of trees that would encountered when travelling at a particular slope
        /// </summary>
        /// <returns>The number of trees encountered</returns>
        public int CalculateTreeEncounterSinglePath()
        {
            /* Read in the map */
            List<string> inputMap = File.ReadAllLines(Path.Combine("y2020", "Day3", "input.txt")).ToList();

            /* Iterate over the map and calculate how many trees we would hit */
            int result = 0;
            for(int currentX = 0, currentY = 0; currentY < inputMap.Count(); currentX += 3, currentY++)
            {
                int adjustedX = currentX % inputMap[currentY].Length;

                if(inputMap[currentY][adjustedX] == '#')
                {
                    result++;
                }
            }

            /* Return the result */
            return result;
        }

        /// <summary>
        /// Find the number of trees that would encountered when travelling at varying slopes
        /// </summary>
        /// <returns>The number of trees encountered multiplied together</returns>
        public double CalculateTreeEncounterDynamicPath()
        {
            /* Read in the map */
            List<string> inputMap = File.ReadAllLines(Path.Combine("y2020", "Day3", "input.txt")).ToList();

            List<Tuple<int, int>> slopes = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 1),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(5, 1),
                new Tuple<int, int>(7, 1),
                new Tuple<int, int>(1, 2),
            };

            /* Iterate over the map and calculate how many trees we would hit */
            double result = 0;
            for(int i = 0; i < slopes.Count(); i++)
            {
                double treeCount = 0;
                for (int currentX = 0, currentY = 0; currentY < inputMap.Count(); currentX += slopes[i].Item1, currentY += slopes[i].Item2)
                {
                    int adjustedX = currentX % inputMap[currentY].Length;

                    if(inputMap[currentY][adjustedX] == '#')
                    {
                        treeCount++;
                    }
                }

                /* Account for the new tree count in our product */
                if(result == 0)
                {
                    result = treeCount;
                }
                else
                {
                    result *= treeCount;
                }
            }

            /* Return the result */
            return result;
        }
    }
}
