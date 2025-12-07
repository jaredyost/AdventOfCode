namespace AdventOfCode.Solvers.Y2020
{
    public class Day03 : BaseDay2020
    {
        protected override int Day => 3;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(CountTrees(aInput, new(3, 1)).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<Tuple<int, int>> slopes = [new(1, 1), new(3, 1), new(5, 1), new(7, 1), new(1, 2)];

            uint trees = 1;
            foreach (Tuple<int, int> slope in slopes)
            {
                trees *= CountTrees(aInput, slope);
            }

            return new(trees.ToString());
        }

        private static uint CountTrees(string[] aMap, Tuple<int, int> aSlope)
        {
            uint trees = 0;
            for (
                int x = 0, y = 0;
                y < aMap.Length;
                x = (x + aSlope.Item1) % aMap[0].Length, y += aSlope.Item2
            )
            {
                if (aMap[y][x] == '#')
                {
                    trees++;
                }
            }

            return trees;
        }
    }
}
