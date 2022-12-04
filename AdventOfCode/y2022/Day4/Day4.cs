using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2022
{
    public class Day4
    {
        public void Run()
        {
            Console.WriteLine("-- 2022: Day 4 --");

            /* Get the input line-by-line and determine the amount of overlaps */
            int overlapCount = 0;
            IEnumerable<string> fileLines = File.ReadLines(Path.Combine("y2022", "Day4", "input.txt"));
            foreach(string line in fileLines)
            {
                IEnumerable<string> assignments = line.Split(',').ToArray();

                int assignmentOneLower = int.Parse(assignments.ElementAt(0).Split('-').ToArray()[0]);
                int assignmentOneUpper = int.Parse(assignments.ElementAt(0).Split('-').ToArray()[1]);

                int assignmentTwoLower = int.Parse(assignments.ElementAt(1).Split('-').ToArray()[0]);
                int assignmentTwoUpper = int.Parse(assignments.ElementAt(1).Split('-').ToArray()[1]);

                if((assignmentOneLower <= assignmentTwoLower && assignmentOneUpper >= assignmentTwoLower)
                    || (assignmentOneLower <= assignmentTwoUpper && assignmentOneUpper >= assignmentTwoUpper)
                    || (assignmentTwoLower <= assignmentOneLower && assignmentTwoUpper >= assignmentOneLower)
                    || (assignmentTwoLower <= assignmentOneUpper && assignmentTwoUpper >= assignmentOneUpper))
                {
                overlapCount++;
                }
            }

            /* Report the solution */
            Console.WriteLine($"Solution: { overlapCount }");
            Console.ReadKey();
        }
    }
}
