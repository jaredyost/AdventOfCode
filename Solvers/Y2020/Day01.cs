namespace AdventOfCode.Solvers.Y2020
{
    public class Day01 : BaseDay2020
    {
        protected override int Day => 1;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            List<int> entries = aInput.Select(int.Parse).ToList();

            int result = 0;
            for (int i = 0; i < entries.Count && result == 0; i++)
            {
                for (int j = i + 1; j < entries.Count && result == 0; j++)
                {
                    if (entries[i] + entries[j] == 2020)
                    {
                        result = entries[i] * entries[j];
                    }
                }
            }

            return new(result.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<int> entries = aInput.Select(int.Parse).ToList();

            int result = 0;
            for (int i = 0; i < entries.Count && result == 0; i++)
            {
                for (int j = i + 1; j < entries.Count && result == 0; j++)
                {
                    for (int k = j + 1; k < entries.Count && result == 0; k++)
                    {
                        if (entries[i] + entries[j] + entries[k] == 2020)
                        {
                            result = entries[i] * entries[j] * entries[k];
                        }
                    }
                }
            }

            return new(result.ToString());
        }
    }
}
