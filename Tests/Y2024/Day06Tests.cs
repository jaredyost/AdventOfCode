using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public async Task Y2024_D06_Part1_Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "....#.....",
                ".........#",
                "..........",
                "..#.......",
                ".......#..",
                "..........",
                ".#..^.....",
                "........#.",
                "#.........",
                "......#...",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("41", result);
        }

        [TestMethod]
        public async Task Y2024_D06_Part2_Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "....#.....",
                ".........#",
                "..........",
                "..#.......",
                ".......#..",
                "..........",
                ".#..^.....",
                "........#.",
                "#.........",
                "......#...",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("6", result);
        }

        [TestMethod]
        public async Task Y2024_D06_Part1_Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("5030", result);
        }

        [TestMethod]
        public async Task Y2024_D06_Part2_Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1928", result);
        }
    }
}
