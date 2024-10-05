using AdventOfCode.Solvers.Y2021;

namespace AdventOfCode.Tests.Y2021
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod, Ignore]
        public async Task Y2021_D07_Part1_Example()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2021_D07_Part2_Example()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2021_D07_Part1_Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2021_D07_Part2_Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
