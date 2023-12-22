using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod]
        public void TestPart1Example()
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
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("6440", result);
        }

        [TestMethod]
        public void TestPart2Example()
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
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("5905", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("250254244", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("250087440", result);
        }
    }
}
