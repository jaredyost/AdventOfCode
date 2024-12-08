namespace AdventOfCode.Core.Helpers
{
    public class MathUtilities
    {
        #region Functions
        public static bool InRange(int aValue, int aBoundary1, int aBoundary2)
        {
            return aValue >= Math.Min(aBoundary1, aBoundary2)
                    && aValue <= Math.Max(aBoundary1, aBoundary2);
        }

        public static bool SameSigns(int aValue1, int aValue2)
        {
            return aValue1 * aValue2 > 0;
        }
        #endregion
    }
}
