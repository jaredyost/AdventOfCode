using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers.Y2024
{
    public partial class Day13 : BaseDay2024
    {
        protected override int Day => 13;

        private struct LongCoordinate(string aX, string aY)
        {
            public long X = long.Parse(aX);
            public long Y = long.Parse(aY);
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(GetPrice(aInput).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(GetPrice(aInput, 10000000000000).ToString());
        }

        [GeneratedRegex(@"Button A: X\+(?<ax>[0-9]+), Y\+(?<ay>[0-9]+)\n"
                        + @"Button B: X\+(?<bx>[0-9]+), Y\+(?<by>[0-9]+)\n"
                        + @"Prize: X=(?<px>[0-9]+), Y=(?<py>[0-9]+)", RegexOptions.Compiled)]
        private static partial Regex PrizeMachineRegex();

        private static long GetPrice(string[] aMachines, long aPrizeOffset = 0)
        {
            long price = 0;
            foreach (Match match in PrizeMachineRegex().Matches(string.Join('\n', aMachines)))
            {
                LongCoordinate aMovement = new(match.Groups["ax"].Value, match.Groups["ay"].Value);
                LongCoordinate bMovement = new(match.Groups["bx"].Value, match.Groups["by"].Value);
                LongCoordinate prize = new(match.Groups["px"].Value, match.Groups["py"].Value);

                prize.X += aPrizeOffset;
                prize.Y += aPrizeOffset;

                // Utilize Cramer's rule to solve this system of equations:
                // 1. Px = A*Ax + B*Bx
                // 2. Py = A*Ay + B*By
                long determinant = (aMovement.X * bMovement.Y) - (aMovement.Y * bMovement.X);
                long aPresses = ((prize.X * bMovement.Y) - (prize.Y * bMovement.X)) / determinant;
                long bPresses = ((aMovement.X * prize.Y) - (aMovement.Y * prize.X)) / determinant;

                if ((aPresses * aMovement.X) + (bPresses * bMovement.X) == prize.X
                    && (aPresses * aMovement.Y) + (bPresses * bMovement.Y) == prize.Y)
                {
                    price += (3 * aPresses) + bPresses;
                }
            }

            return price;
        }
    }
}
