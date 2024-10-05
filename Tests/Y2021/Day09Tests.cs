using AdventOfCode.Solvers.Y2021;

namespace AdventOfCode.Tests.Y2021
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod, Ignore]
        public async Task Y2021_D09_Part1_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2021_D09_Part2_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2021_D09_Part1_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2021_D09_Part2_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
