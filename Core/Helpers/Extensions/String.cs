namespace AdventOfCode.Core.Helpers.Extensions
{
    public static class StringExtensions
    {
        extension(string aSource)
        {
            public string Replace(int aIndex, char aCharacter)
            {
                if (aIndex >= aSource.Length)
                {
                    throw new ArgumentException("Index is outside the string!", nameof(aIndex));
                }

                char[] characters = aSource.ToCharArray();
                characters[aIndex] = aCharacter;
                aSource = string.Join("", characters);

                return aSource;
            }
        }
    }
}
