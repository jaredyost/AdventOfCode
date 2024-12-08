using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day04Tests
    {
        [TestMethod]
        public async Task Y2022_D04_Part1_Example()
        {
            // Arrange
            Day04 solver = new();
            string[] TestInput =
            [
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2022_D04_Part2_Example()
        {
            // Arrange
            Day04 solver = new();
            string[] TestInput =
            [
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public async Task Y2022_D04_Part1_Real()
        {
            // Arrange
            Day04 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("556", result);
        }

        [TestMethod]
        public async Task Y2022_D04_Part2_Real()
        {
            // Arrange
            Day04 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("876", result);
        }
    }
}
