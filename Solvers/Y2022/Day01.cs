namespace AdventOfCode.Solvers.Y2022
{
    public class Day01 : BaseDay2022
    {
        protected override int Day => 1;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(GetTotals(aInput).Max().ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<int> totals = [..GetTotals(aInput).OrderDescending()];
            return new((totals[0] + totals[1] + totals[2]).ToString());
        }

        private static List<int> GetTotals(string[] aCalories)
        {
            List<int> totals = [0];
            foreach (string line in aCalories)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    totals[totals.Count - 1] += int.Parse(line);
                    continue;
                }

                totals.Add(0);
            }

            return totals;
        }
    }
}
