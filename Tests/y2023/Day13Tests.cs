using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public async Task Y2023_D13_Part1_Example()
        {
            // Arrange
            Day13 solver = new();
            string[] TestInput =
            [
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#.",
                "",
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("405", result);
        }

        [TestMethod, Ignore]
        public async Task Y2023_D13_Part2_Example()
        {
            // Arrange
            Day13 solver = new();
            string[] TestInput =
            [
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#.",
                "",
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("400", result);
        }

        [TestMethod]
        public async Task Y2023_D13_Part1_Real()
        {
            // Arrange
            Day13 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("33780", result);
        }

        [TestMethod, Ignore]
        public async Task Y2023_D13_Part2_Real()
        {
            // Arrange
            Day13 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
