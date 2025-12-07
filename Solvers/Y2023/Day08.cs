using System.Numerics;
using System.Text.RegularExpressions;
using NodeDirections = System.Tuple<string, string>;

namespace AdventOfCode.Solvers.Y2023
{
    public partial class Day08 : BaseDay2023
    {
        protected override int Day => 8;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            char[] directions = aInput[0].ToCharArray();
            Dictionary<string, NodeDirections> nodes = ParseNodes(aInput[1..]);

            int stepCount = 1;
            NodeDirections nodeDirections = nodes["AAA"];
            for (
                int currentDirection = 0;
                ;
                currentDirection = (currentDirection + 1) % directions.Length, stepCount++
            )
            {
                string nextNode =
                    directions[currentDirection] == 'L'
                        ? nodeDirections.Item1
                        : nodeDirections.Item2;
                if (nextNode == "ZZZ")
                {
                    break;
                }

                nodeDirections = nodes[nextNode];
            }

            return new(stepCount.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            char[] directions = aInput[0].ToCharArray();
            Dictionary<string, NodeDirections> nodes = ParseNodes(aInput[1..]);

            ulong[] stespToFinish = new ulong[nodes.Where(x => x.Key.EndsWith('A')).Count()];
            for (int i = 0; i < stespToFinish.Length; i++)
            {
                ulong stepCount = 1;
                NodeDirections nodeDirections = nodes[
                    nodes.Where(x => x.Key.EndsWith('A')).ElementAt(i).Key
                ];
                for (
                    int currentDirection = 0;
                    ;
                    currentDirection = (currentDirection + 1) % directions.Length, stepCount++
                )
                {
                    string nextNode =
                        directions[currentDirection] == 'L'
                            ? nodeDirections.Item1
                            : nodeDirections.Item2;
                    if (nextNode.EndsWith('Z'))
                    {
                        break;
                    }

                    nodeDirections = nodes[nextNode];
                }

                stespToFinish[i] = stepCount;
            }

            return new(CalculateLeastCommonMultiple(stespToFinish).ToString());
        }

        private static Dictionary<string, NodeDirections> ParseNodes(string[] aInput)
        {
            Regex regex = NodeRegex();
            Dictionary<string, NodeDirections> nodes = [];
            foreach (string node in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                MatchCollection matches = regex.Matches(node);
                if (matches.Count > 0 && matches[0].Groups.Count == 4)
                {
                    nodes.Add(
                        matches[0].Groups[1].Value,
                        new NodeDirections(matches[0].Groups[2].Value, matches[0].Groups[3].Value)
                    );
                }
            }

            return nodes;
        }

        [GeneratedRegex(
            @"^([A-Za-z0-9]+)\s+=\s+\(([A-Za-z0-9]+),\s+([A-Za-z0-9]+)\)$",
            RegexOptions.Compiled
        )]
        private static partial Regex NodeRegex();

        private static ulong CalculateLeastCommonMultiple(ulong[] aInput)
        {
            ulong multiple = aInput[0];
            for (int i = 1; i < aInput.Length; i++)
            {
                multiple =
                    multiple
                    * aInput[i]
                    / (ulong)BigInteger.GreatestCommonDivisor(multiple, aInput[i]);
            }

            return multiple;
        }
    }
}
