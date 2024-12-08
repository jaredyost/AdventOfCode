using AdventOfCode.Solvers.Y2024;

namespace AdventOfCode.Tests.Y2024
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public async Task Y2024_D05_Part1_Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
                "",
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47",
            ];

            // Act
            string result = await solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("143", result);
        }

        [TestMethod]
        public async Task Y2024_D05_Part2_Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
                "",
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("123", result);
        }

        [TestMethod]
        public async Task Y2024_D05_Part1_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("3608", result);
        }

        [TestMethod]
        public async Task Y2024_D05_Part2_Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("4922", result);
        }
    }
}
