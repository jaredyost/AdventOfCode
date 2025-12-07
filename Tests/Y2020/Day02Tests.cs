using AdventOfCode.Solvers.Y2020;

namespace AdventOfCode.Tests.Y2020
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public async Task Y2020_D02_Part1_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2020_D02_Part2_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "1-3 a: abcde",
                "1-3 b: cdefg",
                "2-9 c: ccccccccc",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public async Task Y2020_D02_Part1_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("418", result);
        }

        [TestMethod]
        public async Task Y2020_D02_Part2_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("616", result);
        }
    }
}
