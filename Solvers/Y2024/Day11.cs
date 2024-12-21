using System.Numerics;

namespace AdventOfCode.Solvers.Y2024
{
    public class Day11 : BaseDay2024
    {
        protected override int Day => 11;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(CountRocks(aInput, 25).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(CountRocks(aInput, 75).ToString());
        }

        private static BigInteger CountRocks(string[] aRocks, int aNumberBlinks)
        {
            BigInteger count = 0;
            Dictionary<Tuple<BigInteger, int>, BigInteger> cache = [];
            foreach (BigInteger rock in aRocks.SelectMany(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)).Select(BigInteger.Parse))
            {
                count += Blink(rock, aNumberBlinks, cache);
            }

            return count;
        }

        private static BigInteger Blink(BigInteger aRock, int aNumberBlinks, Dictionary<Tuple<BigInteger, int>, BigInteger> aCache)
        {
            BigInteger count = 1;
            Tuple<BigInteger, int> cacheKey = new(aRock, aNumberBlinks);
            if (aNumberBlinks > 0 && !aCache.TryGetValue(cacheKey, out count))
            {
                if (aRock == 0)
                {
                    count = Blink(1, aNumberBlinks - 1, aCache);
                    return count;
                }
                else
                {
                    string numberString = aRock.ToString();
                    count = numberString.Length % 2 == 0
                        ? Blink(BigInteger.Parse(numberString.Substring(0, numberString.Length / 2)), aNumberBlinks - 1, aCache)
                            + Blink(BigInteger.Parse(numberString.Substring(numberString.Length / 2)), aNumberBlinks - 1, aCache)
                        : Blink(aRock * 2024, aNumberBlinks - 1, aCache);
                }

                aCache.Add(cacheKey, count);
            }

            return count;
        }
    }
}
