using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day4
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 4 --");

            /* Get the input */
            List<int> inputNumbers = new List<int>();
            List<int[][]> inputCards = new List<int[][]>();

            int currentRow = 0;
            int[][] tempCard = new int[5][];
            foreach(string line in File.ReadLines(Path.Combine("y2021", "Day4", "input.txt")))
            {
                if(!String.IsNullOrWhiteSpace(line))
                {
                    if(!inputNumbers.Any())
                    {
                        /* Get the selected numbers */
                        inputNumbers = line.Split(',').Select(int.Parse).ToList();
                    }
                    else
                    {
                        /* Get the bingo cards */
                        tempCard[currentRow] = line.Split().Where(x => !String.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();
                        currentRow++;

                        if(currentRow == tempCard.Length)
                        {
                            inputCards.Add((int[][])(tempCard.Clone()));
                            tempCard = new int[5][];
                            currentRow = 0;
                        }
                    }
                }
            }

            /* Find the last card to get a bingo */
            int[] calledNumbers = null, cardNumbers = null;
            for(int i = 5; i <= inputNumbers.Count(); i++)
            {
                for(int j = 0; j < inputCards.Count(); j++)
                {
                    bool bingo = false;
                    int[][] card = inputCards[j];

                    /* Check the rows for a bingo */
                    for(int r = 0; r < card.Count() && bingo == false; r++)
                    {
                        bool validRow = true;
                        for(int c = 0; c < card[r].Count() && validRow == true; c++)
                        {
                            if(!inputNumbers.GetRange(0, i).Contains(card[r][c]))
                            {
                                validRow = false;
                                break;
                            }
                        }

                        if(validRow)
                        {
                            bingo = true;
                            break;
                        }
                    }

                    /* Check the columns for a bingo */
                    for(int c = 0; c < card[0].Count() && bingo == false; c++)
                    {
                        bool validColumn = true;
                        for(int r = 0; r < card.Count() && validColumn == true; r++)
                        {
                            if(!inputNumbers.GetRange(0, i).Contains(card[r][c]))
                            {
                                validColumn = false;
                                break;
                            }
                        }

                        if(validColumn)
                        {
                            bingo = true;
                            break;
                        }
                    }

                    /* Save the stats if this is a bingo */
                    if(bingo)
                    {
                        calledNumbers = inputNumbers.GetRange(0, i).ToArray();
                        cardNumbers = inputCards[j].SelectMany(x => x).ToArray();

                        inputCards.RemoveAt(j);
                        j--;
                    }
                }
            }

            /* Calculate the score of the card */
            for(int k = 0; k < calledNumbers.Count(); k++)
            {
                cardNumbers = cardNumbers.Where(x => x != calledNumbers[k]).ToArray();
            }

            int score = cardNumbers.Sum() * calledNumbers[calledNumbers.Count() - 1];

            /* Report the solution */
            Console.Write($"Solution: { score }");
        }
    }
}
