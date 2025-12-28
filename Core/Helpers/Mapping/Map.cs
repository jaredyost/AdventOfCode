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

        public bool IsCoordinateOnOrInsideShape(Coordinate aCoordinate, T aOutlineValue)
        {
            // Utilize ray tracing to count the number of intersections. An odd number means the
            // shape is inside (or on) the outline, and an even number means it lies outside the
            // outline.
            int horizontalIntersections = 0;
            for (int x = 0; x <= aCoordinate.X; x++)
            {
                if (this[x, aCoordinate.Y]?.Equals(aOutlineValue) ?? false)
                {
                    Coordinate up = new(aCoordinate.X, aCoordinate.Y - 1);
                    bool isUpOutline =
                        IsValidCoordinate(up) && (this[up]?.Equals(aOutlineValue) ?? false);

                    Coordinate down = new(aCoordinate.X, aCoordinate.Y + 1);
                    bool isDownOutline =
                        IsValidCoordinate(down) && (this[down]?.Equals(aOutlineValue) ?? false);

                    if (isUpOutline || isDownOutline)
                    {
                        return true;
                    }

                    horizontalIntersections++;
                }
            }

            int verticalIntersections = 0;
            for (int y = 0; y <= aCoordinate.Y; y++)
            {
                if (this[aCoordinate.X, y]?.Equals(aOutlineValue) ?? false)
                {
                    Coordinate left = new(aCoordinate.X - 1, aCoordinate.Y);
                    bool isLeftOutline =
                        IsValidCoordinate(left) && (this[left]?.Equals(aOutlineValue) ?? false);

                    Coordinate right = new(aCoordinate.X + 1, aCoordinate.Y);
                    bool isRightOutline =
                        IsValidCoordinate(right) && (this[right]?.Equals(aOutlineValue) ?? false);

                    if (isLeftOutline || isRightOutline)
                    {
                        return true;
                    }

                    verticalIntersections++;
                }
            }

            return (horizontalIntersections % 2 != 0) && (verticalIntersections % 2 != 0);
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
