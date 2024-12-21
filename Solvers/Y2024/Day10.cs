using AdventOfCode.Core.Helpers.Mapping;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day10 : BaseDay2024
    {
        protected override int Day => 10;

        private struct TrailInfo()
        {
            public int Summits { get; set; } = 0;
            public int Trails { get; set; } = 0;
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(GetTrailInfo(aInput).Summits.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(GetTrailInfo(aInput).Trails.ToString());
        }

        private static TrailInfo GetTrailInfo(string[] aGrid)
        {
            TrailInfo trailInfo = new();
            Map<char> map = Map<char>.GetCharacterMap(aGrid);
            map.IterateColumnsRows(trailhead =>
            {
                Queue<Coordinate> queue = new(new Coordinate[] { trailhead });
                Dictionary<Coordinate, int> visited = new() { { trailhead, 1 } };
                while (queue.TryDequeue(out Coordinate? location))
                {
                    if (map[location] == '9')
                    {
                        trailInfo.Summits++;
                        trailInfo.Trails += visited[location];
                        continue;
                    }

                    foreach (Coordinate neighbor in Coordinate.GetNeighbors(location))
                    {
                        if (!map.IsValidCoordinate(neighbor) || map[neighbor] - map[location] != 1)
                        {
                            continue;
                        }

                        if (visited.ContainsKey(neighbor))
                        {
                            visited[neighbor] += visited[location];
                            continue;
                        }

                        visited.Add(neighbor, visited[location]);
                        queue.Enqueue(neighbor);
                    }
                }
            }, coordinate => map[coordinate] == '0');

            return trailInfo;
        }
    }
}
