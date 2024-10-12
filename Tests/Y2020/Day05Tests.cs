using AdventOfCode.Solvers.Y2020;

namespace AdventOfCode.Tests.Y2020
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public async Task Y2020_D05_Part1_Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                "FBFBBFFRLR",
                "BFFFBBFRRR",
                "FFFBBBFRRR",
                "BBFFBBFRLL",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("820", result);
        }

        [TestMethod]
        public async Task Y2020_D05_Part1_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("944", result);
        }

        [TestMethod]
        public async Task Y2020_D05_Part2_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("554", result);
        }
    }
}
