using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public async Task Y2024_D11_Part1_Example()
        {
            // Arrange
            Day11 solver = new();
            string[] TestInput =
            [
                "125 17",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("55312", result);
        }

        [TestMethod]
        public async Task Y2024_D11_Part1_Real()
        {
            // Arrange
            Day11 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("199982", result);
        }

        [TestMethod]
        public async Task Y2024_D11_Part2_Real()
        {
            // Arrange
            Day11 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("237149922829154", result);
        }
    }
}
