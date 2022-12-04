using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2021
{
    public class Day8
    {
        private enum NumberSegments : int
        {
            Zero = 6,
            One = 2,
            Two = 5,
            Three = 5,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 3,
            Eight = 7,
            Nine = 6,
        }

        public void Run()
        {
            Console.WriteLine("-- 2021: Day 8 --");

            /* Get the input */
            List<string[]> inputSignals = new List<string[]>();
            List<string[]> inputValues = new List<string[]>();
            foreach(string line in File.ReadLines(Path.Combine("y2021", "Day8", "input.txt")))
            {
                string[] currentLine = line.Split('|').ToArray();

                inputSignals.Add(currentLine[0].Split().Where(x => !string.IsNullOrWhiteSpace(x))
                                    .Select(x => new string(x.ToCharArray().OrderBy(x => x).ToArray())).ToArray());
                inputValues.Add(currentLine[1].Split().Where(x => !string.IsNullOrWhiteSpace(x))
                                    .Select(x => new string(x.ToCharArray().OrderBy(x => x).ToArray())).ToArray());
            }

            /* Calculate the sum of all output values */
            int sum = 0;

            for(int i = 0; i < inputValues.Count(); i++)
            {
                string[] mappedValues = new string[10];

                /* 1, 4, 7, and 8 have a distinct number of segments */
                mappedValues[1] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.One).First();
                mappedValues[4] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Four).First();
                mappedValues[7] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Seven).First();
                mappedValues[8] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Eight).First();

                /* 9 has to contain the same segments as 4 */
                mappedValues[9] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Nine
                                                    && getDifference(mappedValues[4], x).Length == 0).First();

                /* 0 needs to contain 7 */
                mappedValues[0] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Zero
                                                    && getDifference(mappedValues[7], x).Length == 0 && !x.Equals(mappedValues[9])).First();

                /* 6 is the only one of this length remaining */
                mappedValues[6] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Six
                                                    && !x.Equals(mappedValues[0]) && !x.Equals(mappedValues[9])).First();

                /* 3 has to contain 7 */
                mappedValues[3] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Three
                                                    && getDifference(mappedValues[7], x).Length == 0).First();

                /* 2 needs to contain the difference between 8 and 6 */
                mappedValues[2] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Two
                                                    && getDifference(getDifference(mappedValues[8], mappedValues[6]), x).Length == 0
                                                    && !x.Equals(mappedValues[3])).First();

                /* 5 is the only one of this length remaining */
                mappedValues[5] = inputSignals[i].Where(x => (NumberSegments)x.Length == NumberSegments.Five
                                                    && !x.Equals(mappedValues[2]) && !x.Equals(mappedValues[3])).First();

                /* Now we can compute the output number and add it to our running sum */
                string value = "0";
                foreach(string currentValue in inputValues[i])
                {
                    value += mappedValues.ToList().IndexOf(currentValue).ToString();
                }

                sum += int.Parse(value);
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { sum }");
        }

        private static string getDifference(string stringToDiff, string comapreString)
        {
            /* Return the characters from stringToDiff not found in comapreString */
            return new string(stringToDiff.Where(x => !comapreString.ToCharArray().Contains(x)).ToArray());
        }
    }
}
