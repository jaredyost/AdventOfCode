using AdventOfCode.Core.Helpers.Types;
using AdventOfCode.Core.Helpers.Types.Mapping;

namespace AdventOfCode.Solvers.Y2025
{
    public class Day09 : BaseDay2025
    {
        protected override int Day => 9;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            Coordinate[] redTiles = GetRedTiles(aInput);
            return new(GetAreas(redTiles).First().Value.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            Coordinate[] redTiles = GetRedTiles(aInput);

            // Utilize coordinate compression to reduce processing time from the large grid
            SortedSet<int> xCoordinates = [];
            SortedSet<int> yCoordinates = [];
            foreach (Coordinate tile in redTiles)
            {
                Coordinate[] coordinates = [tile, .. Coordinate.GetAllNeighbors(tile)];
                foreach (Coordinate coordinate in coordinates)
                {
                    xCoordinates.Add(coordinate.X);
                    yCoordinates.Add(coordinate.Y);
                }
            }

            Dictionary<int, int> xMap = [];
            for (int i = 0; i < xCoordinates.Count; i++)
            {
                xMap[xCoordinates.ElementAt(i)] = i;
            }

            Dictionary<int, int> yMap = [];
            for (int i = 0; i < yCoordinates.Count; i++)
            {
                yMap[yCoordinates.ElementAt(i)] = i;
            }

            Map<char> map = new(xCoordinates.Count + 2, yCoordinates.Count + 2, '.');

            // Add the outline of the red and green tiles
            map.AddOutline(
                [.. redTiles.Select(tile => new Coordinate(xMap[tile.X], yMap[tile.Y]))],
                '#'
            );

            // Flood fill the outside
            map.FloodFill('*', '.');

            // Find the largest areas
            Dictionary<UnorderedPair<Coordinate>, ulong> areas = GetAreas(redTiles);

            // Go through the areas until we find an area that is fully contained
            ulong largestArea = 0;
            foreach (UnorderedPair<Coordinate> area in areas.Keys)
            {
                int leftX = xMap[Math.Min(area.Item1.X, area.Item2.X)];
                int rightX = xMap[Math.Max(area.Item1.X, area.Item2.X)];

                int upperY = yMap[Math.Min(area.Item1.Y, area.Item2.Y)];
                int lowerY = yMap[Math.Max(area.Item1.Y, area.Item2.Y)];

                bool contained = true;
                for (int x = leftX; x <= rightX && contained; x++)
                {
                    for (int y = upperY; y <= lowerY && contained; y++)
                    {
                        if (map[x, y] == '*')
                        {
                            contained = false;
                        }
                    }
                }

                if (contained)
                {
                    largestArea = areas[area];
                    break;
                }
            }

            return new(largestArea.ToString());
        }

        private static Coordinate[] GetRedTiles(string[] aInput)
        {
            return [.. aInput.Select(x => x.Split(',')).Select(x => new Coordinate(x[0], x[1]))];
        }

        private static Dictionary<UnorderedPair<Coordinate>, ulong> GetAreas(Coordinate[] aTiles)
        {
            Dictionary<UnorderedPair<Coordinate>, ulong> areas = [];
            for (int i = 0; i < aTiles.Length; i++)
            {
                for (int j = i + 1; j < aTiles.Length; j++)
                {
                    UnorderedPair<Coordinate> coordinates = new(aTiles[i], aTiles[j]);
                    if (!areas.ContainsKey(coordinates))
                    {
                        int width = Math.Abs(coordinates.Item1.X - coordinates.Item2.X) + 1;
                        int height = Math.Abs(coordinates.Item1.Y - coordinates.Item2.Y) + 1;
                        areas.Add(coordinates, (ulong)width * (ulong)height);
                    }
                }
            }

            return areas.OrderByDescending(x => x.Value).ToDictionary();
        }
    }
}
