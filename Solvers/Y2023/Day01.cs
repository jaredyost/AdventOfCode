namespace AdventOfCode.Solvers.Y2023
{
    public class Day01 : BaseDay2023
    {
        protected override int Day => 1;

        private static readonly IReadOnlyDictionary<string, string> Numbers = new Dictionary<
            string,
            string
        >
        {
            // We need to maintain the first/last letter in case there's overlapping words
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t333e" },
            { "four", "f44r" },
            { "five", "f55e" },
            { "six", "s6x" },
            { "seven", "s777n" },
            { "eight", "e888t" },
            { "nine", "n99e" },
        };

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int total = 0;
            foreach (string line in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                IEnumerable<int> numbers = line.ToCharArray()
                    .Where(char.IsDigit)
                    .Select(x => int.Parse(x.ToString()));
                if (numbers.Any())
                {
                    total += (10 * numbers.First()) + numbers.Last();
                }
            }

            return new(total.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            // Replace spelled out versions with the digit
            List<string> newInput = [];
            foreach (string line in aInput)
            {
                string newLine = "";
                for (int i = 0; i < line.Length; i++)
                {
                    bool modified = false;
                    foreach (KeyValuePair<string, string> number in Numbers)
                    {
                        if (
                            line.Substring(i).Length >= number.Key.Length
                            && number.Key.Equals(line.Substring(i, number.Key.Length))
                        )
                        {
                            newLine += number.Value;
                            modified = true;
                            break;
                        }
                    }

                    if (!modified)
                    {
                        newLine += line[i];
                    }
                }

                newInput.Add(newLine);
            }

            // Route the modified input through our original processing
            return SolvePart1([.. newInput]);
        }
    }
}
