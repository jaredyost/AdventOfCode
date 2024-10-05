namespace AdventOfCode.Core
{
    /// <summary>
    /// Create the solver base
    /// </summary>
    /// <param name="aDate">The date the solver represents</param>
    public abstract class SolverBase(DateOnly aDate)
    {
        /// <summary>
        /// The date the solver represents
        /// </summary>
        private DateOnly Date { get; } = aDate;

        /// <summary>
        /// Performs basic calculations on the input to retrieve a solution.
        /// </summary>
        /// <param name="aInput">The input to solve</param>
        /// <returns>The solution to part 1</returns>
        public abstract string SolvePart1(string[] aInput);


        /// <summary>
        /// Performs advanced calculations on the input to retrieve a solution.
        /// </summary>
        /// <param name="aInput">The input to solve</param>
        /// <returns>The solution to part 2</returns>
        public abstract string SolvePart2(string[] aInput);

        /// <summary>
        /// Get the problem input
        /// </summary>
        /// <returns>The problem input</returns>
        public string[] GetInput()
        {
            return File.ReadAllLines($"Inputs/y{Date.Year}/Day{Date.ToString("dd")}.txt");
        }
    }
}
