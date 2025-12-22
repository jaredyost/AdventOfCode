namespace AdventOfCode.Core.Helpers.Extensions
{
    public static class LinkedListExtensions
    {
        extension<T>(LinkedList<T> aSource)
        {
            public void JoinAfter(LinkedListNode<T> aNode, LinkedList<T> aLinkedList)
            {
                ArgumentNullException.ThrowIfNull(aNode);
                if (!aSource.Contains(aNode.Value))
                {
                    throw new InvalidOperationException();
                }

                LinkedListNode<T> lastNode = aNode;
                foreach (T value in aLinkedList)
                {
                    lastNode = aSource.AddAfter(lastNode, value);
                }
            }
        }
    }
}
