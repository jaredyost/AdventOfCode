using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public async Task Y2024_D01_Part1_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("11", result);
        }

        [TestMethod]
        public async Task Y2024_D01_Part2_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("31", result);
        }

        [TestMethod]
        public async Task Y2024_D01_Part1_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1938424", result);
        }

        [TestMethod]
        public async Task Y2024_D01_Part2_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("22014209", result);
        }
    }
}
