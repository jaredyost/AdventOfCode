using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day02Tests
    {
        [TestMethod]
        public async Task Y2025_D02_Part1_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224, 1698522-1698528,446443-446449,38593856-38593862,565653-565659, 824824821-824824827,2121212118-2121212124",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("1227775554", result);
        }

        [TestMethod]
        public async Task Y2025_D02_Part2_Example()
        {
            // Arrange
            Day02 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "11-22,95-115,998-1012,1188511880-1188511890,222220-222224, 1698522-1698528,446443-446449,38593856-38593862,565653-565659, 824824821-824824827,2121212118-2121212124",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("4174379265", result);
        }

        [TestMethod]
        public async Task Y2025_D02_Part1_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("23534117921", result);
        }

        [TestMethod]
        public async Task Y2025_D02_Part2_Real()
        {
            // Arrange
            Day02 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("31755323497", result);
        }
    }
}
