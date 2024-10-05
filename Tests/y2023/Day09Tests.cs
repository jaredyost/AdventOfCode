using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public async Task Y2023_D09_Part1_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("114", result);
        }

        [TestMethod]
        public async Task Y2023_D09_Part2_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2023_D09_Part1_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1980437560", result);
        }

        [TestMethod]
        public async Task Y2023_D09_Part2_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("977", result);
        }
    }
}
