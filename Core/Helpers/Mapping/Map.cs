namespace AdventOfCode.Core.Helpers.Mapping
{
    public class Map<T>
    {
        public T[,] Grid { get; }
        public int Height => Grid.GetLength(0);
        public int Width => Grid.GetLength(1);

        public Map(string[] aGrid, Func<string, T[]> aParseFunction)
        {
            Grid = new T[aGrid.Length, aGrid[0].Length];
            for (int y = 0; y < Height; y++)
            {
                T[] values = aParseFunction(aGrid[y]);
                for (int x = 0; x < Width; x++)
                {
                    Grid[x, y] = values[x];
                }
            }
        }

        public bool IsValidCoordinate(Coordinate aCoordinate)
        {
            return MathUtilities.InRange(aCoordinate.X, 0, Width - 1)
                    && MathUtilities.InRange(aCoordinate.Y, 0, Height - 1);
        }

        public bool IsValidCoordinate(Coordinate[] aCoordinates)
        {
            return !aCoordinates.Where(x => !IsValidCoordinate(x)).Any();
        }

        public void IterateColumnsRows(Action<Coordinate> aIteratorCallback)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    aIteratorCallback(new(x, y));
                }
            }
        }

        public T this[int aX, int aY]
        {
            get => Grid[aY, aX];
            set => Grid[aY, aX] = value;
        }

        public T this[Coordinate aCoordinate]
        {
            get => this[aCoordinate.X, aCoordinate.Y];
            set => this[aCoordinate.X, aCoordinate.Y] = value;
        }

        public T[] this[Coordinate[] aCoordinates]
        {
            get
            {
                T[] values = new T[aCoordinates.Length];
                for(int i = 0; i < aCoordinates.Length; i++)
                {
                    values[i] = this[aCoordinates[i]];
                }
                return values;
            }

            set
            {
                for (int i = 0; i < aCoordinates.Length; i++)
                {
                    this[aCoordinates[i]] = value[i];
                }
            }
        }

        public static char[] CharacterParser(string aInput)
        {
            return [.. aInput];
        }
    }
}
