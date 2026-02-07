namespace AdventOfCode.Core.Helpers.Extensions
{
    public static class ListExtensions
    {
        extension<T>(List<T> aSource)
        {
            public List<T> Sorted() => Sorted(aSource, 0, aSource.Count, null);

            public List<T> Sorted(IComparer<T>? aComparer) =>
                Sorted(aSource, 0, aSource.Count, aComparer);

            public List<T> Sorted(int aIndex, int aCount, IComparer<T>? aComparer)
            {
                aSource.Sort(aIndex, aCount, aComparer);
                return aSource;
            }

            public List<T> Sorted(Comparison<T> aComparison)
            {
                aSource.Sort(aComparison);
                return aSource;
            }
        }
    }
}
