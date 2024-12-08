namespace AdventOfCode.Solvers.Y2022
{
    public class Day06 : BaseDay2022
    {
        protected override int Day => 6;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(FindUniqueStringPosition(aInput[0], 4).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(FindUniqueStringPosition(aInput[0], 14).ToString());
        }

        private static int FindUniqueStringPosition(string aString, int aLength)
        {
            for (int i = aLength; i < aString.Length; i++)
            {
                if (aString.Substring(i-aLength, aLength).ToCharArray().GroupBy(x => x).Where(x => x.Count() == 1).Count() == aLength)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
