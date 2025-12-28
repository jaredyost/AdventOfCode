using AdventOfCode.Core.Helpers;
using AdventOfCode.Core.Helpers.Mapping;

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
            // Create the initial (empty) map
            Coordinate[] redTiles = GetRedTiles(aInput);
            Map<char> map = new(
                redTiles.Max(tile => tile.Y) + 2,
                redTiles.Max(tile => tile.X) + 2,
                '.'
            );

            // Add the outline of the red and green tiles
            map.AddOutline(redTiles, '#');

            // Fine the largest areas
            Dictionary<UnorderedPair<Coordinate>, ulong> areas = GetAreas(redTiles);

            // Go through the areas until we find an area that is fully contained
            ulong largestArea = 0;
            foreach (UnorderedPair<Coordinate> area in areas.Keys)
            {
                int leftX = Math.Min(area.Item1.X, area.Item2.X);
                int rightX = Math.Max(area.Item1.X, area.Item2.X);

                int upperY = Math.Min(area.Item1.Y, area.Item2.Y);
                int lowerY = Math.Max(area.Item1.Y, area.Item2.Y);

                Coordinate[] corners =
                [
                    new(leftX, upperY),
                    new(rightX, upperY),
                    new(rightX, lowerY),
                    new(leftX, lowerY),
                ];

                if (corners.Count(tile => map.IsCoordinateOnOrInsideShape(tile, '#')) == 4)
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
