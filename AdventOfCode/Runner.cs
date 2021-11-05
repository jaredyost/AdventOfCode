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
                if(result != (int)PasswordPhilosophy.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Positions): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("-- 2020: Day 3 --");
            {
                TobogganTrajectory tobogganTrajectory = new TobogganTrajectory();
                int result = tobogganTrajectory.CalculateTreeEncounterSinglePath();
                if(result != (int)TobogganTrajectory.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Single Path): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }

            {
                TobogganTrajectory tobogganTrajectory = new TobogganTrajectory();
                double result = tobogganTrajectory.CalculateTreeEncounterDynamicPath();
                if(result != (int)TobogganTrajectory.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Dynamic Path): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("-- 2020: Day 4 --");
            {
                PassportProcessing passportProcessing = new PassportProcessing();
                int result = passportProcessing.ValidatePassports();
                if(result != (int)PassportProcessing.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (No Validation): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }

            {
                PassportProcessing passportProcessing = new PassportProcessing();
                int result = passportProcessing.ValidatePassportFields();
                if(result != (int)PassportProcessing.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Validation): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }
            Console.WriteLine();

            Console.WriteLine("-- 2020: Day 5 --");
            {
                BinaryBoarding binaryBoarding = new BinaryBoarding();
                int result = binaryBoarding.LocateSeatFullPlane();
                if(result != (int)BinaryBoarding.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Full Plane): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }

            {
                BinaryBoarding binaryBoarding = new BinaryBoarding();
                int result = binaryBoarding.LocateSeatMissingSeats();
                if(result != (int)BinaryBoarding.ErrorCodes.INVALID_RESULT)
                {
                    Console.WriteLine($"RESULT (Missing Seats): { result }");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }
            Console.WriteLine();

            /* Wait for an enter key press to exit */
            Console.ReadLine();
            Console.Write("~~ END ~~");
        }
    }
}
