using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day14Tests
    {
        [TestMethod]
        public async Task Y2024_D14_Part1_Example()
        {
            // Arrange
            Day14 solver = new(7, 11);
            string[] TestInput =
            [
                "p=0,4 v=3,-3",
                "p=6,3 v=-1,-3",
                "p=10,3 v=-1,2",
                "p=2,0 v=2,-1",
                "p=0,0 v=1,3",
                "p=3,0 v=-2,-2",
                "p=7,6 v=-1,-3",
                "p=3,0 v=-1,-2",
                "p=9,3 v=2,3",
                "p=7,3 v=-1,2",
                "p=2,4 v=2,-3",
                "p=9,5 v=-3,-3",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("12", result);
        }

        [TestMethod]
        public async Task Y2024_D14_Part1_Real()
        {
            // Arrange
            Day14 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("210587128", result);
        }

        [TestMethod]
        public async Task Y2024_D14_Part2_Real()
        {
            // Arrange
            Day14 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("7286", result);
        }
    }
}
