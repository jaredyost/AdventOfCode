using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public async Task Y2024_D10_Part1_Example1()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "...0...",
                "...1...",
                "...2...",
                "6543456",
                "7.....7",
                "8.....8",
                "9.....9",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part1_Example2()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "..90..9",
                "...1.98",
                "...2..7",
                "6543456",
                "765.987",
                "876....",
                "987....",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part1_Example3()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "10..9..",
                "2...8..",
                "3...7..",
                "4567654",
                "...8..3",
                "...9..2",
                ".....01",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part1_Example4()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "89010123",
                "78121874",
                "87430965",
                "96549874",
                "45678903",
                "32019012",
                "01329801",
                "10456732",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("36", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part2_Example1()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                ".....0.",
                "..4321.",
                "..5..2.",
                "..6543.",
                "..7..4.",
                "..8765.",
                "..9....",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part2_Example2()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "..90..9",
                "...1.98",
                "...2..7",
                "6543456",
                "765.987",
                "876....",
                "987....",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("13", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part2_Example3()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "012345",
                "123456",
                "234567",
                "345678",
                "4.6789",
                "56789.",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("227", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part2_Example4()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "89010123",
                "78121874",
                "87430965",
                "96549874",
                "45678903",
                "32019012",
                "01329801",
                "10456732",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("81", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part1_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("535", result);
        }

        [TestMethod]
        public async Task Y2024_D10_Part2_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1186", result);
        }
    }
}
