namespace AdventOfCode.Solvers.Y2024
{
    public partial class Day04 : BaseDay2024
    {
        protected override int Day => 4;

        private struct Coordinate(int aX, int aY)
        {
            public int X = aX;
            public int Y = aY;
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int count = 0;
            for (int y = 0; y < aInput.Length; y++)
            {
                for (int x = 0; x < aInput[y].Length; x++)
                {
                    if (aInput[y][x] == 'X')
                    {
                        count += FindWord(aInput, new(x, y));
                    }
                }
            }

            return new(count.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int count = 0;
            for (int y = 0; y < aInput.Length; y++)
            {
                for (int x = 0; x < aInput[y].Length; x++)
                {
                    if (aInput[y][x] == 'A' && IsValidDiagonal(aInput, new(x, y)))
                    {
                        count++;
                    }
                }
            }

            return new(count.ToString());
        }

        private static bool IsCoordinateValid(string[] aPuzzle, Coordinate aCoordinate)
        {
            return aCoordinate.X >= 0 && aCoordinate.X < aPuzzle[0].Length
                    && aCoordinate.Y >= 0 && aCoordinate.Y < aPuzzle.Length;
        }

        private static int FindWord(string[] aPuzzle, Coordinate aStartingCoordinate)
        {
            int count = 0;
            for (int xAdjust = -1; xAdjust <= 1; xAdjust++)
            {
                for (int yAdjust = -1; yAdjust <= 1; yAdjust++)
                {
                    if (xAdjust == 0 && yAdjust == 0)
                    {
                        continue;
                    }

                    string word = "X";
                    for (int i = 1; i <= 3; i++)
                    {
                        Coordinate currentCoordinate = new(aStartingCoordinate.X + (xAdjust * i),
                                                            aStartingCoordinate.Y + (yAdjust * i));
                        if (IsCoordinateValid(aPuzzle, currentCoordinate))
                        {
                            word += aPuzzle[currentCoordinate.Y][currentCoordinate.X];
                        }
                    }

                    if (word == "XMAS")
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private static bool IsValidDiagonal(string[] aPuzzle, Coordinate aCenterCoordinate)
        {
            if (!IsCoordinateValid(aPuzzle, new(aCenterCoordinate.X - 1, aCenterCoordinate.Y - 1))
                || !IsCoordinateValid(aPuzzle, new(aCenterCoordinate.X - 1, aCenterCoordinate.Y + 1))
                || !IsCoordinateValid(aPuzzle, new(aCenterCoordinate.X + 1, aCenterCoordinate.Y - 1))
                || !IsCoordinateValid(aPuzzle, new(aCenterCoordinate.X + 1, aCenterCoordinate.Y + 1)))
            {
                return false;
            }

            string word1 = aPuzzle[aCenterCoordinate.Y - 1][aCenterCoordinate.X - 1] + "A"
                            + aPuzzle[aCenterCoordinate.Y + 1][aCenterCoordinate.X + 1];
            string word2 = aPuzzle[aCenterCoordinate.Y + 1][aCenterCoordinate.X - 1] + "A"
                            + aPuzzle[aCenterCoordinate.Y - 1][aCenterCoordinate.X + 1];
            return (word1 == "MAS" || word1 == "SAM") && (word2 == "MAS" || word2 == "SAM");
        }
    }
}
