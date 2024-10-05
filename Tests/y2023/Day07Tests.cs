using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod]
        public async Task Part1Example()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("6440", result);
        }

        [TestMethod]
        public async Task Part2Example()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                "32T3K 765",
                "T55J5 684",
                "KK677 28",
                "KTJJT 220",
                "QQQJA 483",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("5905", result);
        }

        [TestMethod]
        public async Task Part1Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("250254244", result);
        }

        [TestMethod]
        public async Task Part2Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("250087440", result);
        }
    }
}
