using AdventOfCode.Core.Helpers.Mapping;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day15 : BaseDay2024
    {
        protected override int Day => 15;

        private enum WarehouseSize
        {
            Condensed,
            Expanded,
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(ProcessWarehouse(aInput, WarehouseSize.Condensed).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(ProcessWarehouse(aInput, WarehouseSize.Expanded).ToString());
        }

        private static int ProcessWarehouse(string[] aInformation, WarehouseSize aWarehouseSize)
        {
            int blankLine = Array.FindIndex(aInformation, string.IsNullOrWhiteSpace);

            string[] providedMap = aInformation[0..blankLine];
            if (aWarehouseSize == WarehouseSize.Expanded)
            {
                for (int i = 0; i < blankLine; i++)
                {
                    providedMap[i] = aInformation[i]
                        .Replace("#", "##")
                        .Replace("O", "[]")
                        .Replace(".", "..")
                        .Replace("@", "@.");
                }
            }

            Map<char> map = Map<char>.GetCharacterMap(providedMap);
            for (int i = blankLine + 1; i < aInformation.Length; i++)
            {
                aInformation[i]
                    .ToCharArray()
                    .ToList()
                    .ForEach(direction => MoveRobot(map, direction));
            }

            int gpsCoordinates = 0;
            map.IterateColumnsRows(
                coordinate => gpsCoordinates += (100 * coordinate.Y) + coordinate.X,
                coordinate => "O[".Contains(map[coordinate])
            );
            return gpsCoordinates;
        }

        private static void MoveRobot(Map<char> aMap, char aDirection)
        {
            int xFactor = aDirection switch
            {
                '<' => -1,
                '>' => 1,
                _ => 0,
            };

            int yFactor = aDirection switch
            {
                '^' => -1,
                'v' => 1,
                _ => 0,
            };

            Coordinate? robot = aMap.Find('@');
            Coordinate velocity = new(xFactor, yFactor);
            if (robot == null || velocity == new Coordinate(0, 0))
            {
                return;
            }

            List<Coordinate> boxesToMove = [];
            if (CanMove(aMap, robot, velocity, boxesToMove))
            {
                foreach (Coordinate boxToMove in boxesToMove)
                {
                    aMap[boxToMove + velocity] = aMap[boxToMove];
                    aMap[boxToMove] = '.';
                }

                aMap[robot + velocity] = '@';
                aMap[robot] = '.';
            }
        }

        private static bool CanMove(
            Map<char> aMap,
            Coordinate aItemLocation,
            Coordinate aVelocity,
            List<Coordinate> aBoxesToMove
        )
        {
            Coordinate nextCoordinate = aItemLocation + aVelocity;
            if (!aMap.IsValidCoordinate(nextCoordinate))
            {
                return false;
            }

            switch (aMap[nextCoordinate])
            {
                case '.':
                    if (!aBoxesToMove.Contains(aItemLocation))
                    {
                        aBoxesToMove.Add(aItemLocation);
                    }
                    return true;

                case '#':
                    return false;

                default:
                    bool canMove = CanMove(aMap, nextCoordinate, aVelocity, aBoxesToMove);
                    if (canMove && aVelocity.Y != 0 && "[]".Contains(aMap[nextCoordinate]))
                    {
                        Coordinate sideCoordinate = new(
                            nextCoordinate.X + (aMap[nextCoordinate] == ']' ? -1 : 1),
                            nextCoordinate.Y
                        );
                        canMove = CanMove(aMap, sideCoordinate, aVelocity, aBoxesToMove);

                        if (canMove && !aBoxesToMove.Contains(sideCoordinate))
                        {
                            aBoxesToMove.Add(sideCoordinate);
                        }
                    }

                    if (canMove && !aBoxesToMove.Contains(aItemLocation))
                    {
                        aBoxesToMove.Add(aItemLocation);
                    }

                    return canMove;
            }
        }
    }
}
