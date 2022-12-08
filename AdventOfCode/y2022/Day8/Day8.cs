using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day8
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 8 --");

            /* Get the input and create the forest */
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day8", "input.txt"));

            int[,] forest = new int[fileLines.Count(), fileLines.ElementAt(0).Count()];
            for(int i = 0; i < fileLines.Count(); i++)
            {
                for(int j = 0; j < fileLines.ElementAt(i).Count(); j++)
                {
                    forest[i,j] = int.Parse(fileLines.ElementAt(i).ElementAt(j).ToString());
                }
            }

            int[,] scenicScores = new int[forest.GetLength(0), forest.GetLength(1)];
            for(int i = 0; i < scenicScores.GetLength(0); i++)
            {
                for(int j = 0; j < scenicScores.GetLength(1); j++)
                {
                    scenicScores[i, j] = 0;
                }
            }

            /* Determine viewing distance */
            for(int i = 0; i < forest.GetLength(0); i++)
            {
                for(int j = 0; j < forest.GetLength(1); j++)
                {
                    /* Check above the tree */
                    int aboveDistance = 0;
                    for(int k = i - 1; k >= 0; k--)
                    {
                        aboveDistance++;
                        if(forest[k, j] >= forest[i, j])
                        {
                            break;
                        }
                    }

                    /* Check below the tree */
                    int belowDistance = 0;
                    for(int k = i + 1; k < forest.GetLength(0); k++)
                    {
                        belowDistance++;
                        if(forest[k, j] >= forest[i, j])
                        {
                            break;
                        }
                    }

                    /* Check to the right of the tree */
                    int rightDistance = 0;
                    for(int k = j + 1; k < forest.GetLength(1); k++)
                    {
                        rightDistance++;
                        if(forest[i, k] >= forest[i, j])
                        {
                            break;
                        }
                    }

                    /* Check to the left of the tree */
                    int leftDistance = 0;
                    for(int k = j - 1; k >= 0; k--)
                    {
                        leftDistance++;
                        if(forest[i, k] >= forest[i, j])
                        {
                            break;
                        }
                    }

                    scenicScores[i, j] = aboveDistance * belowDistance * rightDistance * leftDistance;
                }
            }

            /* Count how many trees are visible */
            int maxScenicScore = 0;
            for(int i = 0; i < scenicScores.GetLength(0); i++)
            {
                for(int j = 0; j < scenicScores.GetLength(1); j++)
                {
                    maxScenicScore = Math.Max(maxScenicScore, scenicScores[i, j]);
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { maxScenicScore }");
        }
    }
}
