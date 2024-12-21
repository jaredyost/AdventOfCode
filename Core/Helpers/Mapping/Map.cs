namespace AdventOfCode.Core.Helpers.Mapping
{
    public class Map<T>
    {
        #region Properties
        public T[,] Grid { get; }
        public int Height => Grid.GetLength(0);
        public int Width => Grid.GetLength(1);
        #endregion

        #region Constructors
        public Map(string[] aGrid, Func<char, T> aParseFunction)
        {
            Grid = new T[aGrid.Length, aGrid[0].Length];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    this[x, y] = aParseFunction(aGrid[y][x]);
                }
            }
        }

        public Map(int aHeight, int aWidth, T aInitialValue)
        {
            Grid = new T[aHeight, aWidth];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    this[x, y] = aInitialValue;
                }
            }
        }
        #endregion

        #region Methods
        public int Count()
        {
            return Count(x => x != null && x.Equals(true));
        }

        public int Count(Func<T, bool> aFilter)
        {
            int count = 0;
            foreach (T item in Grid)
            {
                count += aFilter(item) ? 1 : 0;
            }

            return count;
        }

        public Coordinate? Find(T aValue)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (this[x, y]?.Equals(aValue) ?? false)
                    {
                        return new(x, y);
                    }
                }
            }

            return null;
        }

        public Coordinate? First(T[] aValues)
        {
            foreach (T value in aValues)
            {
                Coordinate? location = Find(value);
                if (location != null)
                {
                    return location;
                }
            }

            return null;
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

        public void IterateColumnsRows(Action<Coordinate> aIteratorCallback, Func<Coordinate, bool>? aFilter = null)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Coordinate coordinate = new(x, y);
                    if (aFilter == null || aFilter(coordinate))
                    {
                        aIteratorCallback(coordinate);
                    }
                }
            }
        }

        public override string ToString()
        {
            string output = "";
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    output += this[x, y]?.ToString() ?? " ";
                }
                output += '\n';
            }

            return output;
        }
        #endregion

        #region Operators
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
                for (int i = 0; i < aCoordinates.Length; i++)
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
        #endregion

        #region Functions
        public static Map<char> GetCharacterMap(string[] aGrid)
        {
            return new(aGrid, x => x);
        }
        #endregion
    }
}
