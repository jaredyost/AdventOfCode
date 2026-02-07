using AdventOfCode.Core.Helpers.Types.Mapping;

namespace AdventOfCode.Solvers.Y2025
{
    public class Day04 : BaseDay2025
    {
        protected override int Day => 4;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(GetAccessibleRolls(Map<char>.GetCharacterMap(aInput)).Count.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int accessibleCount = 0;
            Map<char> map = Map<char>.GetCharacterMap(aInput);
            List<Coordinate> accessibleRolls = GetAccessibleRolls(map);
            while (accessibleRolls.Count > 0)
            {
                accessibleCount += accessibleRolls.Count;
                map.IterateColumnsRows(
                    coordinate => map[coordinate] = 'x',
                    accessibleRolls.Contains
                );
                accessibleRolls = GetAccessibleRolls(map);
            }

            return new(accessibleCount.ToString());
        }

        private static List<Coordinate> GetAccessibleRolls(Map<char> aMap)
        {
            List<Coordinate> accessibleRolls = [];
            aMap.IterateColumnsRows(
                accessibleRolls.Add,
                coordinate =>
                    aMap[coordinate] == '@'
                    && Coordinate
                        .GetAllNeighbors(coordinate)
                        .Where(neighbor =>
                            aMap.IsValidCoordinate(neighbor) && aMap[neighbor] == '@'
                        )
                        .Count() < 4
            );

            return accessibleRolls;
        }
    }
}
