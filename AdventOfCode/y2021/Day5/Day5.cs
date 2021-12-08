using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day5
    {
        public void Run()
        {
            Console.WriteLine("-- 2021: Day 5 --");

            /* Get the input */
            List<LineSegment> input = new List<LineSegment>();
            foreach(string line in File.ReadLines(Path.Combine("y2021", "Day5", "input.txt")))
            {
                int[] currentLine = line.Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries)
                                        .Where(x => !String.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();

                input.Add(new LineSegment(currentLine[0], currentLine[1], currentLine[2], currentLine[3]));
            }

            /* Create a map */
            int maxWidth = maxval(input.Max(x => x.X1), input.Max(x => x.X2)) + 1;
            int maxHeight = maxval(input.Max(x => x.Y1), input.Max(x => x.Y2)) + 1;
            int[,] map = new int[maxWidth, maxHeight];

            /* Add the line segments into the map */
            foreach(LineSegment segment in input)
            {
                int x = segment.X1, y = segment.Y1;
                for(int i = 0, j = 0; i <= segment.XLength || j <= segment.YLength; i++, j++ )
                {
                    map[x,y]++;

                    if(segment.Run != 0)
                    {
                        x += segment.Run / Math.Abs(segment.Run);
                    }

                    if(segment.Rise != 0)
                    {
                        y += segment.Rise / Math.Abs(segment.Rise);
                    }
                }
            }

            /* Count the number of overlapping points */
            int numOverlaps = 0;
            for(int i = 0; i < maxWidth; i++)
            {
                for(int j = 0; j < maxHeight; j++)
                {
                    if(map[i, j] > 1)
                    {
                        numOverlaps++;
                    }
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { numOverlaps }");
        }

        private class LineSegment
        {
            public readonly int X1; public readonly int Y1;
            public readonly int X2; public readonly int Y2;
            public readonly int Rise; public readonly int Run;
            public readonly int XLength; public readonly int YLength;

            public LineSegment(int x1, int y1, int x2, int y2)
            {
                this.X1 = x1; this.Y1 = y1;
                this.X2 = x2; this.Y2 = y2;


                this.Rise = y2 - y1; this.Run = x2 - x1;
                this.XLength = Math.Abs(maxval(this.X1, this.X2) - minval(this.X1, this.X2));
                this.YLength = Math.Abs(maxval(this.Y1, this.Y2) - minval(this.Y1, this.Y2));
            }
        }

        private static int maxval(int val1, int val2)
        {
            return val1 >= val2 ? val1 : val2;
        }

        private static int minval(int val1, int val2)
        {
            return val1 >= val2 ? val2 : val1;
        }
    }
}
