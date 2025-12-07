namespace AdventOfCode.Solvers.Y2023
{
    public class Day05 : BaseDay2023
    {
        protected override int Day => 5;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            long min = long.MaxValue;
            Farm farm = new(aInput[1..]);
            foreach (
                long seed in aInput[0].Split(':')[1].Trim().Split(' ').Select(long.Parse).ToArray()
            )
            {
                min = long.Min(min, farm.ProcessSeed(seed));
            }

            return new(min.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<Range> ranges = [];
            long[] rawSeeds = aInput[0]
                .Split(':')[1]
                .Trim()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();
            for (int i = 0; i < rawSeeds.Length; i += 2)
            {
                ranges.Add(new($"0 {rawSeeds[i]} {rawSeeds[i + 1]}"));
            }

            long min = long.MaxValue;
            Farm farm = new(aInput[1..]);
            foreach (Range range in ranges)
            {
                min = long.Min(min, farm.ProcessSeedRange(range));
            }

            return new(min.ToString());
        }

        private class Farm
        {
            private readonly List<Map> Maps = [];

            public Farm(string[] aInput)
            {
                List<string> lines = [];
                foreach (string line in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
                {
                    if (line.Contains("map"))
                    {
                        if (lines.Count > 0)
                        {
                            // We're about to start a new map, parse the cached one first
                            Maps.Add(new(lines));
                            lines.Clear();
                        }

                        continue;
                    }

                    lines.Add(line);
                }

                if (lines.Count > 0)
                {
                    // Parse the last cached map
                    Maps.Add(new(lines));
                }
            }

            public long ProcessSeed(long aSeed)
            {
                Maps.ForEach(x => aSeed = x.ProcessMap(aSeed));
                return aSeed;
            }

            public long ProcessSeedRange(Range aRange)
            {
                Range[] seedRanges = [aRange];
                foreach (Map map in Maps)
                {
                    List<Range> newSeedRanges = [];
                    foreach (Range seedRange in seedRanges)
                    {
                        long lastEnd = seedRange.SourceStart;
                        foreach (Range mapRange in map.Ranges.OrderBy(x => x.SourceStart))
                        {
                            if (
                                mapRange.SourceEnd > seedRange.SourceStart
                                && mapRange.SourceStart < seedRange.SourceEnd
                            )
                            {
                                // Create the new range
                                long start = long.Max(seedRange.SourceStart, mapRange.SourceStart);
                                long end = long.Min(seedRange.SourceEnd, mapRange.SourceEnd);
                                newSeedRanges.Add(
                                    new(
                                        $"0 {start + mapRange.DestinationStart - mapRange.SourceStart} {end - start}"
                                    )
                                );

                                // Check if there are any gaps to carry forward
                                if (lastEnd != start)
                                {
                                    newSeedRanges.Add(new($"0 {lastEnd} {start - lastEnd}"));
                                }

                                lastEnd = end;
                            }
                        }

                        if (lastEnd != seedRange.SourceEnd)
                        {
                            // There was a gap at the end that still needs to be carried forward
                            newSeedRanges.Add(new($"0 {lastEnd} {seedRange.SourceEnd - lastEnd}"));
                        }
                    }

                    seedRanges = [.. newSeedRanges.OrderBy(x => x.SourceStart)];
                }

                return seedRanges[0].SourceStart;
            }

            private class Map(List<string> aInput)
            {
                public Range[] Ranges { get; } =
                    aInput
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(x => new Range(x))
                        .ToArray();

                public long ProcessMap(long aSeed)
                {
                    long newSeed = aSeed;
                    foreach (Range range in Ranges)
                    {
                        newSeed = range.MapSeed(newSeed);
                        if (newSeed != aSeed)
                        {
                            // Once we map once, we're done
                            break;
                        }
                    }

                    return newSeed;
                }
            }
        }

        private class Range
        {
            public long DestinationStart { get; }
            public long SourceStart { get; }
            public long Length { get; }
            public long SourceEnd => SourceStart + Length;

            public Range(string aInput)
            {
                long[] parsedInput = aInput.Split(' ').Select(long.Parse).ToArray();
                DestinationStart = parsedInput[0];
                SourceStart = parsedInput[1];
                Length = parsedInput[2];
            }

            public long MapSeed(long aSeed)
            {
                return aSeed >= SourceStart && aSeed < SourceEnd
                    ? DestinationStart + (aSeed - SourceStart)
                    : aSeed;
            }
        }
    }
}
