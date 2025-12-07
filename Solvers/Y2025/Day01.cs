namespace AdventOfCode.Solvers.Y2025
{
    public class Day01 : BaseDay2025
    {
        protected override int Day => 1;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int zeroCount = 0;

            int dial = 50;
            foreach (string instruction in aInput)
            {
                dial += 100;
                dial += (instruction[0] == 'L' ? -1 : 1) * int.Parse(instruction[1..]);
                dial %= 100;

                if (dial == 0)
                {
                    zeroCount++;
                }
            }

            return new(zeroCount.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int zeroCount = 0;

            int dial = 50;
            foreach (string instruction in aInput)
            {
                int clicks = (instruction[0] == 'L' ? -1 : 1) * int.Parse(instruction[1..]);
                int partialTurn = clicks;
                if (clicks < 0)
                {
                    zeroCount += Math.DivRem(clicks, -100, out partialTurn);
                    if (dial != 0 && dial + partialTurn <= 0)
                    {
                        zeroCount++;
                    }
                }
                else
                {
                    zeroCount += Math.DivRem(clicks, 100, out partialTurn);
                    if (dial + partialTurn >= 100)
                    {
                        zeroCount++;
                    }
                }

                dial = (dial + partialTurn + 100) % 100;
            }

            return new(zeroCount.ToString());
        }
    }
}
