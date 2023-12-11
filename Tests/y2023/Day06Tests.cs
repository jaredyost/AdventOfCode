using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day06Tests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "Time:      7  15   30",
                "Distance:  9  40  200",
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("288", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            Day06 solver = new();
            string[] TestInput =
            [
                "Time:      7  15   30",
                "Distance:  9  40  200",
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("71503", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("275724", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day06 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("37286485", result);
        }
    }
}
