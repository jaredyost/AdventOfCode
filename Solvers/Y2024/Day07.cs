namespace AdventOfCode.Solvers.Y2024
{
    public class Day07 : BaseDay2024
    {
        protected override int Day => 7;

        private enum ConcatBehavior
        {
            Disallowed,
            Allowed,
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(SumValidEquations(aInput, ConcatBehavior.Disallowed).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(SumValidEquations(aInput, ConcatBehavior.Allowed).ToString());
        }

        private static ulong SumValidEquations(string[] aEquations, ConcatBehavior aConcatBehavior)
        {
            ulong sum = 0;
            foreach (string equation in aEquations)
            {
                string[] splitEquation = equation.Split(':', StringSplitOptions.TrimEntries);
                ulong testValue = ulong.Parse(splitEquation[0]);
                if (
                    IsValidEquation(
                        testValue,
                        [.. splitEquation[1].Split(' ').Select(ulong.Parse)],
                        aConcatBehavior
                    )
                )
                {
                    sum += testValue;
                }
            }

            return sum;
        }

        private static bool IsValidEquation(
            ulong aTestValue,
            ulong[] aParts,
            ConcatBehavior aConcatBehavior
        )
        {
            if (aParts.Length == 1)
            {
                return aTestValue == aParts[0];
            }

            if (
                aTestValue % aParts.Last() == 0
                && IsValidEquation(aTestValue / aParts.Last(), aParts[..^1], aConcatBehavior)
            )
            {
                return true;
            }

            if (
                aTestValue > aParts.Last()
                && IsValidEquation(aTestValue - aParts.Last(), aParts[..^1], aConcatBehavior)
            )
            {
                return true;
            }

            string testValueString = aTestValue.ToString();
            string lastValueString = aParts[^1].ToString();
            return aConcatBehavior == ConcatBehavior.Allowed
                && testValueString.Length > lastValueString.Length
                && testValueString.EndsWith(lastValueString)
                && IsValidEquation(
                    ulong.Parse(
                        testValueString.Substring(
                            0,
                            testValueString.Length - lastValueString.Length
                        )
                    ),
                    aParts[..^1],
                    aConcatBehavior
                );
        }
    }
}
