namespace AdventOfCode.Core.Helpers.Comparers
{
    public sealed class IntArrayComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[]? aFirst, int[]? aSecond)
        {
            if (ReferenceEquals(aFirst, aSecond))
            {
                return true;
            }

            if (aFirst is null || aSecond is null || aFirst.Length != aSecond.Length)
            {
                return false;
            }

            bool equal = true;
            for (int i = 0; i < aFirst.Length && equal; i++)
            {
                equal = aFirst[i] == aSecond[i];
            }

            return equal;
        }

        public int GetHashCode(int[] aArray)
        {
            int hash = 17;
            for (int i = 0; i < aArray.Length; i++)
            {
                hash = hash * 31 + aArray[i];
            }

            return hash;
        }
    }
}
