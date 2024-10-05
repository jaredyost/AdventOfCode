using AoCHelper;
using System.Reflection;

List<Assembly> assemblies = [
    Assembly.GetAssembly(typeof(AdventOfCode.Solvers.Y2020.BaseDay2020)),
    Assembly.GetAssembly(typeof(AdventOfCode.Solvers.Y2021.BaseDay2021)),
    Assembly.GetAssembly(typeof(AdventOfCode.Solvers.Y2022.BaseDay2022)),
    Assembly.GetAssembly(typeof(AdventOfCode.Solvers.Y2023.BaseDay2023)),
    //Assembly.GetAssembly(typeof(AdventOfCode.Solvers.Y2024.BaseDay2024)),
];

if (args.Length == 0)
{
    await Solver.SolveLast(options =>
    {
        options.ClearConsole = false;
        options.ProblemAssemblies = [.. assemblies, .. options.ProblemAssemblies];
    });

    return;
}

if (args.Length == 1 && args[0].Contains("all", StringComparison.CurrentCultureIgnoreCase))
{
    await Solver.SolveAll(options =>
    {
        options.ShowConstructorElapsedTime = true;
        options.ShowTotalElapsedTimePerDay = true;
        options.ProblemAssemblies = [.. assemblies, .. options.ProblemAssemblies];
    });

    return;
}

IEnumerable<uint> indexes = args.Select(arg => uint.TryParse(arg, out uint index) ? index : uint.MaxValue);
await Solver.Solve(
    indexes.Where(i => i < uint.MaxValue),
    options => options.ProblemAssemblies = [.. assemblies, .. options.ProblemAssemblies]
);
