namespace AdventOfCode.Core.Helpers.Mapping
{
    public class Map<T>
        where T : new()
    {
        #region Properties
        public List<List<T>> Grid { get; }
        public int Height => Grid.Count;
        public int Width => Grid[0].Count;
        #endregion

        #region Constructors
        public Map(string[] aGrid, Func<char, T> aParseFunction)
            : this(aGrid.Length, aGrid[0].Length, new T())
        {
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
            Grid = new List<List<T>>(aHeight);
            for (int y = 0; y < aHeight; y++)
            {
                Grid.Add(new List<T>(aWidth));
                for (int x = 0; x < aWidth; x++)
                {
                    Grid[y].Add(aInitialValue);
                }
            }
        }
        #endregion

        #region Methods
        public void AddOutline(Coordinate[] aCoordinates, T aOutlineValue)
        {
            // Fill in the vertical outlines of the red and green tiles
            Coordinate[] tiles = [.. aCoordinates.OrderBy(tile => tile.X).ThenBy(tile => tile.Y)];
            for (int i = 0; i < tiles.Length - 1; i++)
            {
                if (tiles[i].X == tiles[i + 1].X)
                {
                    for (int y = tiles[i].Y; y <= tiles[i + 1].Y; y++)
                    {
                        this[tiles[i].X, y] = aOutlineValue;
                    }
                }
            }

            // Fill in the horizontal outlines of the red and green tiles
            tiles = [.. aCoordinates.OrderBy(tile => tile.Y).ThenBy(tile => tile.X)];
            for (int i = 0; i < tiles.Length - 1; i++)
            {
                if (tiles[i].Y == tiles[i + 1].Y)
                {
                    for (int x = tiles[i].X; x <= tiles[i + 1].X; x++)
                    {
                        this[x, tiles[i].Y] = aOutlineValue;
                    }
                }
            }
        }

        public int Count()
        {
            return Count(x => x != null && x.Equals(true));
        }

        public int Count(Func<T, bool> aFilter)
        {
            int count = 0;
            foreach (List<T> row in Grid)
            {
                foreach (T item in row)
                {
                    count += aFilter(item) ? 1 : 0;
                }
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

        public void FloodFill(T aFloodValue, T? aEmptyValue)
        {
            Queue<Coordinate> queue = [];
            queue.Enqueue(new(0, 0));

            while (queue.TryDequeue(out Coordinate? coordinate))
            {
                if (this[coordinate]?.Equals(aEmptyValue) ?? true)
                {
                    this[coordinate] = aFloodValue;
                    foreach (Coordinate neighbor in Coordinate.GetCrossNeighbors(coordinate))
                    {
                        if (IsValidCoordinate(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
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
            return !aCoordinates.Any(x => !IsValidCoordinate(x));
        }

        public void IterateColumnsRows(
            Action<Coordinate> aIteratorCallback,
            Func<Coordinate, bool>? aFilter = null
        )
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
            get => Grid[aY][aX];
            set => Grid[aY][aX] = value;
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
