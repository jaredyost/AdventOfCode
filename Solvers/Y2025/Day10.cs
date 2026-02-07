using System.Text.RegularExpressions;
using AdventOfCode.Core.Helpers.Comparers;
using AdventOfCode.Core.Helpers.Types;
using AoCHelper;

namespace AdventOfCode.Solvers.Y2025
{
    public partial class Day10 : BaseDay2025
    {
        protected override int Day => 10;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            Machine[] machines = [.. aInput.Select(x => new Machine(x))];
            return new(machines.Sum(x => x.GetMinButtonPressesToStart()).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            Machine[] machines = [.. aInput.Select(x => new Machine(x))];
            return new(machines.Sum(x => x.GetMinButtonPressesToConfigure()).ToString());
        }

        private partial class Machine
        {
            private readonly int Lights;
            private readonly int[] Joltages;
            private readonly int[] Buttons;

            public Machine(string aDescription)
            {
                Match machine = MachineRegex().Match(aDescription);

                string diagram = machine.Groups["LightDiagram"].Value;
                Lights = Convert.ToInt32(diagram[1..^1].Replace('.', '0').Replace('#', '1'), 2);

                MatchCollection joltages = LightRegex().Matches(machine.Groups["Joltage"].Value);
                Joltages = new int[joltages.Count];
                for (int i = 0; i < Joltages.Length; i++)
                {
                    Joltages[i] = int.Parse(joltages[i].Value);
                }

                MatchCollection buttons = ButtonRegex().Matches(machine.Groups["Buttons"].Value);
                Buttons = new int[buttons.Count];
                for (int i = 0; i < Buttons.Length; i++)
                {
                    int buttonSchematic = 0;
                    foreach (Match light in LightRegex().Matches(buttons[i].Value))
                    {
                        buttonSchematic |= 1 << (Joltages.Length - 1 - int.Parse(light.Value));
                    }

                    Buttons[i] = buttonSchematic;
                }
            }

            public int GetMinButtonPressesToStart()
            {
                Queue<(int, int)> queue = [];
                List<int> visited = [];

                queue.Enqueue(new(0, 0));
                visited.Add(queue.Peek().Item1);
                while (queue.TryDequeue(out (int, int) state))
                {
                    if (state.Item1 == Lights)
                    {
                        return state.Item2;
                    }

                    int newCount = state.Item2 + 1;
                    foreach (int button in Buttons)
                    {
                        int newState = state.Item1 ^ button;
                        if (!visited.Contains(newState))
                        {
                            queue.Enqueue(new(newState, newCount));
                            visited.Add(newState);
                        }
                    }
                }

                throw new SolvingException("Solution not found");
            }

            public int GetMinButtonPressesToConfigure()
            {
                Dictionary<int[], int> presses = new(new IntArrayComparer()) { [Joltages] = 0 };

                Queue<int[]> queue = new();
                queue.Enqueue(Joltages);

                int[] buffer = new int[Joltages.Length];
                while (queue.TryDequeue(out int[]? state))
                {
                    int cost = presses[state];
                    if (state.All(x => x == 0))
                    {
                        return cost;
                    }

                    foreach (int button in Buttons)
                    {
                        Array.Copy(state, buffer, Joltages.Length);

                        bool valid = true;
                        for (int i = 0; i < Joltages.Length && valid; i++)
                        {
                            if (((button >> i) & 1) != 0)
                            {
                                int index = Joltages.Length - 1 - i;
                                buffer[index]--;
                                valid = valid && buffer[index] >= 0;
                            }
                        }

                        if (valid && !presses.ContainsKey(buffer))
                        {
                            int[] newKey = (int[])buffer.Clone();
                            presses[newKey] = cost + 1;
                            queue.Enqueue(newKey);
                        }
                    }
                }

                throw new SolvingException("Solution not found");
            }

            [GeneratedRegex(
                @"(?<LightDiagram>\[[.#]+\]) (?<Buttons>\(.*\)) (?<Joltage>\{(?:\d+\,?)+\})",
                RegexOptions.Compiled
            )]
            private static partial Regex MachineRegex();

            [GeneratedRegex(@"\((?:\d+\,?)+\)", RegexOptions.Compiled)]
            private static partial Regex ButtonRegex();

            [GeneratedRegex(@"\d+", RegexOptions.Compiled)]
            private static partial Regex LightRegex();
        }
    }
}
