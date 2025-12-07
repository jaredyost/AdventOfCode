using System.Globalization;

namespace AdventOfCode.Solvers.Y2020
{
    public class Day05 : BaseDay2020
    {
        protected override int Day => 5;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(GetSeatIds(aInput)[0].ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int seatId = 0;
            List<int> seatIds = GetSeatIds(aInput);
            for (int i = 0; i < seatIds.Count - 1; i++)
            {
                if (seatIds[i] - seatIds[i + 1] != 1)
                {
                    seatId = seatIds[i] - 1;
                    break;
                }
            }

            return new(seatId.ToString());
        }

        private static List<int> GetSeatIds(string[] aBoardingPasses)
        {
            List<int> seatIds = [];
            foreach (string boardingPass in aBoardingPasses)
            {
                string row = boardingPass.Substring(0, 7).Replace('B', '1').Replace('F', '0');
                string column = boardingPass.Substring(7, 3).Replace('R', '1').Replace('L', '0');
                seatIds.Add(
                    (int.Parse(row, NumberStyles.BinaryNumber) * 8)
                        + int.Parse(column, NumberStyles.BinaryNumber)
                );
            }

            return [.. seatIds.OrderDescending()];
        }
    }
}
