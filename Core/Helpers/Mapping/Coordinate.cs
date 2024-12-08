namespace AdventOfCode.Core.Helpers.Mapping
{
    public class Coordinate(int aX, int aY)
    {
        #region Properties
        public int X { get; set; } = aX;
        public int Y { get; set; } = aY;
        #endregion

        #region Methods
        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }

        public override bool Equals(object? aOther)
        {
            if (aOther == null || aOther is not Coordinate)
            {
                return false;
            }

            Coordinate other = (aOther as Coordinate)!;
            return X == other.X && Y == other.Y;
        }
        #endregion

        #region Operators
        public static Coordinate operator +(Coordinate aFirst, Coordinate aSecond)
        {
            return new(aFirst.X + aSecond.X, aFirst.Y + aSecond.Y);
        }
        #endregion
    }
}
