namespace AdventOfCode.Solvers.Y2024
{
    public class Day01 : BaseDay2024
    {
        protected override int Day => 1;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int distance = 0;
            Tuple<int[], int[]> columns = GetColumns(aInput);
            for (int i = 0; i < columns.Item1.Length; i++)
            {
                distance += Math.Abs(columns.Item1[i] - columns.Item2[i]);
            }

            return new(distance.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int similarityScore = 0;
            Tuple<int[], int[]> columns = GetColumns(aInput);
            foreach (int number in columns.Item1.Distinct())
            {
                similarityScore += number
                                    * columns.Item1.Where(x => x == number).Count()
                                    * columns.Item2.Where(x => x == number).Count();
            }

            return new(similarityScore.ToString());
        }

        private static Tuple<int[], int[]> GetColumns(string[] aLists)
        {
            int[] firstColumn = [.. aLists.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0])).Order()];
            int[] secondColumn = [.. aLists.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1])).Order()];
            return new(firstColumn, secondColumn);
        }
    }
}
