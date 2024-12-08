using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public async Task Y2024_D04_Part1_Example()
        {
            // Arrange
            Day04 solver = new();
            string[] TestInput =
            [
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("18", result);
        }

        [TestMethod]
        public async Task Y2024_D04_Part2_Example()
        {
            // Arrange
            Day04 solver = new();
            string[] TestInput =
            [
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("9", result);
        }

        [TestMethod]
        public async Task Y2024_D04_Part1_Real()
        {
            // Arrange
            Day04 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("2434", result);
        }

        [TestMethod]
        public async Task Y2024_D04_Part2_Real()
        {
            // Arrange
            Day04 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1835", result);
        }
    }
}
