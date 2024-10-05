using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public async Task Y2023_D03_Part1_Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("4361", result);
        }

        [TestMethod]
        public async Task Y2023_D03_Part2_Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("467835", result);
        }

        [TestMethod]
        public async Task Y2023_D03_Part1_Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("535351", result);
        }

        [TestMethod]
        public async Task Y2023_D03_Part2_Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("87287096", result);
        }
    }
}
