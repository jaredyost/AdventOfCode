using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("4361", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("467835", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("535351", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("87287096", result);
        }
    }
}
