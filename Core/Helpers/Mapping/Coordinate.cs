namespace AdventOfCode.Core.Helpers.Mapping
{
    public class Coordinate(int aX, int aY) : IEquatable<Coordinate>
    {
        #region Properties
        public int X { get; set; } = aX;
        public int Y { get; set; } = aY;
        #endregion

        #region Constructors
        public Coordinate(string aX, string aY)
            : this(int.Parse(aX), int.Parse(aY)) { }
        #endregion

        #region Methods
        public override bool Equals(object? aOther)
        {
            return aOther is Coordinate && Equals(aOther);
        }

        public bool Equals(Coordinate? aOther)
        {
            return aOther is not null && X == aOther.X && Y == aOther.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        #endregion

        #region Operators
        public static Coordinate operator +(Coordinate aFirst, Coordinate aSecond)
        {
            return new(aFirst.X + aSecond.X, aFirst.Y + aSecond.Y);
        }

        public static Coordinate operator -(Coordinate aFirst, Coordinate aSecond)
        {
            return new(aFirst.X - aSecond.X, aFirst.Y - aSecond.Y);
        }

        public static Coordinate operator *(int aMultiplier, Coordinate aCoordinate)
        {
            return new(aCoordinate.X * aMultiplier, aCoordinate.Y * aMultiplier);
        }

        public static Coordinate operator *(Coordinate aCoordinate, int aMultiplier)
        {
            return aMultiplier * aCoordinate;
        }

        public static bool operator ==(Coordinate? aFirst, Coordinate? aSecond)
        {
            return aFirst?.Equals(aSecond) ?? aSecond?.Equals(aFirst) ?? false;
        }

        public static bool operator !=(Coordinate? aFirst, Coordinate? aSecond)
        {
            return !(aFirst == aSecond);
        }
        #endregion

        #region Functions
        public static Coordinate[] GetCrossNeighbors(Coordinate aCoordinate)
        {
            return
            [
                new(aCoordinate.X - 1, aCoordinate.Y),
                new(aCoordinate.X + 1, aCoordinate.Y),
                new(aCoordinate.X, aCoordinate.Y - 1),
                new(aCoordinate.X, aCoordinate.Y + 1),
            ];
        }

        public static Coordinate[] GetDiagonalNeighbors(Coordinate aCoordinate)
        {
            return
            [
                new(aCoordinate.X - 1, aCoordinate.Y - 1),
                new(aCoordinate.X + 1, aCoordinate.Y - 1),
                new(aCoordinate.X - 1, aCoordinate.Y + 1),
                new(aCoordinate.X + 1, aCoordinate.Y + 1),
            ];
        }

        public static Coordinate[] GetAllNeighbors(Coordinate aCoordinate)
        {
            return [.. GetCrossNeighbors(aCoordinate), .. GetDiagonalNeighbors(aCoordinate)];
        }
        #endregion
    }
}
