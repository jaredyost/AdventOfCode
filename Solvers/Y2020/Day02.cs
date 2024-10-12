namespace AdventOfCode.Solvers.Y2020
{
    public class Day02 : BaseDay2020
    {
        protected override int Day => 2;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            int numValid = 0;
            foreach (string data in aInput)
            {
                string[] splitData = data.Split(':', StringSplitOptions.TrimEntries);
                string[] requirements = splitData[0].Split(' ');
                List<int> bounds = requirements[0].Split('-').Select(int.Parse).ToList();

                int count = 0;
                foreach (char character in splitData[1])
                {
                    if (character == requirements[1][0])
                    {
                        count++;
                    }
                }

                if (count >= bounds[0] && count <= bounds[1])
                {
                    numValid++;
                }
            }

            return new(numValid.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            int numValid = 0;
            foreach (string data in aInput)
            {
                string[] splitData = data.Split(':', StringSplitOptions.TrimEntries);
                string[] requirements = splitData[0].Split(' ');
                List<int> positions = requirements[0].Split('-').Select(int.Parse).ToList();

                bool inFirstPosition = splitData[1][positions[0] - 1] == requirements[1][0];
                bool inSecondPosition = splitData[1][positions[1] - 1] == requirements[1][0];
                if (inFirstPosition ^ inSecondPosition)
                {
                    numValid++;
                }
            }

            return new(numValid.ToString());
        }
    }
}
