using AdventOfCode.Solvers.Y2020;

namespace AdventOfCode.Tests.Y2020
{
    [TestClass]
    public class Day03Tests
    {
        [TestMethod]
        public async Task Y2020_D03_Part1_Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public async Task Y2020_D03_Part2_Example()
        {
            // Arrange
            Day03 solver = new();
            string[] TestInput =
            [
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("336", result);
        }

        [TestMethod]
        public async Task Y2020_D03_Part1_Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("203", result);
        }

        [TestMethod]
        public async Task Y2020_D03_Part2_Real()
        {
            // Arrange
            Day03 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("3316272960", result);
        }
    }
}
