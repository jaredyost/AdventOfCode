using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public async Task Y2024_D09_Part1_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                "2333133121414131402",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("1928", result);
        }

        [TestMethod]
        public async Task Y2024_D09_Part2_Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                "2333133121414131402",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("2858", result);
        }

        [TestMethod]
        public async Task Y2024_D09_Part1_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("6367087064415", result);
        }

        [TestMethod]
        public async Task Y2024_D09_Part2_Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("6390781891880", result);
        }
    }
}
