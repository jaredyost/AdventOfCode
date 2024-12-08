using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public async Task Y2022_D06_Part1_Example1()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "mjqjpqmgbljsphdztnvjfqwrcgsmlb",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("7", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part1_Example2()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "bvwbjplbgvbhsrlpgdmjqwftvncz",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part1_Example3()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "nppdvjthqldpwncqszvftbrmjlhg",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("6", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part1_Example4()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part1_Example5()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("11", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part2_Example1()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "mjqjpqmgbljsphdztnvjfqwrcgsmlb",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("19", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part2_Example2()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "bvwbjplbgvbhsrlpgdmjqwftvncz",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("23", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part2_Example3()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "nppdvjthqldpwncqszvftbrmjlhg",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("23", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part2_Example4()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("29", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part2_Example5()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("26", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part1_Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("1544", result);
        }

        [TestMethod]
        public async Task Y2022_D06_Part2_Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("2145", result);
        }
    }
}
