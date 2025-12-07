using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public async Task Y2024_D12_Part1_Example1()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "AAAA",
                "BBCD",
                "BBCC",
                "EEEC",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("140", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part1_Example2()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "OOOOO",
                "OXOXO",
                "OOOOO",
                "OXOXO",
                "OOOOO",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("772", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part1_Example3()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                "RRRRIICCFF",
                "RRRRIICCCF",
                "VVRRRCCFFF",
                "VVRCCCJFFF",
                "VVVVCJJCFE",
                "VVIVCCJJEE",
                "VVIIICJJEE",
                "MIIIIIJJEE",
                "MIIISIJEEE",
                "MMMISSJEEE",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("1930", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part2_Example1()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "AAAA",
                "BBCD",
                "BBCC",
                "EEEC",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("80", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part2_Example2()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "OOOOO",
                "OXOXO",
                "OOOOO",
                "OXOXO",
                "OOOOO",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("436", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part2_Example3()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "EEEEE",
                "EXXXX",
                "EEEEE",
                "EXXXX",
                "EEEEE",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("236", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part2_Example4()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "AAAAAA",
                "AAABBA",
                "AAABBA",
                "ABBAAA",
                "ABBAAA",
                "AAAAAA",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("368", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part2_Example5()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                // csharpier-ignore-start
                "RRRRIICCFF",
                "RRRRIICCCF",
                "VVRRRCCFFF",
                "VVRCCCJFFF",
                "VVVVCJJCFE",
                "VVIVCCJJEE",
                "VVIIICJJEE",
                "MIIIIIJJEE",
                "MIIISIJEEE",
                "MMMISSJEEE",
                // csharpier-ignore-end
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("1206", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part1_Real()
        {
            // Arrange
            Day12 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1494342", result);
        }

        [TestMethod]
        public async Task Y2024_D12_Part2_Real()
        {
            // Arrange
            Day12 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("893676", result);
        }
    }
}
