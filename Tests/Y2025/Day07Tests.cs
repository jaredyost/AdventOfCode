using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day07Tests
    {
        [TestMethod]
        public async Task Y2025_D07_Part1_Example()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                ".......S.......",
                "...............",
                ".......^.......",
                "...............",
                "......^.^......",
                "...............",
                ".....^.^.^.....",
                "...............",
                "....^.^...^....",
                "...............",
                "...^.^...^.^...",
                "...............",
                "..^...^.....^..",
                "...............",
                ".^.^.^.^.^...^.",
                "...............",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("21", result);
        }

        [TestMethod]
        public async Task Y2025_D07_Part2_Example1()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                ".......S.......",
                "...............",
                ".......^.......",
                "...............",
                "......^.^......",
                "...............",
                ".....^.^.^.....",
                "...............",
                "....^.^...^....",
                "...............",
                "...^.^...^.^...",
                "...............",
                "..^...^.....^..",
                "...............",
                ".^.^.^.^.^...^.",
                "...............",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("40", result);
        }

        [TestMethod]
        public async Task Y2025_D07_Part2_Example2()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "..S..",
                ".....",
                "..^..",
                ".....",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2025_D07_Part2_Example3()
        {
            // Arrange
            Day07 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "..S..",
                ".....",
                "..^..",
                ".....",
                ".^.^.",
                ".....",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public async Task Y2025_D07_Part1_Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1537", result);
        }

        [TestMethod]
        public async Task Y2025_D07_Part2_Real()
        {
            // Arrange
            Day07 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("18818811755665", result);
        }
    }
}
