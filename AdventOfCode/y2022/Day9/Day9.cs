using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day9
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 9 --");

            /* Get the input */
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day9", "input.txt"));

            List<Tuple<char, int>> headMovement = new List<Tuple<char, int>>();
            foreach(string line in fileLines)
            {
                string[] lineSplit = line.Split();
                headMovement.Add(new Tuple<char, int>(lineSplit[0][0], int.Parse(lineSplit[1])));
            }

            /* Simulate the movement */
            Rope rope = new Rope();
            foreach(Tuple<char, int> movement in headMovement)
            {
                /* Move the head */
                for(int i = 0; i < movement.Item2; i++)
                {
                    int deltaX = 0;
                    int deltaY = 0;
                    switch(movement.Item1)
                    {
                        case 'U':
                            deltaY++;
                            break;

                        case 'R':
                            deltaX++;
                            break;

                        case 'D':
                            deltaY--;
                            break;

                        case 'L':
                            deltaX--;
                            break;

                        default:
                            continue;
                    }

                    rope.MoveHead(deltaX, deltaY);
                }
            }

            /* Report the solution */
            int uniqueLocations = rope.TailHistory.Distinct().Count();
            Console.WriteLine($"Solution: { uniqueLocations }");
        }

        private class Rope
        {
            public class Coordinate
            {
                public int X { get; set; }
                public int Y { get; set; }

                public Coordinate()
                {
                    X = 0;
                    Y = 0;
                }

                public Coordinate(int X, int Y)
                {
                    this.X = X;
                    this.Y = Y;
                }

                public Coordinate(Coordinate Coordinate)
                {
                    X = Coordinate.X;
                    Y = Coordinate.Y;
                }

                public override bool Equals(object obj)
                {
                    if(obj != null && GetType().Equals(obj.GetType()))
                    {
                        Coordinate coordinate = (Coordinate)obj;
                        return X == coordinate.X && Y == coordinate.Y;
                    }

                    return false;
                }

                public override int GetHashCode()
                {
                    return Tuple.Create(X, Y).GetHashCode();
                }
            }

            public List<Coordinate> Knots { get; private set; } = new List<Coordinate>();
            public List<Coordinate> TailHistory { get; private set; } = new List<Coordinate>();

            public Rope()
            {
                for(int i = 0; i < 10; i++)
                {
                    Knots.Add(new Coordinate());
                }

                TailHistory.Add(new Coordinate());
            }

            public void MoveHead(int DeltaX, int DeltaY)
            {
                Knots[0].X += DeltaX;
                Knots[0].Y += DeltaY;

                for(int i = 1; i < Knots.Count(); i++)
                {
                    Coordinate previousKnot = Knots[i - 1];
                    Coordinate currentKnot = Knots[i];

                    bool movementRequired = true;
                    for(int currentX = previousKnot.X - 1; currentX <= previousKnot.X + 1 && movementRequired; currentX++)
                    {
                        for(int currentY = previousKnot.Y - 1; currentY <= previousKnot.Y + 1 && movementRequired; currentY++)
                        {
                            if(currentX == currentKnot.X && currentY == currentKnot.Y)
                            {
                                movementRequired = false;
                            }
                        }
                    }

                    if(movementRequired)
                    {
                        int deltaX = 0;
                        bool sameColumn = previousKnot.X == currentKnot.X;
                        if(!sameColumn)
                        {
                            deltaX = (previousKnot.X >= currentKnot.X) ? (previousKnot.X - currentKnot.X - 1) : -(currentKnot.X - previousKnot.X - 1);
                        }

                        int deltaY = 0;
                        bool sameRow = previousKnot.Y == currentKnot.Y;
                        if(!sameRow)
                        {
                            deltaY = (previousKnot.Y >= currentKnot.Y) ? (previousKnot.Y - currentKnot.Y - 1) : -(currentKnot.Y - previousKnot.Y - 1);
                        }

                        if(!sameColumn && !sameRow)
                        {
                            if(deltaX == 0)
                            {
                                deltaX = (previousKnot.X >= currentKnot.X) ? 1 : -1;
                            }

                            if(deltaY == 0)
                            {
                                deltaY = (previousKnot.Y >= currentKnot.Y) ? 1 : -1;
                            }
                        }

                        Knots[i].X += deltaX;
                        Knots[i].Y += deltaY;
                    }
                }

                TailHistory.Add(new Coordinate(Knots[Knots.Count() - 1]));
            }
        }
    }
}
