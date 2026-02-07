namespace AdventOfCode.Core.Helpers.Utilities
{
    public class Math
    {
        #region Functions
        public static bool InRange(int aValue, int aBoundary1, int aBoundary2)
        {
            return aValue >= System.Math.Min(aBoundary1, aBoundary2)
                && aValue <= System.Math.Max(aBoundary1, aBoundary2);
        }

        public static bool SameSigns(int aValue1, int aValue2)
        {
            return aValue1 * aValue2 > 0;
        }
        #endregion
    }
}
