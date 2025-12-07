namespace AdventOfCode.Solvers.Y2025
{
    public class Day02 : BaseDay2025
    {
        protected override int Day => 2;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            ulong sum = 0;
            foreach (string pair in aInput[0].Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                string[] bounds = pair.Split('-');
                ulong lowerBound = ulong.Parse(bounds[0]);
                ulong upperBound = ulong.Parse(bounds[1]);

                for (ulong i = lowerBound; i <= upperBound; i++)
                {
                    string numString = i.ToString();
                    int length = numString.Length;
                    if (length % 2 == 0 && numString[..(length / 2)] == numString[(length / 2)..])
                    {
                        sum += i;
                    }
                }
            }

            return new(sum.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            ulong sum = 0;
            foreach (string pair in aInput[0].Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                string[] bounds = pair.Split('-');
                ulong lowerBound = ulong.Parse(bounds[0]);
                ulong upperBound = ulong.Parse(bounds[1]);

                for (ulong i = lowerBound; i <= upperBound; i++)
                {
                    bool valid = false;
                    string numString = i.ToString();
                    for (int j = numString.Length / 2; j >= 1 && !valid; j--)
                    {
                        string pattern = numString[..j];
                        valid = numString.Length % pattern.Length == 0;
                        for (
                            int k = pattern.Length;
                            valid && k < numString.Length;
                            k += pattern.Length
                        )
                        {
                            valid = valid && numString[k..(k + pattern.Length)] == pattern;
                        }
                    }

                    if (valid)
                    {
                        sum += ulong.Parse(numString);
                        continue;
                    }
                }
            }

            return new(sum.ToString());
        }
    }
}
