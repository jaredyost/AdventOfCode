using AdventOfCode.Solvers.y2023;

namespace AdventOfCode.Tests.y2023
{
    [TestClass]
    public class Day05Tests
    {
        [TestMethod]
        public void TestPart1Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                "seeds: 79 14 55 13",
                "",
                "seed-to-soil map:",
                "50 98 2",
                "52 50 48",
                "",
                "soil-to-fertilizer map:",
                "0 15 37",
                "37 52 2",
                "39 0 15",
                "",
                "fertilizer-to-water map:",
                "49 53 8",
                "0 11 42",
                "42 0 7",
                "57 7 4",
                "",
                "water-to-light map:",
                "88 18 7",
                "18 25 70",
                "",
                "light-to-temperature map:",
                "45 77 23",
                "81 45 19",
                "68 64 13",
                "",
                "temperature-to-humidity map:",
                "0 69 1",
                "1 0 69",
                "",
                "humidity-to-location map:",
                "60 56 37",
                "56 93 4",
            ];

            // Act
            string result = solver.SolvePart1(TestInput);

            // Assert
            Assert.AreEqual("35", result);
        }

        [TestMethod]
        public void TestPart2Example()
        {
            // Arrange
            Day05 solver = new();
            string[] TestInput =
            [
                "seeds: 79 14 55 13",
                "",
                "seed-to-soil map:",
                "50 98 2",
                "52 50 48",
                "",
                "soil-to-fertilizer map:",
                "0 15 37",
                "37 52 2",
                "39 0 15",
                "",
                "fertilizer-to-water map:",
                "49 53 8",
                "0 11 42",
                "42 0 7",
                "57 7 4",
                "",
                "water-to-light map:",
                "88 18 7",
                "18 25 70",
                "",
                "light-to-temperature map:",
                "45 77 23",
                "81 45 19",
                "68 64 13",
                "",
                "temperature-to-humidity map:",
                "0 69 1",
                "1 0 69",
                "",
                "humidity-to-location map:",
                "60 56 37",
                "56 93 4",
            ];

            // Act
            string result = solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("46", result);
        }

        [TestMethod]
        public void TestPart1Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = solver.SolvePart1(solver.GetInput());

            // Assert
            Assert.AreEqual("309796150", result);
        }

        [TestMethod]
        public void TestPart2Real()
        {
            // Arrange
            Day05 solver = new();

            // Act
            string result = solver.SolvePart2(solver.GetInput());

            // Assert
            Assert.AreEqual("50716416", result);
        }
    }
}
