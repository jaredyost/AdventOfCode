using AdventOfCode.Core.Helpers.Extensions;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers.Y2022
{
    public partial class Day05 : BaseDay2022
    {
        protected override int Day => 5;

        private enum Movement
        {
            Single,
            Stack,
        }

        private readonly struct Instruction(string aCount, string aSource, string aDestination)
        {
            public readonly int Count { get; } = int.Parse(aCount);
            public readonly int Source { get; } = int.Parse(aSource);
            public readonly int Destination { get; } = int.Parse(aDestination);
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(DetermineTopCrates(aInput, Movement.Single));
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(DetermineTopCrates(aInput, Movement.Stack));
        }

        [GeneratedRegex("move ([0-9]+) from ([0-9]+) to ([0-9]+)")]
        private static partial Regex InstructionRegex();

        private static string DetermineTopCrates(string[] aData, Movement aMovement)
        {
            int blankInputLine = aData.ToList().IndexOf("");

            int stackCount = aData[blankInputLine - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Max();
            Stack<char>[] stacks = [.. (new Stack<char>[stackCount]).Select(x => new Stack<char>())];
            for (int i = blankInputLine - 2; i >= 0; i--)
            {
                for (int j = 1; j < aData[0].Length; j += 4)
                {
                    if (!char.IsWhiteSpace(aData[i][j]))
                    {
                        stacks[(j - 1) / 4].Push(aData[i][j]);
                    }
                }
            }

            Regex regex = InstructionRegex();
            List<Instruction> instructions = [];
            for (int i = blankInputLine + 1; i < aData.Length; i++)
            {
                GroupCollection groups = regex.Matches(aData[i])[0].Groups;
                instructions.Add(new(groups[1].Value, groups[2].Value, groups[3].Value));
            }

            foreach (Instruction instruction in instructions)
            {
                if (aMovement == Movement.Stack)
                {
                    stacks[instruction.Destination - 1].PushMultiple(stacks[instruction.Source - 1].PopMultiple(instruction.Count));
                    continue;
                }

                for (int i = 0; i < instruction.Count; i++)
                {
                    stacks[instruction.Destination - 1].Push(stacks[instruction.Source - 1].Pop());
                }
            }

            return string.Concat(stacks.Select(x => x.Peek()));
        }
    }
}
