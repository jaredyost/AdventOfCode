using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public async Task Y2023_D08_Part1_Example1()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "RL",
                "",
                "AAA = (BBB, CCC)",
                "BBB = (DDD, EEE)",
                "CCC = (ZZZ, GGG)",
                "DDD = (DDD, DDD)",
                "EEE = (EEE, EEE)",
                "GGG = (GGG, GGG)",
                "ZZZ = (ZZZ, ZZZ)",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2023_D08_Part1_Example2()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "LLR",
                "",
                "AAA = (BBB, BBB)",
                "BBB = (AAA, ZZZ)",
                "ZZZ = (ZZZ, ZZZ)",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("6", result);
        }

        [TestMethod]
        public async Task Y2023_D08_Part2_Example()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                "LR",
                "",
                "11A = (11B, XXX)",
                "11B = (XXX, 11Z)",
                "11Z = (11B, XXX)",
                "22A = (22B, XXX)",
                "22B = (22C, 22C)",
                "22C = (22Z, 22Z)",
                "22Z = (22B, 22B)",
                "XXX = (XXX, XXX)",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("6", result);
        }

        [TestMethod]
        public async Task Y2023_D08_Part1_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("24253", result);
        }

        [TestMethod]
        public async Task Y2023_D08_Part2_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("12357789728873", result);
        }
    }
}
