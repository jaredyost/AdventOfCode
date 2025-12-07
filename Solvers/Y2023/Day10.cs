using System.Drawing;

namespace AdventOfCode.Solvers.Y2023
{
    public class Day10 : BaseDay2023
    {
        protected override int Day => 10;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(Math.Ceiling(GetPath(ParseMap(aInput)).Count / 2.0).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            char[][] map = ParseMap(aInput);
            List<Point> path = GetPath(map);

            // We need to know the actual pipe type of S for calculations later
            Point start = FindStart(map);
            map[start.Y][start.X] = FindPipeType(map, path, start);

            int enclosedAmount = 0;
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    Point point = new(x, y);
                    if (
                        !path.Contains(point)
                        && CountHorizontalIntersections(map, path, point) % 2 != 0
                        && CountVerticalIntersections(map, path, point) % 2 != 0
                    )
                    {
                        enclosedAmount++;
                    }
                }
            }

            return new(enclosedAmount.ToString());
        }

        private static char[][] ParseMap(string[] aInput)
        {
            // Create a map from the input with a buffer row/column on all sides
            List<char[]> map = [];

            char[] topBottomRow = new string('.', aInput[0].Length + 2).ToCharArray();
            map.Add(topBottomRow);
            map.AddRange(
                aInput.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => $".{x}.".ToCharArray())
            );
            map.Add(topBottomRow);

            return [.. map];
        }

        private static Point FindStart(char[][] aMap)
        {
            for (int y = 0; y < aMap.Length; y++)
            {
                for (int x = 0; x < aMap[y].Length; x++)
                {
                    if (aMap[y][x] == 'S')
                    {
                        return new(x, y);
                    }
                }
            }

            throw new ArgumentException("The provided map does not have a starting position!");
        }

        private static List<Point> FindAdjacents(char[][] aMap, Point aCoordinate)
        {
            List<Point> adjacents = [];
            char currentSymbol = aMap[aCoordinate.Y][aCoordinate.X];

            // Above
            if (
                "S|LJ".Contains(currentSymbol)
                && "|7F".Contains(aMap[aCoordinate.Y - 1][aCoordinate.X])
            )
            {
                adjacents.Add(new(aCoordinate.X, aCoordinate.Y - 1));
            }

            // Below
            if (
                "S|7F".Contains(currentSymbol)
                && "|LJ".Contains(aMap[aCoordinate.Y + 1][aCoordinate.X])
            )
            {
                adjacents.Add(new(aCoordinate.X, aCoordinate.Y + 1));
            }

            // Left
            if (
                "S-7J".Contains(currentSymbol)
                && "-LF".Contains(aMap[aCoordinate.Y][aCoordinate.X - 1])
            )
            {
                adjacents.Add(new(aCoordinate.X - 1, aCoordinate.Y));
            }

            // Right
            if (
                "S-LF".Contains(currentSymbol)
                && "-7J".Contains(aMap[aCoordinate.Y][aCoordinate.X + 1])
            )
            {
                adjacents.Add(new(aCoordinate.X + 1, aCoordinate.Y));
            }

            return adjacents;
        }

        private static List<Point> GetPath(char[][] aMap)
        {
            List<Point> path = [FindStart(aMap)];
            while (true)
            {
                Point? next = FindAdjacents(aMap, path.Last())
                    .FirstOrDefault(x => path.Count < 2 || !x.Equals(path[path.Count - 2]));

                if (next == null || next.Equals(path[0]) || next.Value.IsEmpty)
                {
                    // If the only point was our previous one, we've made a full loop
                    break;
                }

                path.Add(next.Value);
            }

            return path;
        }

        private static char FindPipeType(char[][] aMap, List<Point> aPath, Point aCoordinate)
        {
            List<Point> adjacents = FindAdjacents(aMap, aCoordinate).Where(aPath.Contains).ToList();
            if (adjacents.Count == 2)
            {
                if (adjacents[0].X == adjacents[1].X)
                {
                    return '|';
                }

                if (adjacents[0].Y == adjacents[1].Y)
                {
                    return '-';
                }

                if (adjacents[0].Y < adjacents[1].Y)
                {
                    if (adjacents[0].X > adjacents[1].X)
                    {
                        return 'J';
                    }

                    if (adjacents[0].X < adjacents[1].X)
                    {
                        return 'L';
                    }
                }

                if (adjacents[0].Y > adjacents[1].Y)
                {
                    if (adjacents[0].X > adjacents[1].X)
                    {
                        return '7';
                    }

                    if (adjacents[0].X < adjacents[1].X)
                    {
                        return 'F';
                    }
                }
            }

            throw new ArgumentException("The map/coordinate pair was invalid");
        }

        private static int CountHorizontalIntersections(
            char[][] aMap,
            List<Point> aPath,
            Point aCoordinate
        )
        {
            char? lastBend = null;
            int intersectionCount = 0;
            for (int x = aCoordinate.X - 1; x >= 0; x--)
            {
                if (!aPath.Contains(new(x, aCoordinate.Y)))
                {
                    continue;
                }

                if (aMap[aCoordinate.Y][x] == '|')
                {
                    intersectionCount++;
                    continue;
                }

                if ("LJ7F".Contains(aMap[aCoordinate.Y][x]))
                {
                    if (lastBend == null)
                    {
                        lastBend = aMap[aCoordinate.Y][x];
                        continue;
                    }

                    if ("LJ".Contains(lastBend.Value) && "LJ".Contains(aMap[aCoordinate.Y][x]))
                    {
                        lastBend = null;
                        continue;
                    }

                    if ("7F".Contains(lastBend.Value) && "7F".Contains(aMap[aCoordinate.Y][x]))
                    {
                        lastBend = null;
                        continue;
                    }

                    lastBend = null;
                    intersectionCount++;
                }
            }

            return intersectionCount;
        }

        private static int CountVerticalIntersections(
            char[][] aMap,
            List<Point> aPath,
            Point aCoordinate
        )
        {
            char? lastBend = null;
            int intersectionCount = 0;
            for (int y = aCoordinate.Y - 1; y >= 0; y--)
            {
                if (!aPath.Contains(new(aCoordinate.X, y)))
                {
                    continue;
                }

                if (aMap[y][aCoordinate.X] == '-')
                {
                    intersectionCount++;
                    continue;
                }

                if ("LJ7F".Contains(aMap[y][aCoordinate.X]))
                {
                    if (lastBend == null)
                    {
                        lastBend = aMap[y][aCoordinate.X];
                        continue;
                    }

                    if ("J7".Contains(lastBend.Value) && "J7".Contains(aMap[y][aCoordinate.X]))
                    {
                        lastBend = null;
                        continue;
                    }

                    if ("LF".Contains(lastBend.Value) && "LF".Contains(aMap[y][aCoordinate.X]))
                    {
                        lastBend = null;
                        continue;
                    }

                    lastBend = null;
                    intersectionCount++;
                }
            }

            return intersectionCount;
        }
    }
}
