using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public async Task Y2022_D01_Part1_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("24000", result);
        }

        [TestMethod]
        public async Task Y2022_D01_Part2_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                "1000",
                "2000",
                "3000",
                "",
                "4000",
                "",
                "5000",
                "6000",
                "",
                "7000",
                "8000",
                "9000",
                "",
                "10000",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("45000", result);
        }

        [TestMethod]
        public async Task Y2022_D01_Part1_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("68787", result);
        }

        [TestMethod]
        public async Task Y2022_D01_Part2_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("198041", result);
        }
    }
}
