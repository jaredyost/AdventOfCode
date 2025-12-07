using Record = System.Tuple<string, int[]>;

namespace AdventOfCode.Solvers.Y2023
{
    public class Day12 : BaseDay2023
    {
        protected override int Day => 12;

        private readonly Dictionary<(string, string), ulong> Cache = [];

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            List<Record> records = [];
            foreach (string line in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                string[] split = line.Split(' ');
                records.Add(new(split[0], [.. split[1].Split(',').Select(int.Parse)]));
            }

            ulong sum = 0;
            foreach (Record record in records)
            {
                sum += CalculateArrangements(record.Item1, record.Item2);
            }

            return new(sum.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<Record> records = [];
            foreach (string line in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                string[] split = line.Split(' ');

                // Unfold the record
                string[] unfoldedSplit = (string[])split.Clone();
                for (int i = 0; i < 4; i++)
                {
                    unfoldedSplit[0] += '?' + split[0];
                    unfoldedSplit[1] += ',' + split[1];
                }

                records.Add(
                    new(unfoldedSplit[0], [.. unfoldedSplit[1].Split(',').Select(int.Parse)])
                );
            }

            ulong sum = 0;
            foreach (Record record in records)
            {
                sum += CalculateArrangements(record.Item1, record.Item2);
            }

            return new(sum.ToString());
        }

        private ulong CalculateArrangements(string aMap, int[] aGroups)
        {
            if (aMap.Length == 0)
            {
                return aGroups.Length == 0 ? 1u : 0u;
            }

            if (aGroups.Length == 0)
            {
                return !aMap.Contains('#') ? 1u : 0u;
            }

            string groupsString = string.Join(',', aGroups);
            if (Cache.TryGetValue((aMap, groupsString), out ulong cacheValue))
            {
                return cacheValue;
            }

            ulong numArrangements = 0u;
            if (".?".Contains(aMap[0]))
            {
                numArrangements += CalculateArrangements(aMap[1..], aGroups);
            }

            if (
                "#?".Contains(aMap[0])
                && aGroups[0] <= aMap.Length
                && !aMap.Substring(0, aGroups[0]).Contains('.')
                && (aGroups[0] == aMap.Length || aMap[aGroups[0]] != '#')
            )
            {
                string newMap = "";
                if (aGroups[0] + 1 < aMap.Length)
                {
                    newMap = aMap.Substring(aGroups[0] + 1);
                }
                numArrangements += CalculateArrangements(newMap, aGroups[1..]);
            }

            Cache.Add((aMap, groupsString), numArrangements);
            return numArrangements;
        }
    }
}
