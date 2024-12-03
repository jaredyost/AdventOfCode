﻿namespace AdventOfCode.Solvers.Y2024
{
    public class Day02 : BaseDay2024
    {
        protected override int Day => 2;

        private enum ErrorTolerance
        {
            None,
            Single,
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(aInput.Where(x => IsReportSafe(x, ErrorTolerance.None)).Count().ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(aInput.Where(x => IsReportSafe(x, ErrorTolerance.Single)).Count().ToString());
        }

        private static bool IsReportSafe(string aReport, ErrorTolerance aErrorTolerance)
        {
            return IsReportSafe([.. aReport.Split().Select(int.Parse)], aErrorTolerance);
        }

        private static bool IsReportSafe(List<int> aLevels, ErrorTolerance aErrorTolerance)
        {
            bool isSafe = true;
            int factor = aLevels[1] - aLevels[0] > 0 ? 1 : -1;
            for (int i = 1; i < aLevels.Count && isSafe; i++)
            {
                int difference = aLevels[i] - aLevels[i - 1];
                isSafe = factor * difference > 0 && Math.Abs(difference) >= 1 && Math.Abs(difference) <= 3;
            }

            if (!isSafe && aErrorTolerance == ErrorTolerance.Single)
            {
                for (int i = 0; i < aLevels.Count && !isSafe; i++)
                {
                    List<int> modifiedLevels = [.. aLevels];
                    modifiedLevels.RemoveAt(i);
                    isSafe = IsReportSafe(modifiedLevels, ErrorTolerance.None);
                }
            }

            return isSafe;
        }
    }
}
