using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day11Tests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            Day11 solver = new();
            string[] TestInput =
            [
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#.....",
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("374", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            Day11 solver = new();
            string[] TestInput =
            [
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#.....",
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("82000210", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day11 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("9556712", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day11 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("678626199476", result);
        }
    }
}
