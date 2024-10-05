using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public async Task Y2023_D12_Part1_Example()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                "???.### 1,1,3",
                ".??..??...?##. 1,1,3",
                "?#?#?#?#?#?#?#? 1,3,1,6",
                "????.#...#... 4,1,1",
                "????.######..#####. 1,6,5",
                "?###???????? 3,2,1",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("21", result);
        }

        [TestMethod]
        public async Task Y2023_D12_Part2_Example()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                "???.### 1,1,3",
                ".??..??...?##. 1,1,3",
                "?#?#?#?#?#?#?#? 1,3,1,6",
                "????.#...#... 4,1,1",
                "????.######..#####. 1,6,5",
                "?###???????? 3,2,1",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("525152", result);
        }

        [TestMethod]
        public async Task Y2023_D12_Part1_Real()
        {
            // Arrange
            Day12 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("7361", result);
        }

        [TestMethod]
        public async Task Y2023_D12_Part2_Real()
        {
            // Arrange
            Day12 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("83317216247365", result);
        }
    }
}
