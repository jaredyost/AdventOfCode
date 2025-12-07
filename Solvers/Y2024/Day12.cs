using AdventOfCode.Core.Helpers.Mapping;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day12 : BaseDay2024
    {
        protected override int Day => 12;

        private struct PlotInfo(char aPlant)
        {
            public char Plant = aPlant;
            public int Area = 0;
            public int Perimeter = 0;
            public int Sides = 0;
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(GetPlotInfo(aInput).Sum(x => x.Perimeter * x.Area).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(GetPlotInfo(aInput).Sum(x => x.Sides * x.Area).ToString());
        }

        private static PlotInfo[] GetPlotInfo(string[] aGarden)
        {
            Map<char> garden = Map<char>.GetCharacterMap(aGarden);

            List<PlotInfo> plots = [];
            List<Coordinate> visited = [];
            garden.IterateColumnsRows(
                plot =>
                {
                    PlotInfo plotInfo = new(garden[plot]);
                    List<Coordinate> spots = [];
                    Queue<Coordinate> queue = new(new Coordinate[] { plot });
                    while (queue.TryDequeue(out Coordinate? location))
                    {
                        plotInfo.Area++;
                        spots.Add(location);

                        foreach (
                            Coordinate neighbor in Coordinate
                                .GetCrossNeighbors(location)
                                .Where(x => !queue.Contains(x))
                        )
                        {
                            if (
                                !garden.IsValidCoordinate(neighbor)
                                || garden[neighbor] != plotInfo.Plant
                            )
                            {
                                plotInfo.Perimeter++;
                                continue;
                            }

                            if (!spots.Contains(neighbor))
                            {
                                queue.Enqueue(neighbor);
                            }
                        }
                    }

                    foreach (Coordinate spot in spots)
                    {
                        // Top
                        if (
                            !spots.Contains(new(spot.X, spot.Y - 1))
                            && (
                                !spots.Contains(new(spot.X - 1, spot.Y))
                                || spots.Contains(new(spot.X - 1, spot.Y - 1))
                            )
                        )
                        {
                            plotInfo.Sides++;
                        }

                        // Right
                        if (
                            !spots.Contains(new(spot.X + 1, spot.Y))
                            && (
                                !spots.Contains(new(spot.X, spot.Y - 1))
                                || spots.Contains(new(spot.X + 1, spot.Y - 1))
                            )
                        )
                        {
                            plotInfo.Sides++;
                        }

                        // Bottom
                        if (
                            !spots.Contains(new(spot.X, spot.Y + 1))
                            && (
                                !spots.Contains(new(spot.X - 1, spot.Y))
                                || spots.Contains(new(spot.X - 1, spot.Y + 1))
                            )
                        )
                        {
                            plotInfo.Sides++;
                        }

                        // Left
                        if (
                            !spots.Contains(new(spot.X - 1, spot.Y))
                            && (
                                !spots.Contains(new(spot.X, spot.Y - 1))
                                || spots.Contains(new(spot.X - 1, spot.Y - 1))
                            )
                        )
                        {
                            plotInfo.Sides++;
                        }
                    }

                    plots.Add(plotInfo);
                    visited = [.. visited.Concat(spots)];
                },
                plot => !visited.Contains(plot)
            );

            return [.. plots];
        }
    }
}
