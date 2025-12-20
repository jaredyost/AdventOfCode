namespace AdventOfCode.Core.Helpers
{
    public class UnorderedPair<T>(T aItem1, T aItem2)
        where T : notnull
    {
        #region Properties
        public T Item1 { get; set; } = aItem1;
        public T Item2 { get; set; } = aItem2;
        #endregion

        #region Methods
        public override bool Equals(object? aOther)
        {
            return aOther is UnorderedPair<T> && Equals(aOther);
        }

        public bool Equals(UnorderedPair<T>? aOther)
        {
            return aOther is not null
                && (
                    (Item1.Equals(aOther.Item1) && Item2.Equals(aOther.Item2))
                    || (Item1.Equals(aOther.Item2) && Item2.Equals(aOther.Item1))
                );
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Item1, Item2);
        }

        public override string ToString()
        {
            return $"{{ Item1 = {Item1}, Item2 = {Item2} }}";
        }
        #endregion

        #region Operators
        public static bool operator ==(UnorderedPair<T>? aFirst, UnorderedPair<T>? aSecond)
        {
            return aFirst?.Equals(aSecond) ?? aSecond?.Equals(aFirst) ?? false;
        }

        public static bool operator !=(UnorderedPair<T>? aFirst, UnorderedPair<T>? aSecond)
        {
            return !(aFirst == aSecond);
        }
        #endregion
    }
}
