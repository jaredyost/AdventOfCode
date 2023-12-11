using AdventOfCode.Core;
using System.Collections.Generic;

namespace AdventOfCode.Solvers.y2023
{
    public class Day03 : SolverBase
    {
        public Day03() : base(new DateOnly(2023, 12, 03)) { }

        public override string SolvePart1(string[] aInput)
        {
            int sum = 0;
            char[][] engineMap = CreateEngineMap(aInput);
            for (int row = 0; row < engineMap.Length; row++)
            {
                for (int column = 0; column < engineMap[row].Length; column++)
                {
                    if (!char.IsLetterOrDigit(engineMap[row][column]) && engineMap[row][column] != '.')
                    {
                        // Check the rows above and below this symbol
                        for (int testRow = -1; testRow <= 1; testRow++)
                        {
                            // Check the columns to the left and right of this symbol
                            for (int testColumn = -1; testColumn <= 1; testColumn++)
                            {
                                if (char.IsNumber(engineMap[row + testRow][column + testColumn]))
                                {
                                    // We found a number, now find the start of it
                                    do
                                    {
                                        testColumn--;
                                    } while ((column + testColumn) >= 0 && char.IsNumber(engineMap[row + testRow][column + testColumn]));
                                    testColumn++;

                                    // Create the number
                                    string number = "";
                                    do
                                    {
                                        number += engineMap[row + testRow][column + testColumn];
                                        testColumn++;
                                    } while ((column + testColumn) < engineMap[row].Length && char.IsNumber(engineMap[row + testRow][column + testColumn]));
                                    sum += int.Parse(number);
                                }
                            }
                        }
                    }
                }
            }

            return sum.ToString();
        }

        public override string SolvePart2(string[] aInput)
        {
            int sum = 0;
            char[][] engineMap = CreateEngineMap(aInput);
            for (int row = 0; row < engineMap.Length; row++)
            {
                for (int column = 0; column < engineMap[row].Length; column++)
                {
                    if (engineMap[row][column] == '*')
                    {
                        List<int> numbers = [];
                        // Check the rows above and below this symbol
                        for (int testRow = -1; testRow <= 1; testRow++)
                        {
                            // Check the columns to the left and right of this symbol
                            for (int testColumn = -1; testColumn <= 1; testColumn++)
                            {
                                if (char.IsNumber(engineMap[row + testRow][column + testColumn]))
                                {
                                    // We found a number, now find the start of it
                                    do
                                    {
                                        testColumn--;
                                    } while ((column + testColumn) >= 0 && char.IsNumber(engineMap[row + testRow][column + testColumn]));
                                    testColumn++;

                                    // Create the number
                                    string number = "";
                                    do
                                    {
                                        number += engineMap[row + testRow][column + testColumn];
                                        testColumn++;
                                    } while ((column + testColumn) < engineMap[row].Length && char.IsNumber(engineMap[row + testRow][column + testColumn]));
                                    numbers.Add(int.Parse(number));
                                }
                            }
                        }

                        if (numbers.Count == 2)
                        {
                            sum += numbers[0] * numbers[1];
                        }
                    }
                }
            }

            return sum.ToString();
        }

        private static char[][] CreateEngineMap(string[] aInput)
        {
            // Create a map from the input with a buffer row/column on all sides
            List<char[]> engineMap = [];

            char[] topBottomRow = new string('.', aInput[0].Length + 2).ToCharArray();
            engineMap.Add(topBottomRow);
            engineMap.AddRange(aInput.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => new string("." + x + ".").ToCharArray()));
            engineMap.Add(topBottomRow);

            return [.. engineMap];
        }
    }
}
