using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public async Task Y2025_D09_Part1_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "7,1",
                "11,1",
                "11,7",
                "9,7",
                "9,5",
                "2,5",
                "2,3",
                "7,3",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("50", result);
        }

        [TestMethod]
        public async Task Y2025_D09_Part2_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "7,1",
                "11,1",
                "11,7",
                "9,7",
                "9,5",
                "2,5",
                "2,3",
                "7,3",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("24", result);
        }

        [TestMethod]
        public async Task Y2025_D09_Part1_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("4777824480", result);
        }

        [TestMethod]
        public async Task Y2025_D09_Part2_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1542119040", result);
        }
    }
}
