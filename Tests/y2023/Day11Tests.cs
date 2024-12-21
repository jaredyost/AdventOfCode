using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public async Task Y2023_D11_Part1_Example()
        {
            // Arrange
            Day11 solver = new();
            string[] TestInput =
            [
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#.....",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("374", result);
        }

        [TestMethod]
        public async Task Y2023_D11_Part2_Example()
        {
            // Arrange
            Day11 solver = new();
            string[] TestInput =
            [
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#.....",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("82000210", result);
        }

        [TestMethod]
        public async Task Y2023_D11_Part1_Real()
        {
            // Arrange
            Day11 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("9556712", result);
        }

        [TestMethod]
        public async Task Y2023_D11_Part2_Real()
        {
            // Arrange
            Day11 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("678626199476", result);
        }
    }
}
