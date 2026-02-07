using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public async Task Y2025_D10_Part1_Example()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}",
                "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}",
                "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public async Task Y2025_D10_Part2_Example()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}",
                "[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}",
                "[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("33", result);
        }

        [TestMethod]
        public async Task Y2025_D10_Part1_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("425", result);
        }

        [TestMethod, Ignore]
        public async Task Y2025_D10_Part2_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
