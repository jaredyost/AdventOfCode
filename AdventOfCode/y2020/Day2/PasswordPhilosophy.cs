using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.y2020
{
    public class PasswordPhilosophy
    {
        /// <summary>
        /// Error Codes associated with Password Philosophy
        /// </summary>
        public enum ErrorCodes : int
        {
            INVALID_RESULT  = -1,
        }

        /// <summary>
        /// Find the number of valid passwords given an input list and password length constraints
        /// </summary>
        /// <returns>The number of valid passwords</returns>
        public int ValidatePasswordLength()
        {
            /* Read in all the input values */
            List<string> inputLines = File.ReadAllLines(Path.Combine("y2020", "Day2", "input.txt")).ToList();

            /* Iterate over all the inputs to perform validation */
            int result = 0;
            foreach(string currentLine in inputLines)
            {
                /* Split the needed information */
                List<string> currentLineItems = currentLine.Split('-', ' ', ':').Where(tempString => !string.IsNullOrWhiteSpace(tempString)).ToList();
                int minAmount = int.Parse(currentLineItems[0]);
                int maxAmount = int.Parse(currentLineItems[1]);
                char requiredCharacter = currentLineItems[2][0];
                string password = currentLineItems[3];

                /* Validate the password */
                int tempCharacterCount = 0;
                for(int i = 0; i < password.Length; i++)
                {
                    if(password[i] == requiredCharacter)
                    {
                        tempCharacterCount++;
                    }
                }

                if(tempCharacterCount >= minAmount && tempCharacterCount <= maxAmount)
                {
                    result++;
                }
            }

            /* Return the result */
            return result;
        }

        /// <summary>
        /// Find the number of valid passwords given an input list and password position constraints
        /// </summary>
        /// <returns>The number of valid passwords</returns>
        public int ValidatePasswordPositions()
        {
            /* Read in all the input values */
            List<string> inputLines = File.ReadAllLines(Path.Combine("y2020", "Day2", "input.txt")).ToList();

            /* Iterate over all the inputs to perform validation */
            int result = 0;
            foreach(string currentLine in inputLines)
            {
                /* Split the needed information */
                List<string> currentLineItems = currentLine.Split('-', ' ', ':').Where(tempString => !string.IsNullOrWhiteSpace(tempString)).ToList();
                int position1 = int.Parse(currentLineItems[0]) - 1; /* -1 since the values are not zero-indexed */
                int position2 = int.Parse(currentLineItems[1]) - 1; /* -1 since the values are not zero-indexed */
                char requiredCharacter = currentLineItems[2][0];
                string password = currentLineItems[3];

                /* Validate the password */
                bool position1Valid = password[position1] == requiredCharacter;
                bool position2Valid = password[position2] == requiredCharacter;

                if(position1Valid ^ position2Valid)
                {
                    result++;
                }
            }

            /* Return the result */
            return result;
        }
    }
}
