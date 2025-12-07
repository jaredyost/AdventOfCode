using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public async Task Y2025_D04_Part1_Example()
        {
            // Arrange
            Day04 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "..@@.@@@@.",
                "@@@.@.@.@@",
                "@@@@@.@.@@",
                "@.@@@@..@.",
                "@@.@@@@.@@",
                ".@@@@@@@.@",
                ".@.@.@.@@@",
                "@.@@@.@@@@",
                ".@@@@@@@@.",
                "@.@.@@@.@.",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("13", result);
        }

        [TestMethod]
        public async Task Y2025_D04_Part2_Example()
        {
            // Arrange
            Day04 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "..@@.@@@@.",
                "@@@.@.@.@@",
                "@@@@@.@.@@",
                "@.@@@@..@.",
                "@@.@@@@.@@",
                ".@@@@@@@.@",
                ".@.@.@.@@@",
                "@.@@@.@@@@",
                ".@@@@@@@@.",
                "@.@.@@@.@.",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("43", result);
        }

        [TestMethod]
        public async Task Y2025_D04_Part1_Real()
        {
            // Arrange
            Day04 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1543", result);
        }

        [TestMethod]
        public async Task Y2025_D04_Part2_Real()
        {
            // Arrange
            Day04 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("9038", result);
        }
    }
}
