using AdventOfCode.Core.Helpers.Mapping;
using System.Text.RegularExpressions;

#if DEBUG
using System.Diagnostics;
#endif

namespace AdventOfCode.Solvers.Y2024
{
    public partial class Day14(int aWidth, int aHeight) : BaseDay2024
    {
        protected override int Day => 14;

        public Day14() : this(101, 103) {}

        private readonly Coordinate Room = new(aWidth, aHeight);

        private class Robot(Coordinate aPosition, Coordinate aVelocity)
        {
            public Coordinate Position { get; set; } = aPosition;
            public Coordinate Velocity { get; set; } = aVelocity;

            public void Move(Coordinate aRoom)
            {
                Position.X = (Position.X + aRoom.X + Velocity.X) % aRoom.X;
                Position.Y = (Position.Y + aRoom.Y + Velocity.Y) % aRoom.Y;
            }
        }

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            List<Robot> robots = GetRobots(aInput);
            for (int i = 0; i < 100; i++)
            {
                robots.ForEach(x => x.Move(Room));
            }

            return new(CalculateSafetyScore(robots).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<Robot> robots = GetRobots(aInput);
            Tuple<int, int> minimum = new(int.MaxValue, int.MinValue);
            for (int i = 0; i < 10000; i++)
            {
                robots.ForEach(x => x.Move(Room));
                int safetyScore = CalculateSafetyScore(robots);
                if (safetyScore < minimum.Item1)
                {
                    minimum = new(safetyScore, i);
                }
            }

#if DEBUG
            // Print out the map in debug mode
            robots = GetRobots(aInput);
            for (int i = 0; i <= minimum.Item2; i++)
            {
                robots.ForEach(x => x.Move(Room));
            }

            Map<char> map = new(Room.Y, Room.X, '.');
            foreach (Robot robot in robots)
            {
                map[robot.Position] = '#';
            }
            Debug.WriteLine(map);
#endif

            return new((minimum.Item2 + 1).ToString());
        }

        [GeneratedRegex(@"p=(?<px>[0-9]+),(?<py>[0-9]+) v=(?<vx>-?[0-9]+),(?<vy>-?[0-9]+)", RegexOptions.Compiled)]
        private static partial Regex RobotRegex();

        private static List<Robot> GetRobots(string[] aInformation)
        {
            List<Robot> robots = [];
            foreach (Match match in RobotRegex().Matches(string.Join('\n', aInformation)))
            {
                robots.Add(new(new(match.Groups["px"].Value, match.Groups["py"].Value),
                                new(match.Groups["vx"].Value, match.Groups["vy"].Value)));
            }

            return robots;
        }

        private int CalculateSafetyScore(List<Robot> aRobots)
        {
            int[,] quadrants = { { 0, 0 }, { 0, 0 } };
            foreach (Robot robot in aRobots)
            {
                if (robot.Position.X == Room.X / 2 || robot.Position.Y == Room.Y / 2)
                {
                    continue;
                }

                int x = Convert.ToInt32(robot.Position.X > Room.X / 2);
                int y = Convert.ToInt32(robot.Position.Y > Room.Y / 2);
                quadrants[y, x]++;
            }

            return quadrants[0, 0] * quadrants[0, 1] * quadrants[1, 0] * quadrants[1, 1];
        }
    }
}
