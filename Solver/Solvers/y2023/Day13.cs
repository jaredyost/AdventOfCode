using AdventOfCode.Core;
using System.Collections.Frozen;

namespace AdventOfCode.Solvers.y2023
{
    public class Day13 : SolverBase
    {
        public Day13() : base(new(2023, 12, 13)) { }

        public override string SolvePart1(string[] aInput)
        {
            string[][] maps = ParseMap(aInput);

            int sum = 0;
            foreach (string[] map in maps)
            {
                sum += FindVerticalReflection(map).First();
                sum += 100 * FindHorizontalReflection(map).First();
            }

            return sum.ToString();
        }

        public override string SolvePart2(string[] aInput)
        {
            string[][] maps = ParseMap(aInput);

            int sum = 0;
            foreach (string[] map in maps)
            {
                int originalVertical = FindVerticalReflection(map).First();
                int originalHorizontal = FindHorizontalReflection(map).First();
                string[] repairedMap = RepairSmudge(map);

                int[] newVerticals = [..FindVerticalReflection(repairedMap).Where(x => x != originalVertical)];
                if (newVerticals.Length > 0)
                {
                    sum += newVerticals.First();
                }

                int[] newHorizontals = [..FindHorizontalReflection(repairedMap).Where(x => x != originalHorizontal)];
                if (newHorizontals.Length > 0)
                {
                    sum += 100 * newHorizontals.First();
                }
            }

            return sum.ToString();
        }

        private static string[][] ParseMap(string[] aInput)
        {
            List<List<string>> maps = [[]];
            foreach (string line in aInput)
            {
                if (string.IsNullOrEmpty(line))
                {
                    maps.Add([]);
                }
                else
                {
                    maps.Last().Add(line);
                }
            }
            maps.RemoveAll(x => x.Count == 0);

            string[][] finalizedMaps = new string[maps.Count][];
            for (int i = 0; i < finalizedMaps.Length; i++)
            {
                finalizedMaps[i] = [.. maps[i]];
            }

            return finalizedMaps;
        }

        private static string[] RepairSmudge(string[] aMap)
        {
            string[] repairedMap = aMap.Clone() as string[] ?? throw new NullReferenceException();

            // Check the rows first
            int originalRow = FindVerticalReflection(aMap).First();
            for (int i = 1; i < aMap.Length; i++)
            {
                for (int j = 1; i - j >= 0 && i + j - 1 < aMap.Length; j++)
                {
                    int differences = 0;
                    for (int k = 0; k < aMap[i - j].Length && differences < 2; k++)
                    {
                        if (aMap[i - j][k] != aMap[i + j - 1][k])
                        {
                            differences++;
                        }
                    }

                    if (differences == 1 && i + j != originalRow)
                    {
                        repairedMap[i - j] = aMap[i + j - 1];
                        return repairedMap;
                    }
                }
            }

            // Then check the columns
            int originalColumn = FindHorizontalReflection(aMap).First();
            for (int i = 1; i < aMap[0].Length; i++)
            {
                int reflectionOffset = -1;
                int differences = 0;
                for (int j = 1; i - j >= 0 && i + j - 1 < aMap[0].Length && differences < 2; j++)
                {
                    for (int k = 0; k < aMap.Length && differences < 2; k++)
                    {
                        if (aMap[k][i - j] != aMap[k][i + j - 1])
                        {
                            differences++;
                            reflectionOffset = j;
                        }
                    }
                }

                if (differences == 1 && i + reflectionOffset != originalColumn)
                {
                    for (int k = 0; k < aMap.Length; k++)
                    {
                        if (aMap[k][i - reflectionOffset] != aMap[k][i + reflectionOffset - 1])
                        {
                            char[] newString = aMap[k].ToCharArray();
                            newString[i - reflectionOffset] = aMap[k][i + reflectionOffset - 1];
                            repairedMap[k] = new string(newString);
                        }
                    }

                    return repairedMap;
                }
            }

            return repairedMap;
        }

        private static int[] FindVerticalReflection(string[] aMap)
        {
            List<int> reflections = [];
            for (int i = 1; i < aMap[0].Length; i++)
            {
                bool valid = true;
                for (int j = 1; i - j >= 0 && i + j - 1 < aMap[0].Length && valid; j++)
                {
                    valid = string.Join("", aMap.Select(x => x[i - j]).ToArray()) == string.Join("", aMap.Select(x => x[i + j - 1]).ToArray());
                }

                if (valid)
                {
                    reflections.Add(i);
                    continue;
                }
            }

            if (reflections.Count == 0)
            {
                reflections.Add(0);
            }

            return [.. reflections];
        }

        private static int[] FindHorizontalReflection(string[] aMap)
        {
            List<int> reflections = [];
            for (int i = 1; i < aMap.Length; i++)
            {
                bool valid = true;
                for (int j = 1; i - j >= 0 && i + j - 1 < aMap.Length && valid; j++)
                {
                    valid = aMap[i - j] == aMap[i + j - 1];
                }

                if (valid)
                {
                    reflections.Add(i);
                    continue;
                }
            }

            if (reflections.Count == 0)
            {
                reflections.Add(0);
            }

            return [.. reflections];
        }
    }
}
