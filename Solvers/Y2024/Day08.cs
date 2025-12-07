using AdventOfCode.Core.Helpers.Mapping;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day08 : BaseDay2024
    {
        protected override int Day => 8;

        private enum Spacing
        {
            InLine,
            DistanceRequired,
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(GetAntinodeLocations(aInput, Spacing.DistanceRequired).Count().ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(GetAntinodeLocations(aInput, Spacing.InLine).Count().ToString());
        }

        private static Map<bool> GetAntinodeLocations(string[] aGrid, Spacing aSpacing)
        {
            Map<char> antennas = Map<char>.GetCharacterMap(aGrid);
            Map<bool> antinodes = new(aGrid, x => false);
            antennas.IterateColumnsRows(
                coordinate =>
                    antennas.IterateColumnsRows(
                        secondCoordinate =>
                        {
                            Coordinate distance = secondCoordinate - coordinate;
                            if (aSpacing == Spacing.DistanceRequired)
                            {
                                _ = CheckAndPlaceAntinode(ref antinodes, coordinate - distance);
                                _ = CheckAndPlaceAntinode(
                                    ref antinodes,
                                    coordinate + (2 * distance)
                                );
                                return;
                            }

                            bool backwards = true,
                                forwards = true;
                            for (int i = 0; backwards || forwards; i++)
                            {
                                backwards = CheckAndPlaceAntinode(
                                    ref antinodes,
                                    coordinate - (i * distance)
                                );
                                forwards = CheckAndPlaceAntinode(
                                    ref antinodes,
                                    coordinate + (i * distance)
                                );
                            }
                        },
                        secondCoordinate =>
                            coordinate != secondCoordinate
                            && antennas[coordinate] == antennas[secondCoordinate]
                    ),
                coordinate => antennas[coordinate] != '.'
            );

            return antinodes;
        }

        private static bool CheckAndPlaceAntinode(ref Map<bool> aAntinodes, Coordinate aCoordinate)
        {
            if (aAntinodes.IsValidCoordinate(aCoordinate))
            {
                aAntinodes[aCoordinate] = true;
                return true;
            }

            return false;
        }
    }
}
