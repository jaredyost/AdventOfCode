using AdventOfCode.y2020;
using System;

namespace AdventOfCode
{
    class Runner
    {
        static void Main(string[] args)
        {
            Console.WriteLine("~~ ADVENT OF CODE ~~\n");

            // TODO: Add a selector here

            Console.WriteLine("-- 2020: Day 1 --");
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
            Console.WriteLine();

            Console.WriteLine("-- 2020: Day 2 --");
            {
                PasswordPhilosophy passwordPhilosophy = new PasswordPhilosophy();
                int result = passwordPhilosophy.ValidatePasswordLength();
                if(result != (int)PasswordPhilosophy.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Length): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }

            {
                PasswordPhilosophy passwordPhilosophy = new PasswordPhilosophy();
                int result = passwordPhilosophy.ValidatePasswordPositions();
                if (result != (int)PasswordPhilosophy.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Positions): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }
            Console.WriteLine();

            /* Wait for an enter key press to exit */
            Console.ReadLine();
        }
    }
}
