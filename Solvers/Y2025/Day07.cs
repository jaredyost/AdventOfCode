using AdventOfCode.Core.Helpers.Mapping;

namespace AdventOfCode.Solvers.Y2025
{
    public class Day07 : BaseDay2025
    {
        protected override int Day => 7;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int splits = 0;
            Map<char> map = Map<char>.GetCharacterMap(aInput);
            map.IterateColumnsRows(
                coordinate =>
                {
                    Coordinate below = new(coordinate.X, coordinate.Y + 1);
                    if (map.IsValidCoordinate(below))
                    {
                        switch (map[below])
                        {
                            case '.':
                            case '|':
                                map[below] = '|';
                                break;

                            case '^':
                                bool split = false;

                                Coordinate belowLeft = new(below.X - 1, below.Y);
                                if (map.IsValidCoordinate(belowLeft) && map[belowLeft] != '|')
                                {
                                    map[belowLeft] = '|';
                                    split = true;
                                }

                                Coordinate belowRight = new(below.X + 1, below.Y);
                                if (map.IsValidCoordinate(belowRight) && map[belowRight] != '|')
                                {
                                    map[belowRight] = '|';
                                    split = true;
                                }

                                splits += split ? 1 : 0;
                                break;

                            default:
                                throw new ArgumentException(
                                    nameof(map),
                                    $"Unexpected character: {map[below]}"
                                );
                        }
                    }
                },
                coordinate => map[coordinate] == 'S' || map[coordinate] == '|'
            );

            return new(splits.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            Map<char> map = Map<char>.GetCharacterMap(aInput);
            Dictionary<Coordinate, ulong> cache = [];
            return new(GetNumTimelines(map, map.Find('S')!, ref cache).ToString());
        }

        private static ulong GetNumTimelines(
            Map<char> aMap,
            Coordinate aStartingCoordinate,
            ref Dictionary<Coordinate, ulong> aCache
        )
        {
            Coordinate nextCoordinate = new(aStartingCoordinate.X, aStartingCoordinate.Y + 1);
            while (aMap.IsValidCoordinate(nextCoordinate))
            {
                if (aMap[nextCoordinate] == '^')
                {
                    if (aCache.TryGetValue(nextCoordinate, out ulong timelines))
                    {
                        return timelines;
                    }
                    else
                    {
                        ulong newTimelines =
                            GetNumTimelines(
                                aMap,
                                new(nextCoordinate.X - 1, nextCoordinate.Y),
                                ref aCache
                            )
                            + GetNumTimelines(
                                aMap,
                                new(nextCoordinate.X + 1, nextCoordinate.Y),
                                ref aCache
                            );
                        aCache.Add(nextCoordinate, newTimelines);
                        return newTimelines;
                    }
                }

                nextCoordinate.Y++;
            }

            return 1;
        }
    }
}
