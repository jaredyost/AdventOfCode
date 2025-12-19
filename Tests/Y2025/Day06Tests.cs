using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public async Task Y2025_D06_Part1_Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "123 328  51 64 ",
                " 45 64  387 23 ",
                "  6 98  215 314",
                "*   +   *   +  ",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("4277556", result);
        }

        [TestMethod]
        public async Task Y2025_D06_Part2_Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "123 328  51 64 ",
                " 45 64  387 23 ",
                "  6 98  215 314",
                "*   +   *   +  ",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("3263827", result);
        }

        [TestMethod]
        public async Task Y2025_D06_Part1_Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("4412382293768", result);
        }

        [TestMethod]
        public async Task Y2025_D06_Part2_Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("7858808482092", result);
        }
    }
}
