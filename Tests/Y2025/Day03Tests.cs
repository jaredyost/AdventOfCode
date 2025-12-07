using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public async Task Y2025_D03_Part1_Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "987654321111111",
                "811111111111119",
                "234234234234278",
                "818181911112111",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("357", result);
        }

        [TestMethod]
        public async Task Y2025_D03_Part2_Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "987654321111111",
                "811111111111119",
                "234234234234278",
                "818181911112111",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("3121910778619", result);
        }

        [TestMethod]
        public async Task Y2025_D03_Part1_Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("17207", result);
        }

        [TestMethod]
        public async Task Y2025_D03_Part2_Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("170997883706617", result);
        }
    }
}
