using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod, Ignore]
        public async Task Y2022_D01_Part1_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D01_Part2_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D01_Part1_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D01_Part2_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
