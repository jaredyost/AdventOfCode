using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public async Task Y2024_D08_Part1_Example1()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "..........",
                "..........",
                "..........",
                "....a.....",
                "..........",
                ".....a....",
                "..........",
                "..........",
                "..........",
                "..........",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2024_D08_Part1_Example2()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "..........",
                "..........",
                "..........",
                "....a.....",
                "........a.",
                ".....a....",
                "..........",
                "..........",
                "..........",
                "..........",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public async Task Y2024_D08_Part1_Example3()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "..........",
                "..........",
                "..........",
                "....a.....",
                "........a.",
                ".....a....",
                "..........",
                "......A...",
                "..........",
                "..........",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public async Task Y2024_D08_Part1_Example4()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "............",
                "........0...",
                ".....0......",
                ".......0....",
                "....0.......",
                "......A.....",
                "............",
                "............",
                "........A...",
                ".........A..",
                "............",
                "............",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("14", result);
        }

        [TestMethod]
        public async Task Y2024_D08_Part2_Example1()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "T.........",
                "...T......",
                ".T........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("9", result);
        }

        [TestMethod]
        public async Task Y2024_D08_Part2_Example2()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "............",
                "........0...",
                ".....0......",
                ".......0....",
                "....0.......",
                "......A.....",
                "............",
                "............",
                "........A...",
                ".........A..",
                "............",
                "............",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("34", result);
        }

        [TestMethod]
        public async Task Y2024_D08_Part1_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("293", result);
        }

        [TestMethod]
        public async Task Y2024_D08_Part2_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("934", result);
        }
    }
}
