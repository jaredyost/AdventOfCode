namespace AdventOfCode.Solvers.Y2023
{
    public class Day07 : BaseDay2023
    {
        protected override int Day => 7;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int totalWinnings = 0;
            Hand[] hands = Hand.ParseHandsSorted(aInput, Hand.JType.Jack);
            for (int i = 0; i < hands.Length; i++)
            {
                totalWinnings += hands[i].Bid * (i + 1);
            }

            return new(totalWinnings.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int totalWinnings = 0;
            Hand[] hands = Hand.ParseHandsSorted(aInput, Hand.JType.Joker);
            for (int i = 0; i < hands.Length; i++)
            {
                totalWinnings += hands[i].Bid * (i + 1);
            }

            return new(totalWinnings.ToString());
        }

        private class Hand
        {
            // csharpier-ignore-start
            public enum WinType
            {
                // Lowest
                HighCard,
                OnePair,
                TwoPair,
                ThreeOfAKind,
                FullHouse,
                FourOfAKind,
                FiveOfAKind,
                // Highest

                Count,
            }
            // csharpier-ignore-end

            public enum JType
            {
                Jack,
                Joker,
            }

            public int Bid { get; }
            public WinType Type { get; }

            private readonly int[] Cards;

            public Hand(string aInput, JType aJType)
            {
                string[] splitInput = [.. aInput.Split(' ')];

                List<int> cards = [];
                foreach (char card in splitInput[0].ToCharArray())
                {
                    int cardValue;
                    switch (card)
                    {
                        case 'A':
                            cardValue = 14;
                            break;

                        case 'K':
                            cardValue = 13;
                            break;

                        case 'Q':
                            cardValue = 12;
                            break;

                        case 'J':
                            cardValue = 11;
                            break;

                        case 'T':
                            cardValue = 10;
                            break;

                        default:
                            cardValue = int.Parse(card.ToString());
                            break;
                    }

                    cards.Add(cardValue);
                }

                Cards = [.. cards];
                Type = GetWinType(Cards);
                Bid = int.Parse(splitInput[1]);

                if (aJType == JType.Joker)
                {
                    Type = GetWinTypeWithJokers(Cards);
                    Cards = [.. Cards.Select(x => x == 11 ? 1 : x)];
                }
            }

            public static Hand[] ParseHandsSorted(string[] aInput, JType aJType)
            {
                List<Hand> hands = [];
                foreach (string input in aInput.Where(x => !string.IsNullOrWhiteSpace(x)))
                {
                    hands.Add(new(input, aJType));
                }

                return [.. hands.OrderBy(x => x, new HandComparer())];
            }

            private static WinType GetWinType(int[] aCards)
            {
                int[] distinctCards = [.. aCards.Distinct()];

                if (distinctCards.Length == 2)
                {
                    foreach (int card in distinctCards)
                    {
                        if (aCards.Where(x => x == card).Count() == 4)
                        {
                            return WinType.FourOfAKind;
                        }
                    }

                    return WinType.FullHouse;
                }

                foreach (int card in distinctCards)
                {
                    if (aCards.Where(x => x == card).Count() == 3)
                    {
                        return WinType.ThreeOfAKind;
                    }
                }

                int pairCount = 0;
                foreach (int card in distinctCards)
                {
                    if (aCards.Where(x => x == card).Count() == 2)
                    {
                        pairCount++;
                    }
                }

                return pairCount switch
                {
                    1 => WinType.OnePair,
                    2 => WinType.TwoPair,
                    _ => distinctCards.Length == 1 ? WinType.FiveOfAKind : WinType.HighCard,
                };
            }

            private static WinType GetWinTypeWithJokers(int[] aCards)
            {
                int jokerCount = aCards.Where(x => x == 11).Count();
                int[] distinctCards = [.. aCards.Where(x => x != 11).Distinct().OrderDescending()];

                if (distinctCards.Length == 1)
                {
                    return WinType.FiveOfAKind;
                }

                if (distinctCards.Length == 2)
                {
                    foreach (int card in distinctCards)
                    {
                        if (aCards.Where(x => x == card).Count() + jokerCount == 4)
                        {
                            return WinType.FourOfAKind;
                        }
                    }

                    return WinType.FullHouse;
                }

                foreach (int card in distinctCards)
                {
                    if (aCards.Where(x => x == card).Count() + jokerCount == 3)
                    {
                        return WinType.ThreeOfAKind;
                    }
                }

                int pairCount = 0;
                int jokersLeft = jokerCount;
                foreach (int card in aCards.Distinct())
                {
                    if (aCards.Where(x => x == card).Count() + jokersLeft == 2)
                    {
                        pairCount++;
                        jokersLeft = int.Max(jokersLeft - 1, 0);
                    }
                }

                return pairCount switch
                {
                    1 => WinType.OnePair,
                    2 => WinType.TwoPair,
                    _ => aCards.Distinct().Count() <= 2 ? WinType.FiveOfAKind : WinType.HighCard,
                };
            }

            private class HandComparer : IComparer<Hand>
            {
                public int Compare(Hand? x, Hand? y)
                {
                    if (x == null)
                    {
                        return -1;
                    }

                    if (y == null)
                    {
                        return 1;
                    }

                    int card = 0;
                    int result = x.Type.CompareTo(y.Type);
                    while (result == 0 && card < x.Cards.Length)
                    {
                        result = x.Cards[card] - y.Cards[card];
                        card++;
                    }

                    return result;
                }
            }
        }
    }
}
