using System.Diagnostics;

namespace AdventOfCode.Core
{
    public class Solver
    {
        /// <summary>
        /// Solve a problem
        /// </summary>
        /// <param name="aInput">The input for the problem</param>
        /// <param name="aSolver">The solver for the problem</param>
        public static void Solve(SolverBase aSolver)
        {
            (string solution1, TimeSpan time1) = SolvePart(aSolver, 1);
            Console.WriteLine($"Part 1 Solution: {solution1}\t\tTime: {time1.TotalMilliseconds}ms");

            (string solution2, TimeSpan time2) = SolvePart(aSolver, 2);
            Console.WriteLine($"Part 2 Solution: {solution2}\t\tTime: {time2.TotalMilliseconds}ms");
        }

        /// <summary>
        /// Run part of the solver for a problem
        /// </summary>
        /// <param name="aSolver">The solver for the problem</param>
        /// <param name="aPart">The part of the problem to solve</param>
        /// <returns>The solution and the elapsed time</returns>
        private static (string, TimeSpan) SolvePart(SolverBase aSolver, uint aPart)
        {
            string solution = "";
            Stopwatch stopwatch = new();

            try
            {
                string[] input = aSolver.GetInput();

                stopwatch.Start();
                solution = aPart switch
                {
                    1 => aSolver.SolvePart1(input),
                    2 => aSolver.SolvePart2(input),
                    _ => throw new NotImplementedException("Unknown part requested"),
                };
            }
            catch (NotImplementedException)
            {
                solution = "Not Implemented";
            }
            catch (Exception)
            {
                solution = "Error";
            }
            finally
            {
                stopwatch.Stop();
            }

            return (solution, stopwatch.Elapsed);
        }
    }
}
