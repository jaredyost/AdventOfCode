using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2020
{
    public class ReportRepair
    {
        /// <summary>
        /// Error Codes associated with Report Repair
        /// </summary>
        public enum ErrorCodes : int
        {
            INVALID_ENTRY   = -1,
            INVALID_RESULT  = -2,
        }

        /// <summary>
        /// Find the first two entries that sum to 2020 and multiply them together
        /// </summary>
        /// <returns>The product of the first two entries that sum to 2020</returns>
        public int Calculate2Entries()
        {
            /* Read in all the input values */
            List<int> inputVals = File.ReadAllLines(@"C:\Users\Jared Yost\source\repos\AdventOfCode\AdventOfCode\y2020\Day1\input.txt").Select(int.Parse).ToList();

            /* Find the entries that sum to 2020 */
            Tuple<int, int> entries = Find2Entries(inputVals);

            /* If we found the entries, calculate the product */
            int result = (int)ErrorCodes.INVALID_RESULT;
            if(entries.Item1 != (int)ErrorCodes.INVALID_ENTRY && entries.Item2 != (int)ErrorCodes.INVALID_ENTRY)
            {
                result = entries.Item1 * entries.Item2;
            }

            /* Return the result */
            return result;
        }

        /// <summary>
        /// Find the first three entries that sum to 2020 and multiply them together
        /// </summary>
        /// <returns>The product of the first three entries that sum to 2020</returns>
        public int Calculate3Entries()
        {
            /* Read in all the input values */
            List<int> inputVals = File.ReadAllLines(@"C:\Users\Jared Yost\source\repos\AdventOfCode\AdventOfCode\y2020\Day1\input.txt").Select(int.Parse).ToList();

            /* Find the entries that sum to 2020 */
            Tuple<int, int, int> entries = Find3Entries(inputVals);

            /* If we found the entries, calculate the product */
            int result = (int)ErrorCodes.INVALID_RESULT;
            if(entries.Item1 != (int)ErrorCodes.INVALID_ENTRY && entries.Item2 != (int)ErrorCodes.INVALID_ENTRY && entries.Item3 != (int)ErrorCodes.INVALID_ENTRY)
            {
                result = entries.Item1 * entries.Item2 * entries.Item3;
            }

            /* Return the result */
            return result;
        }

        #region PrivateMethods
        /// <summary>
        /// Find the first two entries that sum to 2020
        /// </summary>
        /// <param name="inputEntries">A list of integer inputs to search through</param>
        /// <returns>A tuple with the entry values that sum to 2020</returns>
        private static Tuple<int, int> Find2Entries(List<int> inputEntries)
        {
            /* Iterate through the list to find which entries sum to 2020 */
            for(int i = 0; i < inputEntries.Count(); i++)
            {
                for(int j = i; j < inputEntries.Count(); j++)
                {
                    if(inputEntries[i] + inputEntries[j] == 2020)
                    {
                        return Tuple.Create(inputEntries[i], inputEntries[j]);
                    }
                }
            }

            /* No valid entries were found, return INVALID */
            return Tuple.Create((int)ErrorCodes.INVALID_ENTRY, (int)ErrorCodes.INVALID_ENTRY);
        }

        /// <summary>
        /// Find the first three entries that sum to 2020
        /// </summary>
        /// <param name="inputEntries">A list of integer inputs to search through</param>
        /// <returns>A tuple with the entry values that sum to 2020</returns>
        private static Tuple<int, int, int> Find3Entries(List<int> inputEntries)
        {
            /* Iterate through the list to find which entries sum to 2020 */
            for(int i = 0; i < inputEntries.Count(); i++)
            {
                for(int j = i; j < inputEntries.Count(); j++)
                {
                    for(int k = j; k < inputEntries.Count(); k++)
                    {
                        if(inputEntries[i] + inputEntries[j] + inputEntries[k] == 2020)
                        {
                            return Tuple.Create(inputEntries[i], inputEntries[j], inputEntries[k]);
                        }
                    }
                }
            }

            /* No valid entries were found, return INVALID */
            return Tuple.Create((int)ErrorCodes.INVALID_ENTRY, (int)ErrorCodes.INVALID_ENTRY, (int)ErrorCodes.INVALID_ENTRY);
        }
        #endregion
    }
}
