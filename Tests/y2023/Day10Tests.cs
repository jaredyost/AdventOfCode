using AdventOfCode.Solvers.Y2023;

namespace AdventOfCode.Tests.Y2023
{
    [TestClass]
    public class Day10Tests
    {
        [TestMethod]
        public async Task Y2023_D10_Part1_Example1()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput1 =
            [
                ".....",
                ".S-7.",
                ".|.|.",
                ".L-J.",
                ".....",
            ];

            string[] TestInput2 =
            [
                "-L|F7",
                "7S-7|",
                "L|7||",
                "-L-J|",
                "L|-JF",
            ];

            // Act
            string result1 = await solver.SolvePart1(TestInput1);
            string result2 = await solver.SolvePart1(TestInput2);

            // Assert
            Assert.AreEqual("4", result1);
            Assert.AreEqual("4", result2);
        }

        [TestMethod]
        public async Task Y2023_D10_Part1_Example2()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput1 =
            [
                "..F7.",
                ".FJ|.",
                "SJ.L7",
                "|F--J",
                "LJ...",
            ];

            string[] TestInput2 =
            [
                "7-F7-",
                ".FJ|7",
                "SJLL7",
                "|F--J",
                "LJ.LJ",
            ];

            // Act
            string result1 = await solver.SolvePart1(TestInput1);
            string result2 = await solver.SolvePart1(TestInput2);

            // Assert
            Assert.AreEqual("8", result1);
            Assert.AreEqual("8", result2);
        }

        [TestMethod]
        public async Task Y2023_D10_Part2_Example1()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput1 =
            [
                "...........",
                ".S-------7.",
                ".|F-----7|.",
                ".||.....||.",
                ".||.....||.",
                ".|L-7.F-J|.",
                ".|..|.|..|.",
                ".L--J.L--J.",
                "...........",
            ];

            string[] TestInput2 =
            [
                "..........",
                ".S------7.",
                ".|F----7|.",
                ".||....||.",
                ".||....||.",
                ".|L-7F-J|.",
                ".|..||..|.",
                ".L--JL--J.",
                "..........",
            ];

            // Act
            string result1 = await solver.SolvePart2(TestInput1);
            string result2 = await solver.SolvePart2(TestInput2);

            // Assert
            Assert.AreEqual("4", result1);
            Assert.AreEqual("4", result2);
        }

        [TestMethod]
        public async Task Y2023_D10_Part2_Example2()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                ".F----7F7F7F7F-7....",
                ".|F--7||||||||FJ....",
                ".||.FJ||||||||L7....",
                "FJL7L7LJLJ||LJ.L-7..",
                "L--J.L7...LJS7F-7L7.",
                "....F-J..F7FJ|L7L7L7",
                "....L7.F7||L7|.L7L7|",
                ".....|FJLJ|FJ|F7|.LJ",
                "....FJL-7.||.||||...",
                "....L---J.LJ.LJLJ...",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("8", result);
        }

        [TestMethod]
        public async Task Y2023_D10_Part2_Example3()
        {
            // Arrange
            Day10 solver = new();
            string[] TestInput =
            [
                "FF7FSF7F7F7F7F7F---7",
                "L|LJ||||||||||||F--J",
                "FL-7LJLJ||||||LJL-77",
                "F--JF--7||LJLJ7F7FJ-",
                "L---JF-JLJ.||-FJLJJ7",
                "|F|F-JF---7F7-L7L|7|",
                "|FFJF7L7F-JF7|JL---7",
                "7-L-JL7||F7|L7F-7F7|",
                "L.L7LFJ|||||FJL7||LJ",
                "L7JLJL-JLJLJL--JLJ.L",
            ];

            // Act
            string result = await solver.SolvePart2(TestInput);

            // Assert
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public async Task Y2023_D10_Part1_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart1(solver.ProblemInput);

            // Assert
            Assert.AreEqual("7063", result);
        }

        [TestMethod]
        public async Task Y2023_D10_Part2_Real()
        {
            // Arrange
            Day10 solver = new();

            // Act
            string result = await solver.SolvePart2(solver.ProblemInput);

            // Assert
            Assert.AreEqual("589", result);
        }
    }
}
