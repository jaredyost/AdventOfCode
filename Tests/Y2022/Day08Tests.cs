using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod, Ignore]
        public async Task Y2022_D08_Part1_Example()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "30373",
                "25512",
                "65332",
                "33549",
                "35390",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("21", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D08_Part2_Example()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("8", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D08_Part1_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1684", result);
        }

        [TestMethod, Ignore]
        public async Task Y2022_D08_Part2_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("486540", result);
        }
    }
}
