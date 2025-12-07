using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod, Ignore]
        public async Task Y2022_D10_Part1_Example()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D10_Part2_Example()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D10_Part1_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D10_Part2_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
