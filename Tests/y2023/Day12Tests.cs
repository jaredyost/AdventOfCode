using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day12Tests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                "???.### 1,1,3",
                ".??..??...?##. 1,1,3",
                "?#?#?#?#?#?#?#? 1,3,1,6",
                "????.#...#... 4,1,1",
                "????.######..#####. 1,6,5",
                "?###???????? 3,2,1",
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("21", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            Day12 solver = new();
            string[] TestInput =
            [
                "???.### 1,1,3",
                ".??..??...?##. 1,1,3",
                "?#?#?#?#?#?#?#? 1,3,1,6",
                "????.#...#... 4,1,1",
                "????.######..#####. 1,6,5",
                "?###???????? 3,2,1",
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("525152", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day12 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("7361", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day12 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("83317216247365", result);
        }
    }
}
