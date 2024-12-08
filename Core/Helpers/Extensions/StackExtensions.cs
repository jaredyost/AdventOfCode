namespace AdventOfCode.Core.Helpers.Extensions
{
    public static class StackExtensions
    {
        public static List<T> PopMultiple<T>(this Stack<T> aStack, int aCount)
        {
            List<T> values = [];
            for (int i = 0; i < aCount && aStack.Count > 0; i++)
            {
                values.Add(aStack.Pop());
            }

            return values;
        }

        public static void PushMultiple<T>(this Stack<T> aStack, List<T> aValues)
        {
            for (int i = aValues.Count - 1; i >= 0; i--)
            {
                aStack.Push(aValues[i]);
            }
        }
    }
}
