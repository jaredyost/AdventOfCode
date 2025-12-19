using Range = System.Tuple<ulong, ulong>;

namespace AdventOfCode.Solvers.Y2025
{
    public class Day05 : BaseDay2025
    {
        protected override int Day => 5;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int freshCount = 0;
            Range[] ranges = [.. aInput.Where(x => x.Contains('-')).Select(ParseRange)];
            foreach (
                ulong ingredient in aInput.Where(x => ulong.TryParse(x, out _)).Select(ulong.Parse)
            )
            {
                freshCount += ranges
                    .Where(x => x.Item1 <= ingredient && x.Item2 >= ingredient)
                    .Any()
                    ? 1
                    : 0;
            }

            return new(freshCount.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<Range> ranges =
            [
                .. aInput
                    .Where(x => x.Contains('-'))
                    .Select(ParseRange)
                    .OrderBy(x => x.Item1)
                    .ThenBy(x => x.Item2),
            ];

            for (int i = 0; i < ranges.Count - 1; i++)
            {
                if (ranges[i + 1].Item1 <= ranges[i].Item2)
                {
                    ulong rangeMax = Math.Max(ranges[i].Item2, ranges[i + 1].Item2);
                    ranges[i] = new(ranges[i].Item1, rangeMax);
                    ranges.RemoveAt(i + 1);
                    i--;
                }
            }

            ulong ingredientCount = 0;
            foreach (Range range in ranges)
            {
                ingredientCount += range.Item2 - range.Item1 + 1;
            }

            return new(ingredientCount.ToString());
        }

        private static Range ParseRange(string aRangeString)
        {
            ulong[] split = [.. aRangeString.Split('-').Select(ulong.Parse)];
            return new(split.Min(), split.Max());
        }
    }
}
