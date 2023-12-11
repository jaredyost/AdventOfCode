using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day01Tests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                "1abc2",
                "npqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet",
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("142", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            Day01 solver = new();
            string[] TestInput =
            [
                "two1nine",
                "eightwothree",
                "abcone2threexyz",
                "xtwone3four",
                "4nineeightseven2",
                "zoneight234",
                "7pqrstsixteen",
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("281", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("56506", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day01 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("56017", result);
        }
    }
}
