namespace AdventOfCode.Solvers.Y2025
{
    public class Day03 : BaseDay2025
    {
        protected override int Day => 3;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int totalJoltage = 0;
            foreach (string bank in aInput)
            {
                int joltage = 0;
                for (int i = 0; i < bank.Length - 1; i++)
                {
                    for (int j = i + 1; j < bank.Length; j++)
                    {
                        joltage = Math.Max(joltage, int.Parse($"{bank[i]}{bank[j]}"));
                    }
                }

                totalJoltage += joltage;
            }

            return new(totalJoltage.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            ulong totalJoltage = 0;
            foreach (string bank in aInput)
            {
                ulong joltage = 0;
                int[] batteries = [.. bank.ToCharArray().Select(x => int.Parse(x.ToString()))];
                for (int i = 11; i >= 0; i--)
                {
                    int max = batteries[0..(batteries.Length - i)].Max();
                    joltage = (joltage * 10) + (ulong)max;
                    batteries = batteries[(batteries.IndexOf(max) + 1)..];
                }

                totalJoltage += joltage;
            }

            return new(totalJoltage.ToString());
        }
    }
}
