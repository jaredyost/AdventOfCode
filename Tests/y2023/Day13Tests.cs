using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day13Tests
    {
        [TestMethod]
        public void TestPart1Example()
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
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("405", result);
        }

        [TestMethod]
        public void TestPart2Example()
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
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("400", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day13 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("33780", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day13 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
