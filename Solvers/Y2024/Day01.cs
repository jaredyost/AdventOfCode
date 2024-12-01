namespace AdventOfCode.Solvers.Y2024
{
    public class Day01 : BaseDay2024
    {
        protected override int Day => 1;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            List<int> firstColumn = [.. aInput.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0])).Order()];
            List<int> secondColumn = [.. aInput.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1])).Order()];

            int distance = 0;
            for (int i = 0; i < firstColumn.Count; i++)
            {
                distance += Math.Abs(firstColumn[i] - secondColumn[i]);
            }

            return new(distance.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<int> firstColumn = [.. aInput.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0]))];
            List<int> secondColumn = [.. aInput.Select(x => int.Parse(x.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]))];

            int similarityScore = 0;
            foreach (int number in firstColumn.Distinct())
            {
                similarityScore += number * firstColumn.Where(x => x == number).Count() * secondColumn.Where(x => x == number).Count();
            }

            return new(similarityScore.ToString());
        }
    }
}
