namespace AdventOfCode.Solvers.Y2023
{
    public class Day02 : BaseDay2023
    {
        protected override int Day => 2;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(
                Game.ParseGames(aInput)
                    .Where(x => x.Red <= 12 && x.Green <= 13 && x.Blue <= 14)
                    .Sum(x => x.ID)
                    .ToString()
            );
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(Game.ParseGames(aInput).Sum(x => x.Red * x.Green * x.Blue).ToString());
        }

        private class Game
        {
            public int ID { get; }
            public int Red { get; } = 0;
            public int Green { get; } = 0;
            public int Blue { get; } = 0;

            public Game(string aGameString)
            {
                string[] gameOverview = aGameString.Split(':');
                ID = int.Parse(gameOverview[0].Split(' ')[1]);

                foreach (string handful in gameOverview[1].Split(';'))
                {
                    foreach (string type in handful.Split(','))
                    {
                        string[] typeSplit = type.Trim().Split(' ');
                        int amount = int.Parse(typeSplit[0].ToString());
                        switch (typeSplit[1])
                        {
                            case "red":
                                Red = int.Max(Red, amount);
                                break;

                            case "green":
                                Green = int.Max(Green, amount);
                                break;

                            case "blue":
                                Blue = int.Max(Blue, amount);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            public static IEnumerable<Game> ParseGames(string[] aInput)
            {
                return aInput.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => new Game(x));
            }
        }
    }
}
