namespace AdventOfCode.Solvers.Y2022
{
    public class Day07 : BaseDay2022
    {
        protected override int Day => 7;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(ParseFileSystem(aInput).Where(x => x.Value <= 100000).Sum(x => x.Value).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            Dictionary<string, uint> directories = ParseFileSystem(aInput);
            uint spaceNeeded = 30000000 - (70000000 - directories["/"]);
            return new(ParseFileSystem(aInput).Where(x => x.Value >= spaceNeeded).Min(x => x.Value).ToString());
        }

        private static Dictionary<string, uint> ParseFileSystem(string[] aTerminalHistory)
        {
            List<string> path = [];
            Dictionary<string, uint> directories = new() { { "/", 0 } };
            foreach (string line in aTerminalHistory)
            {
                string[] parts = line.Split();
                if (parts[0] == "$")
                {
                    if (parts[1] == "cd")
                    {
                        if (parts[2] == "..")
                        {
                            path.RemoveAt(path.Count - 1);
                        }
                        else
                        {
                            path.Add(parts[2]);
                        }
                    }

                    continue;
                }

                if (parts[0] == "dir")
                {
                    directories.Add(string.Join('/', [.. path, parts[1]]), 0);
                    continue;
                }

                for (int j = 0; j < path.Count; j++)
                {
                    directories[string.Join('/', path.GetRange(0, j + 1))] += uint.Parse(parts[0]);
                }
            }

            return directories;
        }
    }
}
