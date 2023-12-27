using AdventOfCode.Core;

namespace AdventOfCode.Solvers.y2023
{
    public partial class Day09 : SolverBase
    {
        private enum ExtrapolateDirection
        {
            Forwards,
            Backwards,
        }

        public Day09() : base(new DateOnly(2023, 12, 09)) { }

        public override string SolvePart1(string[] aInput)
        {
            int sum = 0;
            foreach (string input in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                sum += Extrapolate(input, ExtrapolateDirection.Forwards);
            }

            return sum.ToString();
        }

        public override string SolvePart2(string[] aInput)
        {
            int sum = 0;
            foreach (string input in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                sum += Extrapolate(input, ExtrapolateDirection.Backwards);
            }

            return sum.ToString();
        }

        private static int Extrapolate(string aInput, ExtrapolateDirection aDirection)
        {
            List<List<int>> readings = [[.. aInput.Split().Select(int.Parse)]];

            // Calculate all the differences
            while (readings.Last().Where(x => x != 0).Any())
            {
                List<int> differences = [];
                for (int i = 0; i < readings.Last().Count - 1; i++)
                {
                    differences.Add(readings.Last()[i + 1] - readings.Last()[i]);
                }
                readings.Add(differences);
            }

            // Extrapolate in the provided direction
            int lastDifference = 0;
            for (int i = readings.Count - 2; i >= 0; i--)
            {
                lastDifference = aDirection == ExtrapolateDirection.Backwards ? readings[i].First() - lastDifference : readings[i].Last() + lastDifference;
            }

            return lastDifference;
        }
    }
}
