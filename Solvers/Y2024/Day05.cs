namespace AdventOfCode.Solvers.Y2024
{
    public class Day05 : BaseDay2024
    {
        protected override int Day => 5;

        private enum UpdateType
        {
            Valid,
            Invalid,
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(SumUpdates(FilterUpdates(aInput, UpdateType.Valid)).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int[][] updates = FilterUpdates(aInput, UpdateType.Invalid);
            for (int i = 0; i < updates.Length; i++)
            {
                List<int> sortedUpdates = new(updates[i]);
                sortedUpdates.Sort(new UpdateSorter(GetRules(aInput)));
                updates[i] = [.. sortedUpdates];
            }

            return new(SumUpdates(updates).ToString());
        }

        private static Tuple<int, int>[] GetRules(string[] aUpdate)
        {
            List<Tuple<int, int>> rules = [];
            foreach (string line in aUpdate)
            {
                if (line.Contains('|'))
                {
                    int[] pages = [.. line.Split('|').Select(int.Parse)];
                    rules.Add(new(pages[0], pages[1]));
                }
            }

            return [.. rules];
        }

        private static int[][] GetUpdates(string[] aUpdate)
        {
            List<int[]> updates = [];
            foreach (string line in aUpdate)
            {
                if (line.Contains(','))
                {
                    updates.Add([.. line.Split(',').Select(int.Parse)]);
                }
            }

            return [.. updates];
        }

        private static bool IsUpdateValid(int[] aUpdate, Tuple<int, int>[] aRules)
        {
            bool valid = true;
            for (int i = 0; i < aUpdate.Length && valid; i++)
            {
                Tuple<int, int>[] applicableRules =
                [
                    .. aRules.Where(x => aUpdate[i] == x.Item1 && aUpdate.Contains(x.Item2)),
                ];
                for (int j = 0; j < applicableRules.Length && valid; j++)
                {
                    valid = i < Array.IndexOf(aUpdate, applicableRules[j].Item2);
                }
            }

            return valid;
        }

        private static int[][] FilterUpdates(string[] aUpdate, UpdateType aUpdateType)
        {
            List<int[]> reports = [];
            Tuple<int, int>[] rules = GetRules(aUpdate);
            foreach (int[] update in GetUpdates(aUpdate))
            {
                bool valid = IsUpdateValid(update, rules);
                if (
                    (aUpdateType == UpdateType.Valid && valid)
                    || (aUpdateType == UpdateType.Invalid && !valid)
                )
                {
                    reports.Add(update);
                }
            }

            return [.. reports];
        }

        private static int SumUpdates(int[][] aUpdates)
        {
            int sum = 0;
            foreach (int[] update in aUpdates)
            {
                sum += update[(int)Math.Floor(update.Length / 2.0)];
            }

            return sum;
        }

        private class UpdateSorter(Tuple<int, int>[] aRules) : IComparer<int>
        {
            private readonly Tuple<int, int>[] Rules = aRules;

            public int Compare(int aFirst, int aSecond)
            {
                // Correct order
                if (Rules.Where(x => x.Item1 == aFirst && x.Item2 == aSecond).Any())
                {
                    return -1;
                }

                // Incorrect order
                if (Rules.Where(x => x.Item1 == aSecond && x.Item2 == aFirst).Any())
                {
                    return 1;
                }

                // Not comparable
                return 0;
            }
        }
    }
}
