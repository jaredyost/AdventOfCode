using AdventOfCode.Solvers.Y2020;

namespace AdventOfCode.Tests.Y2020
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public async Task Y2020_D01_Part1_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "1721",
                "979",
                "366",
                "299",
                "675",
                "1456",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("514579", result);
        }

        [TestMethod]
        public async Task Y2020_D01_Part2_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "1721",
                "979",
                "366",
                "299",
                "675",

                "1456",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("241861950", result);
        }

        [TestMethod]
        public async Task Y2020_D01_Part1_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("989824", result);
        }

        [TestMethod]
        public async Task Y2020_D01_Part2_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("66432240", result);
        }
    }
}
