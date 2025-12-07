using AdventOfCode.Solvers.Y2025;

namespace AdventOfCode.Tests.Y2025
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public async Task Y2025_D01_Part1_Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "L68",
                "L30",
                "R48",
                "L5",
                "R60",
                "L55",
                "L1",
                "L99",
                "R14",
                "L82",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public async Task Y2025_D01_Part2_Example1()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "L68",
                "L30",
                "R48",
                "L5",
                "R60",
                "L55",
                "L1",
                "L99",
                "R14",
                "L82",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("6", result);
        }

        [TestMethod]
        public async Task Y2025_D01_Part2_Example2()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "R1000",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public async Task Y2025_D01_Part1_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("989", result);
        }

        [TestMethod]
        public async Task Y2025_D01_Part2_Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("5941", result);
        }
    }
}
