using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public async Task Y2025_D05_Part1_Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "3-5",
                "10-14",
                "16-20",
                "12-18",
                "",
                "1",
                "5",
                "8",
                "11",
                "17",
                "32",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public async Task Y2025_D05_Part2_Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "3-5",
                "10-14",
                "16-20",
                "12-18",
                "",
                "1",
                "5",
                "8",
                "11",
                "17",
                "32",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("14", result);
        }

        [TestMethod]
        public async Task Y2025_D05_Part1_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("623", result);
        }

        [TestMethod]
        public async Task Y2025_D05_Part2_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("353507173555373", result);
        }
    }
}
