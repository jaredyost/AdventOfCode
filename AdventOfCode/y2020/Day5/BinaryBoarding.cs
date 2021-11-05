using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2020
{
    public class BinaryBoarding
    {
        /// <summary>
        /// Error Codes associated with Binary Boarding
        /// </summary>
        public enum ErrorCodes : int
        {
            INVALID_RESULT = -1,
        }

        /// <summary>
        /// Find the seat on the plane
        /// </summary>
        /// <returns>The seat ID of your assigned seat</returns>
        public int LocateSeatFullPlane()
        {
            /* Read in all the input values */
            List<string> inputSeats = File.ReadAllLines(Path.Combine("y2020", "Day5", "input.txt")).ToList();

            /* Iterate over all the inputs to perform validation */
            int result = 0;
            foreach(string seat in inputSeats)
            {
                int seatRow = 0;
                int seatColumn = 0;

                int minRow = 0;
                int maxRow = 127;

                int minColumn = 0;
                int maxColumn = 7;

                for(int i = 0; i < seat.Length; i++)
                {
                    if(i < 7)
                    {
                        /* The first 7 digits are the row */
                         int rowsRemaining = maxRow - minRow + 1;
                        switch(seat[i])
                        {
                            case 'F':
                                maxRow = minRow + (rowsRemaining / 2) - 1;
                                break;

                            case 'B':
                                minRow = maxRow - (rowsRemaining / 2) + 1;
                                break;

                            default:
                                /* Unhandled character */
                                break;
                        }
                    }
                    else
                    {
                        /* The last 3 digits are the column */
                        int columnsRemaining = maxColumn - minColumn + 1;
                        switch(seat[i])
                        {
                            case 'L':
                                maxColumn = minColumn + (columnsRemaining / 2) - 1;
                                break;

                            case 'R':
                                minColumn = maxColumn - (columnsRemaining / 2) + 1;
                                break;

                            default:
                                /* Unhandled character */
                                break;
                        }
                    }
                }

                seatRow = minRow;
                seatColumn = minColumn;

                int tempResult = (seatRow * 8) + seatColumn;
                if(tempResult > result)
                {
                    result = tempResult;
                }
            }

            /* Return the result */
            return result;
        }

        /// <summary>
        /// Find the seat on the plane with missing seats
        /// </summary>
        /// <returns>The seat ID of your assigned seat</returns>
        public int LocateSeatMissingSeats()
        {
            /* Read in all the input values */
            List<string> inputSeats = File.ReadAllLines(Path.Combine("y2020", "Day5", "input.txt")).ToList();

            /* Iterate over all the inputs to perform validation */
            List<int> seatIDs = new List<int>();
            foreach(string seat in inputSeats)
            {
                int minRow = 0;
                int maxRow = 127;

                int minColumn = 0;
                int maxColumn = 7;

                for(int i = 0; i < seat.Length; i++)
                {
                    if(i < 7)
                    {
                        /* The first 7 digits are the row */
                        int rowsRemaining = maxRow - minRow + 1;
                        switch(seat[i])
                        {
                            case 'F':
                                maxRow = minRow + (rowsRemaining / 2) - 1;
                                break;

                            case 'B':
                                minRow = maxRow - (rowsRemaining / 2) + 1;
                                break;

                            default:
                                /* Unhandled character */
                                break;
                        }
                    }
                    else
                    {
                        /* The last 3 digits are the column */
                        int columnsRemaining = maxColumn - minColumn + 1;
                        switch(seat[i])
                        {
                            case 'L':
                                maxColumn = minColumn + (columnsRemaining / 2) - 1;
                                break;

                            case 'R':
                                minColumn = maxColumn - (columnsRemaining / 2) + 1;
                                break;

                            default:
                                /* Unhandled character */
                                break;
                        }
                    }
                }

                int seatRow = minRow;
                int seatColumn = minColumn;
                int seatID = (seatRow * 8) + seatColumn;
                seatIDs.Add(seatID);
            }

            /* Sort all the seat IDs */
            seatIDs.Sort();

            /* Find the missing seat ID */
            int result = 0;
            for(int i = 0; i < seatIDs.Count - 1; i++)
            {
                if(seatIDs[i] + 1 != seatIDs[i + 1])
                {
                    result = seatIDs[i] + 1;
                }
            }

            /* Return the result */
            return result;
        }
    }
}
