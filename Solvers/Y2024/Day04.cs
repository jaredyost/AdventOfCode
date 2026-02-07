using AdventOfCode.Core.Helpers.Types.Mapping;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day04 : BaseDay2024
    {
        protected override int Day => 4;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int count = 0;
            Map<char> map = Map<char>.GetCharacterMap(aInput);
            map.IterateColumnsRows(coordinate => count += CountXmasOccurrences(map, coordinate));
            return new(count.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int count = 0;
            Map<char> map = Map<char>.GetCharacterMap(aInput);
            map.IterateColumnsRows(coordinate => count += IsValidXMas(map, coordinate) ? 1 : 0);
            return new(count.ToString());
        }

        private static int CountXmasOccurrences(Map<char> aMap, Coordinate aCoordinate)
        {
            const string WordToMatch = "XMAS";

            if (aMap[aCoordinate.X, aCoordinate.Y] != WordToMatch[0])
            {
                return 0;
            }

            int count = 0;
            for (int xAdjust = -1; xAdjust <= 1; xAdjust++)
            {
                for (int yAdjust = -1; yAdjust <= 1; yAdjust++)
                {
                    if (xAdjust == 0 && yAdjust == 0)
                    {
                        continue;
                    }

                    Coordinate[] coordinates = new Coordinate[4];
                    for (int i = 0; i < coordinates.Length; i++)
                    {
                        coordinates[i] = new(
                            aCoordinate.X + (xAdjust * i),
                            aCoordinate.Y + (yAdjust * i)
                        );
                    }

                    if (
                        aMap.IsValidCoordinate(coordinates)
                        && new string(aMap[coordinates]) == WordToMatch
                    )
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static bool IsValidXMas(Map<char> aMap, Coordinate aCenterCoordinate)
        {
            const string WordToMatch = "MAS";

            Coordinate[] upperLeftToBottomRight =
            [
                new(aCenterCoordinate.X - 1, aCenterCoordinate.Y - 1),
                new(aCenterCoordinate.X, aCenterCoordinate.Y),
                new(aCenterCoordinate.X + 1, aCenterCoordinate.Y + 1),
            ];
            Coordinate[] bottomLeftToUpperRight =
            [
                new(aCenterCoordinate.X - 1, aCenterCoordinate.Y + 1),
                new(aCenterCoordinate.X, aCenterCoordinate.Y),
                new(aCenterCoordinate.X + 1, aCenterCoordinate.Y - 1),
            ];

            if (
                !aMap.IsValidCoordinate(upperLeftToBottomRight)
                || !aMap.IsValidCoordinate(bottomLeftToUpperRight)
            )
            {
                return false;
            }

            string upperLeftToBottomRightWord = new(aMap[upperLeftToBottomRight]);
            string bottomLeftToUpperRightWord = new(aMap[bottomLeftToUpperRight]);
            return (
                    upperLeftToBottomRightWord == WordToMatch
                    || upperLeftToBottomRightWord == new string(WordToMatch.Reverse().ToArray())
                )
                && (
                    bottomLeftToUpperRightWord == WordToMatch
                    || bottomLeftToUpperRightWord == new string(WordToMatch.Reverse().ToArray())
                );
        }
    }
}
