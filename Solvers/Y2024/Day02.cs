using System.Collections.Generic;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day02 : BaseDay2024
    {
        protected override int Day => 2;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int safeReportCount = 0;
            foreach (string report in aInput)
            {
                List<int> levels = report.Split().Select(int.Parse).ToList();
                int factor = levels[1] - levels[0] > 0 ? 1 : -1;

                bool safe = true;
                for (int i = 1; i < levels.Count && safe; i++)
                {
                    int difference = levels[i] - levels[i - 1];
                    safe = factor * difference > 0 && Math.Abs(difference) >= 1 && Math.Abs(difference) <= 3;
                }

                if (safe)
                {
                    safeReportCount++;
                }
            }

            return new(safeReportCount.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int safeReportCount = 0;
            foreach (string report in aInput)
            {
                List<int> levels = report.Split().Select(int.Parse).ToList();
                int factor = levels[1] - levels[0] > 0 ? 1 : -1;

                bool safe = true;
                for (int i = 1; i < levels.Count && safe; i++)
                {
                    int difference = levels[i] - levels[i - 1];
                    safe = factor * difference > 0 && Math.Abs(difference) >= 1 && Math.Abs(difference) <= 3;
                }

                if (!safe)
                {
                    for (int i = 0; i < levels.Count && !safe; i++)
                    {
                        List<int> modifiedLevels = new(levels);
                        modifiedLevels.RemoveAt(i);
                        int newFactor = modifiedLevels[1] - modifiedLevels[0] > 0 ? 1 : -1;

                        bool newSafe = true;
                        for (int j = 1; j < modifiedLevels.Count && newSafe; j++)
                        {
                            int difference = modifiedLevels[j] - modifiedLevels[j - 1];
                            newSafe = newFactor * difference > 0 && Math.Abs(difference) >= 1 && Math.Abs(difference) <= 3;
                        }

                        safe = newSafe;
                    }
                }

                if (safe)
                {
                    safeReportCount++;
                }
            }

            return new(safeReportCount.ToString());
        }
    }
}
