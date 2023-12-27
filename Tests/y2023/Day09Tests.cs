using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day09Tests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45",
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("114", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            Day09 solver = new();
            string[] TestInput =
            [
                "0 3 6 9 12 15",
                "1 3 6 10 15 21",
                "10 13 16 21 30 45",
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("2", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("1980437560", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day09 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("977", result);
        }
    }
}
