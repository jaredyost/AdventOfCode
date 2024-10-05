using AdventOfCode.Core;
using System.Drawing;

namespace AdventOfCode.Solvers.y2023
{
    public class Day11 : SolverBase
    {
        public Day11() : base(new(2023, 12, 11)) { }

        public override string SolvePart1(string[] aInput)
        {
            return SumShortestPaths(aInput, 2).ToString();
        }

        public override string SolvePart2(string[] aInput)
        {
            return SumShortestPaths(aInput, 1000000).ToString();
        }

        private static string[][] ParseMap(string[] aInput, int aGrowthFactor)
        {
            string[][] map = aInput.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.ToCharArray()).Select(x => x.Select(x => x.ToString()).ToArray()).ToArray();

            // Expand the empty space
            for (int x = 0; x < map[0].Length; x++)
            {
                if (!map.Select(row => row[x]).Where(x => !x.Equals(".") && !x.Equals(aGrowthFactor.ToString())).Any())
                {
                    for (int y = 0; y < map.Length; y++)
                    {
                        map[y][x] = aGrowthFactor.ToString();
                    }
                }
            }

            for (int y = 0; y < map.Length; y++)
            {
                if (!map[y].Where(x => !x.Equals(".") && !x.Equals(aGrowthFactor.ToString())).Any())
                {
                    for (int x = 0; x < map[y].Length; x++)
                    {
                        map[y][x] = map[y][x].Equals(aGrowthFactor.ToString()) ? (2 * aGrowthFactor).ToString() : aGrowthFactor.ToString();
                    }
                }
            }

            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x].Equals("."))
                    {
                        map[y][x] = "1";
                    }
                }
            }

            return [.. map];
        }

        private static ulong SumShortestPaths(string[] aInput, int aGrowthFactor)
        {
            string[][] map = ParseMap(aInput, aGrowthFactor);

            List<Point> galaxies = [];
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    if (map[y][x] == "#")
                    {
                        galaxies.Add(new(x, y));
                        map[y][x] = "1";
                    }
                }
            }

            ulong sum = 0;
            for (int i = 0; i < galaxies.Count - 1; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    int startX = int.Min(galaxies[i].X, galaxies[j].X);
                    int endX = int.Min(galaxies[i].X, galaxies[j].X);

                    int startY = int.Min(galaxies[i].Y, galaxies[j].Y);
                    int endY = int.Min(galaxies[i].Y, galaxies[j].Y);

                    if (galaxies[i].X != galaxies[j].X)
                    {
                        int xScale = galaxies[i].X > galaxies[j].X ? -1 : 1;
                        for (int x = galaxies[i].X + xScale; x != galaxies[j].X; x += xScale)
                        {
                            sum += ulong.Parse(map[startY][x]);
                        }
                        sum += 1u;
                    }

                    if (galaxies[i].Y != galaxies[j].Y)
                    {
                        int yScale = galaxies[i].Y > galaxies[j].Y ? -1 : 1;
                        for (int y = galaxies[i].Y + yScale; y != galaxies[j].Y; y += yScale)
                        {
                            sum += ulong.Parse(map[y][startX]);
                        }
                        sum += 1u;
                    }
                }
            }

            return sum;
        }
    }
}
