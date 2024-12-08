namespace AdventOfCode.Solvers.Y2022
{
    public class Day04 : BaseDay2022
    {
        protected override int Day => 4;

        private enum OverlapType
        {
            Any,
            Full,
        }

        private readonly struct Pair
        {
            public Pair(string aRange)
            {
                int[] range = [.. aRange.Split('-').Select(int.Parse)];

                LowerBound = range[0];
                UpperBound = range[1];
            }

            public Pair(int aPoint)
            {
                LowerBound = aPoint;
                UpperBound = aPoint;
            }

            public readonly int LowerBound { get; }
            public readonly int UpperBound { get; }

            public bool ContainsPair(Pair aOtherPair)
            {
                return LowerBound <= aOtherPair.LowerBound && UpperBound >= aOtherPair.UpperBound;
            }

            public bool OverlapsPair(Pair aOtherPair)
            {
                return aOtherPair.ContainsPair(new(LowerBound)) || aOtherPair.ContainsPair(new(UpperBound));
            }
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(CalculateOverlaps(aInput, OverlapType.Full).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(CalculateOverlaps(aInput, OverlapType.Any).ToString());
        }

        private static int CalculateOverlaps(string[] aPairs, OverlapType aOverlapType)
        {
            int overlappingPairs = 0;
            foreach (string pair in aPairs)
            {
                Pair[] pairs = [.. pair.Split(',').Select(x => new Pair(x))];
                if ((aOverlapType == OverlapType.Full && (pairs[0].ContainsPair(pairs[1]) || pairs[1].ContainsPair(pairs[0])))
                    || (aOverlapType == OverlapType.Any && (pairs[0].OverlapsPair(pairs[1]) || pairs[1].OverlapsPair(pairs[0]))))
                {
                    overlappingPairs++;
                }
            }

            return overlappingPairs;
        }
    }
}
