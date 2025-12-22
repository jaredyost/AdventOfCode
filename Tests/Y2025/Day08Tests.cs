using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day08Tests
    {
        [TestMethod]
        public async Task Y2025_D08_Part1_Example()
        {
            // Arrange
            Day08 solver = new() { NumberPairs = 10 };
            string[] TestInput =
            [
                // csharpier-ignore-start
                "162,817,812",
                "57,618,57",
                "906,360,560",
                "592,479,940",
                "352,342,300",
                "466,668,158",
                "542,29,236",
                "431,825,988",
                "739,650,466",
                "52,470,668",
                "216,146,977",
                "819,987,18",
                "117,168,530",
                "805,96,715",
                "346,949,466",
                "970,615,88",
                "941,993,340",
                "862,61,35",
                "984,92,344",
                "425,690,689",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("40", result);
        }

        [TestMethod]
        public async Task Y2025_D08_Part2_Example()
        {
            // Arrange
            Day08 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "162,817,812",
                "57,618,57",
                "906,360,560",
                "592,479,940",
                "352,342,300",
                "466,668,158",
                "542,29,236",
                "431,825,988",
                "739,650,466",
                "52,470,668",
                "216,146,977",
                "819,987,18",
                "117,168,530",
                "805,96,715",
                "346,949,466",
                "970,615,88",
                "941,993,340",
                "862,61,35",
                "984,92,344",
                "425,690,689",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("25272", result);
        }

        [TestMethod]
        public async Task Y2025_D08_Part1_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("50760", result);
        }

        [TestMethod]
        public async Task Y2025_D08_Part2_Real()
        {
            // Arrange
            Day08 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("3206508875", result);
        }
    }
}
