using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod]
        public async Task Y2024_D07_Part1_Example()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                "190: 10 19",
                "3267: 81 40 27",
                "83: 17 5",
                "156: 15 6",
                "7290: 6 8 6 15",
                "161011: 16 10 13",
                "192: 17 8 14",
                "21037: 9 7 18 13",
                "292: 11 6 16 20",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("3749", result);
        }

        [TestMethod]
        public async Task Y2024_D07_Part2_Example()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                "190: 10 19",
                "3267: 81 40 27",
                "83: 17 5",
                "156: 15 6",
                "7290: 6 8 6 15",
                "161011: 16 10 13",
                "192: 17 8 14",
                "21037: 9 7 18 13",
                "292: 11 6 16 20",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("11387", result);
        }

        [TestMethod]
        public async Task Y2024_D07_Part1_Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("5540634308362", result);
        }

        [TestMethod]
        public async Task Y2024_D07_Part2_Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("472290821152397", result);
        }
    }
}
