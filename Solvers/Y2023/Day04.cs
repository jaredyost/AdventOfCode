namespace AdventOfCode.Solvers.Y2023
{
    public class Day04 : BaseDay2023
    {
        protected override int Day => 4;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int sum = 0;
            foreach (string card in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                int cardTotal = 0;
                int winnerCount = new Card(card).WinningSelections.Count();
                for (int i = 0; i < winnerCount; i++)
                {
                    cardTotal += cardTotal == 0 ? 1 : cardTotal;
                }

                sum += cardTotal;
            }

            return new(sum.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<Card> cards = aInput.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => new Card(x)).ToList();
            for (int i = cards.Count - 1; i >= 0; i--)
            {
                cards[i].CardsAdded += cards[i].WinningSelections.Count();
                for (int j = 1; j <= cards[i].WinningSelections.Count(); j++)
                {
                    cards[i].CardsAdded += cards[i + j].CardsAdded;
                }
            }

            return new((cards.Count + cards.Sum(x => x.CardsAdded)).ToString());
        }

        private class Card
        {
            public int ID { get; }
            public IEnumerable<int> WinningSelections { get; } = [];
            public int CardsAdded { get; set; } = 0;

            public Card(string aInput)
            {
                IEnumerable<string> split = aInput.Split([':', '|']).Select(x => x.Trim());

                ID = int.Parse(split.ElementAt(0).Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ElementAt(1));
                WinningSelections = SplitNumbers(split.ElementAt(2)).Where(x => SplitNumbers(split.ElementAt(1)).Contains(x));
            }

            private static IEnumerable<int> SplitNumbers(string aInput)
            {
                return aInput.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse);
            }
        }
    }
}
