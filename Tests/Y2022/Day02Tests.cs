using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public async Task Y2022_D02_Part1_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                "A Y",
                "B X",
                "C Z",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("15", result);
        }

        [TestMethod]
        public async Task Y2022_D02_Part2_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                "A Y",
                "B X",
                "C Z",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("12", result);
        }

        [TestMethod]
        public async Task Y2022_D02_Part1_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("10816", result);
        }

        [TestMethod]
        public async Task Y2022_D02_Part2_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("11657", result);
        }
    }
}
