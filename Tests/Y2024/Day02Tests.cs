using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public async Task Y2024_D02_Part1_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2024_D02_Part2_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public async Task Y2024_D02_Part1_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("371", result);
        }

        [TestMethod]
        public async Task Y2024_D02_Part2_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("426", result);
        }
    }
}
