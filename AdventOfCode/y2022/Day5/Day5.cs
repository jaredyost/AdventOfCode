using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day5
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 5 --");

            /* Get the input line-by-line and read the input */
            List<string> cratesToParse = new List<string>();
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day5", "input.txt"));

            int numStacks = 0;
            List<char[]> stacks = new List<char[]>();
            List<Tuple<int, int, int>> instructions = new List<Tuple<int, int, int>>();

            bool cratesComplete = false;
            foreach(string line in fileLines)
            {
                if(line.Trim() == "")
                {
                    continue;
                }
                else if(!cratesComplete)
                {
                    if(line.Contains('['))
                    {
                        /* Save the row to be read in later */
                        cratesToParse.Insert(0, line);
                    }
                    else
                    {
                        /* Determine how many stacks there are */
                        numStacks = line.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Max();

                        /* Read in all the crates */
                        for(int i = 0; i < cratesToParse.Count(); i++)
                        {
                            stacks.Add(new char[numStacks]);
                            for(int j = 0; j < numStacks; j++)
                            {
                                stacks[stacks.Count() - 1][j] = ' ';
                            }

                            for(int j = 0, k = 1; j < numStacks && k < cratesToParse[i].Count(); j++, k += 4)
                            {
                                stacks[i][j] = cratesToParse[i][k];
                            }
                        }

                        cratesComplete = true;
                    }
                }
                else
                {
                    /* Read in all the instructions */
                    int movement = -1;
                    int origin = -1;
                    int destination = -1;
                    foreach(string word in line.Split())
                    {
                        int parsedNum = 0;
                        if(int.TryParse(word, out parsedNum))
                        {
                            if(movement == -1)
                            {
                                movement = parsedNum;
                            }
                            else if(origin == -1)
                            {
                                origin = parsedNum - 1;
                            }
                            else if(destination == -1)
                            {
                                destination = parsedNum - 1;
                            }
                        }
                    }

                    instructions.Add(new Tuple<int, int, int>(movement, origin, destination));
                }
            }

            /* Follow the instructions */
            foreach(Tuple<int, int, int> instruction in instructions)
            {
                int oldIdx = -1;
                for(int i = stacks.Count() - 1; i >= 0; i--)
                {
                    if(stacks[i][instruction.Item2] != ' ')
                    {
                        oldIdx = i - (instruction.Item1 - 1);
                        break;
                    }
                }

                int newIdx = -1;
                for(int i = stacks.Count() - 1; i >= 0; i--)
                {
                    if(stacks[i][instruction.Item3] != ' ')
                    {
                        newIdx = i + 1;
                        break;
                    }
                }

                if(newIdx == -1)
                {
                    newIdx = 0;
                }

                for(int i = 0; i < instruction.Item1; i++)
                {
                    if(stacks.Count() <= newIdx || stacks[newIdx][instruction.Item3] != ' ')
                    {
                        stacks.Add(new char[numStacks]);
                        for(int j = 0; j < numStacks; j++)
                        {
                            stacks[stacks.Count() - 1][j] = ' ';
                        }
                    }

                    stacks[newIdx][instruction.Item3] = stacks[oldIdx][instruction.Item2];
                    stacks[oldIdx][instruction.Item2] = ' ';
                    oldIdx++;
                    newIdx++;
                }
            }

            /* Report the solution */
            string top = "";
            for(int i = 0; i < numStacks; i++)
            {
                for(int j = stacks.Count() - 1; j >= 0; j--)
                {
                    if(stacks[j][i] != ' ')
                    {
                        top += stacks[j][i];
                        break;
                    }
                }
            }

            Console.WriteLine($"Solution: { top }");
        }
    }
}
