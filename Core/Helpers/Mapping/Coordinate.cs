namespace AdventOfCode.Core.Helpers.Mapping
{
    public class Coordinate(int aX, int aY) : IEquatable<Coordinate>
    {
        #region Properties
        public int X { get; set; } = aX;
        public int Y { get; set; } = aY;
        #endregion

        #region Methods
        public override bool Equals(object? aOther)
        {
            return aOther is Coordinate || Equals(aOther);
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

        public static bool operator ==(Coordinate? aFirst, Coordinate? aSecond)
        {
            return aFirst?.Equals(aSecond) ?? aSecond?.Equals(aFirst) ?? false;
        }

        public static bool operator !=(Coordinate? aFirst, Coordinate? aSecond)
        {
            return !(aFirst == aSecond);
        }
        #endregion
    }
}
