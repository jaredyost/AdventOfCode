using AdventOfCode.Solvers.Y2022;

namespace AdventOfCode.Tests.Y2022
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public async Task Y2022_D05_Part1_Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                " 1   2   3 ",
                "",
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("CMZ", result);
        }

        [TestMethod]
        public async Task Y2022_D05_Part2_Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                "    [D]    ",
                "[N] [C]    ",
                "[Z] [M] [P]",
                " 1   2   3 ",
                "",
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("MCD", result);
        }

        [TestMethod]
        public async Task Y2022_D05_Part1_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("FCVRLMVQP", result);
        }

        [TestMethod]
        public async Task Y2022_D05_Part2_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("RWLWGJGFD", result);
        }
    }
}
