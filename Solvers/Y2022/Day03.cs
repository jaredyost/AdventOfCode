namespace AdventOfCode.Solvers.Y2022
{
    public class Day03 : BaseDay2022
    {
        protected override int Day => 3;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int priorityTotal = 0;
            foreach (string sack in aInput)
            {
                priorityTotal += GetPriority([.. sack.Chunk(sack.Length / 2).Select(x => new string(x))]);
            }

            return new(priorityTotal.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int priorityTotal = 0;
            for (int i = 0; i < aInput.Length; i += 3)
            {
                priorityTotal += GetPriority([.. aInput.Take(new Range(i, i + 3))]);
            }

            return new(priorityTotal.ToString());
        }

        private static int GetPriority(string[] aSacks)
        {
            int priority = 0;
            List<char> checkedItems = [];
            foreach (char item in aSacks[0])
            {
                if (checkedItems.Contains(item))
                {
                    continue;
                }

                checkedItems.Add(item);
                if (aSacks.All(x => x.Contains(item)))
                {
                    priority += item - (item >= 'a' ? ('a' - 1) : ('A' - 27));
                }
            }

            return priority;
        }
    }
}
