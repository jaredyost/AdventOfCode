namespace AdventOfCode.Core.Helpers.Mapping
{
    public class Coordinate(int aX, int aY)
    {
        public int X { get; set; } = aX;
        public int Y { get; set; } = aY;
    }
}
