using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public async Task Part1Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "Time:      7  15   30",
                "Distance:  9  40  200",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("288", result);
        }

        [TestMethod]
        public async Task Part2Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "Time:      7  15   30",
                "Distance:  9  40  200",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("71503", result);
        }

        [TestMethod]
        public async Task Part1Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("275724", result);
        }

        [TestMethod]
        public async Task Part2Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("37286485", result);
        }
    }
}
