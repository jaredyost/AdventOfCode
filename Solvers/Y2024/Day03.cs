using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers.Y2024
{
    public partial class Day03 : BaseDay2024
    {
        protected override int Day => 3;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(ProcessMemory(aInput, SimpleMultiplyRegex()).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(ProcessMemory(aInput, ComplexMultiplyRegex()).ToString());
        }

        [GeneratedRegex(@"mul\((?<left>[0-9]+),(?<right>[0-9]+)\)", RegexOptions.Compiled)]
        private static partial Regex SimpleMultiplyRegex();

        [GeneratedRegex(@"mul\((?<left>[0-9]+),(?<right>[0-9]+)\)|(?<do>do\(\))|(?<dont>don't\(\))", RegexOptions.Compiled)]
        private static partial Regex ComplexMultiplyRegex();

        private static uint ProcessMemory(string[] aMemory, Regex aRegex)
        {
            uint sum = 0;
            bool enabled = true;
            foreach(string memory in aMemory){
                foreach (Match match in aRegex.Matches(memory))
                {
                    if (match.Groups.ContainsKey("do") && match.Groups["do"].Success)
                    {
                        enabled = true;
                        continue;
                    }

                    if (match.Groups.ContainsKey("dont") && match.Groups["dont"].Success)
                    {
                        enabled = false;
                        continue;
                    }

                    if (enabled)
                    {
                        sum += uint.Parse(match.Groups["left"].Value) * uint.Parse(match.Groups["right"].Value);
                    }
                }
            }

            return sum;
        }
    }
}
