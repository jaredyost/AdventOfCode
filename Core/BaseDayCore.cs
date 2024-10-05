using AoCHelper;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AdventOfCode.Core
{
    public abstract class BaseDayCore : BaseDay
    {
        public string[] ProblemInput { get; }

        public BaseDayCore()
        {
            ProblemInput = LoadInput();
        }

        // Every day/problem needs to define these methods
        protected abstract int Year { get; }
        protected abstract int Day { get; }
        public abstract ValueTask<string> SolvePart1(string[] aInput);
        public abstract ValueTask<string> SolvePart2(string[] aInput);

        // Configuration overrides
        public override string InputFilePath =>
            Path.Combine(
                Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!,
                "Inputs",
                $"Y{Year}D{Day:D2}.txt"
            );
        public sealed override ValueTask<string> Solve_1() { return SolvePart1(ProblemInput); }
        public sealed override ValueTask<string> Solve_2() { return SolvePart2(ProblemInput); }

        // Helpers
        private string[] LoadInput()
        {
            if (!File.Exists(InputFilePath) || new FileInfo(InputFilePath).Length == 0)
            {
                HttpClient httpClient = new() { BaseAddress = new("https://adventofcode.com") };
                _ = httpClient.DefaultRequestHeaders.TryAddWithoutValidation(
                    "User-Agent",
                    "github.com/jaredyost/AdventOfCode by jaredyost@me.com"
                );

                IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets(Assembly.GetExecutingAssembly()).Build();
                httpClient.DefaultRequestHeaders.Add("cookie", $"session={config["session"]}");

                HttpResponseMessage response = Task.Run(() => httpClient.GetAsync($"/{Year}/day/{Day}/input")).Result;
                _ = response.EnsureSuccessStatusCode();

                using (FileStream fileStream = new(InputFilePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    response.Content.ReadAsStream().CopyTo(fileStream);
                }

                // This is a little hacky, but copy this back to our user-facing directory
                File.Copy(
                    InputFilePath,
                    Path.Combine("..", "..", "..", "..", "Solvers", $"Y{Year}", "Inputs", Path.GetFileName(InputFilePath)),
                    true
                );
            }

            return File.ReadAllLines(InputFilePath);
        }
    }
}
