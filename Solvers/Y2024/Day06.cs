using AdventOfCode.Core.Helpers.Types.Mapping;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day06 : BaseDay2024
    {
        protected override int Day => 6;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(WalkGuardRoute(Map<char>.GetCharacterMap(aInput))!.Length.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            Map<char> lab = Map<char>.GetCharacterMap(aInput);
            Coordinate[] path = WalkGuardRoute(lab)!;

            int possibilities = 0;
            for (int i = 0; i < path.Length; i++)
            {
                lab = Map<char>.GetCharacterMap(aInput);
                if (lab[path[i]] != '.')
                {
                    continue;
                }

                lab[path[i]] = '#';
                if (WalkGuardRoute(lab) == null)
                {
                    possibilities++;
                }
            }

            return new(possibilities.ToString());
        }

        private static Coordinate[]? WalkGuardRoute(Map<char> aMap)
        {
            Dictionary<char, Coordinate> Movements = new()
            {
                { '^', new(0, -1) },
                { '>', new(1, 0) },
                { 'v', new(0, 1) },
                { '<', new(-1, 0) },
            };

            Coordinate currentCoordinate = aMap.First([.. Movements.Keys])!;
            Coordinate nextCoordinate = currentCoordinate + Movements[aMap[currentCoordinate]];

            Dictionary<Coordinate, string> path = new()
            {
                { currentCoordinate, aMap[currentCoordinate].ToString() },
            };
            while (aMap.IsValidCoordinate(nextCoordinate))
            {
                if (aMap[nextCoordinate] == '#')
                {
                    int currentDirectionIndex = Movements
                        .Keys.ToList()
                        .IndexOf(aMap[currentCoordinate]);
                    aMap[currentCoordinate] = Movements.Keys.ElementAt(
                        (currentDirectionIndex + 1) % Movements.Count
                    );
                }
                else
                {
                    aMap[nextCoordinate] = aMap[currentCoordinate];
                    aMap[currentCoordinate] = '.';

                    currentCoordinate = nextCoordinate;
                    if (path.TryGetValue(currentCoordinate, out string? value))
                    {
                        if (value.Contains(aMap[currentCoordinate]))
                        {
                            // We're stuck in a loop, bail out
                            return null;
                        }

                        path[currentCoordinate] += aMap[currentCoordinate];
                    }
                    else
                    {
                        path.Add(currentCoordinate, aMap[currentCoordinate].ToString());
                    }
                }

                nextCoordinate = currentCoordinate + Movements[aMap[currentCoordinate]];
            }

            return [.. path.Keys];
        }
    }
}
