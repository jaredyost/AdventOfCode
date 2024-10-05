namespace AdventOfCode.Solvers.Y2023
{
    public class Day06 : BaseDay2023
    {
        protected override int Day => 6;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            long product = 1;
            foreach (Race race in Race.ParseRaces(aInput))
            {
                long count = 0;
                for (long i = 0; i < race.Time; i++)
                {
                    if ((race.Time - i) * i > race.Distance)
                    {
                        count++;
                    }
                }

                product *= count;
            }

            return new(product.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            Race race = new
            (
                long.Parse(string.Join("", aInput[0].Split(' ').Where(x => long.TryParse(x, out _)).Select(long.Parse).ToArray())),
                long.Parse(string.Join("", aInput[1].Split(' ').Where(x => long.TryParse(x, out _)).Select(long.Parse).ToArray()))
            );

            long count = 0;
            for (long i = 0; i < race.Time; i++)
            {
                if ((race.Time - i) * i > race.Distance)
                {
                    count++;
                }
            }

            return new(count.ToString());
        }

        private class Race(long aTime, long aDistance)
        {
            public long Time { get; } = aTime;
            public long Distance { get; } = aDistance;

            public static Race[] ParseRaces(string[] aInput)
            {
                long[] times = aInput[0].Split(' ').Where(x => long.TryParse(x, out _)).Select(long.Parse).ToArray();
                long[] distances = aInput[1].Split(' ').Where(x => long.TryParse(x, out _)).Select(long.Parse).ToArray();

                List<Race> races = [];
                for (int i = 0; i < times.Length; i++)
                {
                    races.Add(new(times[i], distances[i]));
                }

                return [.. races];
            }
        }
    }
}
