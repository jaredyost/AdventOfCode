using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day2
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 2 --");

            /* Get the input line-by-line and keep a running total */
            int score = 0;
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day2", "input.txt"));
            foreach(string line in fileLines)
            {
                int roundScore = 0;

                IEnumerable<string> moves = line.Trim().Split(' ').ToArray();

                /* Figure out the score from my loss/tie/win */
                switch(moves.ElementAt(1)[0])
                {
                    case 'X':
                        roundScore = 0;
                        break;

                    case 'Y':
                        roundScore = 3;
                        break;

                    case 'Z':
                        roundScore = 6;
                        break;

                    default:
                        break;
                }

                /* Figure out the score from my move */
                roundScore += ScoreMove(moves.ElementAt(0)[0], moves.ElementAt(1)[0]);

                score += roundScore;
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { score }");
        }

        private int ScoreMove(char opponentMove, char result)
        {
            switch(opponentMove)
            {
                case 'A':
                    switch(result)
                    {
                        case 'X':
                            return 3;

                        case 'Y':
                            return 1;

                        case 'Z':
                            return 2;

                        default:
                            return 0;
                    }

                case 'B':
                    switch(result)
                    {
                        case 'X':
                            return 1;

                        case 'Y':
                            return 2;

                        case 'Z':
                            return 3;

                        default:
                            return 0;
                    }

                case 'C':
                    switch(result)
                    {
                        case 'X':
                            return 3;

                        case 'Y':
                            return 1;

                        case 'Z':
                            return 2;

                        default:
                            return 0;
                    }

                default:
                    return 0;
            }
        }
    }
}
