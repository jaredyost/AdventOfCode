using AdventOfCode.y2020;
using System;

namespace AdventOfCode
{
    class Runner
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running Code...\n\n");

            // TODO: Add a selector here
            {
                ReportRepair reportRepair = new ReportRepair();
                int result = reportRepair.Calculate2Entries();
                if(result != (int)ReportRepair.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (2 Entires): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }

            {
                ReportRepair reportRepair = new ReportRepair();
                int result = reportRepair.Calculate3Entries();
                if(result != (int)ReportRepair.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (3 Entires): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }

            /* Wait for an enter key press to exit */
            Console.ReadLine();
        }
    }
}
