using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public async Task Y2024_D13_Part1_Example()
        {
            // Arrange
            Day13 solver = new();
            string[] TestInput =
            [
                "Button A: X+94, Y+34",
                "Button B: X+22, Y+67",
                "Prize: X=8400, Y=5400",
                "",
                "Button A: X+26, Y+66",
                "Button B: X+67, Y+21",
                "Prize: X=12748, Y=12176",
                "",
                "Button A: X+17, Y+86",
                "Button B: X+84, Y+37",
                "Prize: X=7870, Y=6450",
                "",
                "Button A: X+69, Y+23",
                "Button B: X+27, Y+71",
                "Prize: X=18641, Y=10279",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("480", result);
        }

        [TestMethod]
        public async Task Y2024_D13_Part2_Example()
        {
            // Arrange
            Day13 solver = new();
            string[] TestInput =
            [
                "Button A: X+94, Y+34",
                "Button B: X+22, Y+67",
                "Prize: X=8400, Y=5400",
                "",
                "Button A: X+26, Y+66",
                "Button B: X+67, Y+21",
                "Prize: X=12748, Y=12176",
                "",
                "Button A: X+17, Y+86",
                "Button B: X+84, Y+37",
                "Prize: X=7870, Y=6450",
                "",
                "Button A: X+69, Y+23",
                "Button B: X+27, Y+71",
                "Prize: X=18641, Y=10279",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("875318608908", result);
        }

        [TestMethod]
        public async Task Y2024_D13_Part1_Real()
        {
            // Arrange
            Day13 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("28138", result);
        }

        [TestMethod]
        public async Task Y2024_D13_Part2_Real()
        {
            // Arrange
            Day13 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("108394825772874", result);
        }
    }
}
