using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class DayXXTests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            DayXX solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            DayXX solver = new();
            string[] TestInput =
            [
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            DayXX solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            DayXX solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("", result);
        }
    }
}
