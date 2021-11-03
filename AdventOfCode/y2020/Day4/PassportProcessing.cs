using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.y2020
{
    public class PassportProcessing
    {
        /// <summary>
        /// Error Codes associated with Passport Processing
        /// </summary>
        public enum ErrorCodes : int
        {
            INVALID_RESULT  = -1,
        }

        /// <summary>
        /// Fields required for a valid passport
        /// </summary>
        private enum RequiredFields : int
        {
            BirthYear,
            IssueYear,
            ExpirationYear,
            Height,
            HairColor,
            EyeColor,
            PassportID,
            //CountryID, // NOT REQUIRED!

            Count,
        }

        /// <summary>
        /// Find the number of valid passports containing all required fields
        /// </summary>
        /// <returns>The number of valid passports</returns>
        public int ValidatePassports()
        {
            /* Read in all the passports */
            List<string> inputPassports = File.ReadAllText(Path.Combine("y2020", "Day4", "input.txt"))
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            /* Set up an array of required passport fields */
            string[] requiredFields = new string[]
            {
                "byr",  // BirthYear
                "iyr",  // IssueYear
                "eyr",  // ExpirationYear
                "hgt",  // Height
                "hcl",  // HairColor
                "ecl",  // EyeColor
                "pid",  // PassportID
                // "cid",  // CountryID // NOT REQUIRED!
            };

            /* Iterate over the passports and ensure they have all the required fields */
            int result = 0;
            foreach(string passport in inputPassports)
            {
                bool valid = true;
                foreach(string field in requiredFields)
                {
                    valid = valid && passport.Contains(field);
                }

                if(valid)
                {
                    result++;
                }
            }

            /* Return the result */
            return result;
        }

        /// <summary>
        /// Find the number of valid passports containing all required fields
        /// </summary>
        /// <returns>The number of valid passports</returns>
        public int ValidatePassportFields()
        {
            /* Read in all the passports */
            List<string> inputPassports = File.ReadAllText(Path.Combine("y2020", "Day4", "input.txt"))
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            /* Set up an array of required passport fields */
            string[] requiredFields = new string[]
            {
                "byr",  // BirthYear
                "iyr",  // IssueYear
                "eyr",  // ExpirationYear
                "hgt",  // Height
                "hcl",  // HairColor
                "ecl",  // EyeColor
                "pid",  // PassportID
                // "cid",  // CountryID // NOT REQUIRED!
            };

            /* Iterate over the passports and ensure they have all the required fields */
            int result = 0;
            foreach(string passport in inputPassports)
            {
                Dictionary<string, string> fields = passport.Split().Where(tempString => !string.IsNullOrWhiteSpace(tempString))
                    .Select(field => field.Split(':')).ToDictionary(field => field[0], field => field[1])
                    .Where(item => !item.Key.Equals("cid")).ToDictionary(item => item.Key, item => item.Value);

                if(fields.Count() >= (int)RequiredFields.Count)
                {
                    bool valid = true;
                    foreach(KeyValuePair<string, string> field in fields)
                    {
                        bool fieldValid = false;
                        switch((RequiredFields)requiredFields.ToList().IndexOf(field.Key))
                        {
                            case RequiredFields.BirthYear:
                                /* 4 digits; Must be between [1920-2002] */
                                if(field.Value.Length == 4)
                                {
                                    int birthYear = int.Parse(field.Value);
                                    if(birthYear >= 1920 && birthYear <= 2002)
                                    {
                                        fieldValid = true;
                                    }
                                }
                                break;

                            case RequiredFields.IssueYear:
                                /* 4 digits; Must be between [2010-2020] */
                                if(field.Value.Length == 4)
                                {
                                    int issueYear = int.Parse(field.Value);
                                    if(issueYear >= 2010 && issueYear <= 2020)
                                    {
                                        fieldValid = true;
                                    }
                                }
                                break;

                            case RequiredFields.ExpirationYear:
                                /* 4 digits; Must be between [2020-2030] */
                                if(field.Value.Length == 4)
                                {
                                    int expirationYear = int.Parse(field.Value);
                                    if(expirationYear >= 2020 && expirationYear <= 2030)
                                    {
                                        fieldValid = true;
                                    }
                                }
                                break;

                            case RequiredFields.Height:
                                /* Number followed by "cm" or "in"; "cm" number must be [150-193]; "in" number must be [59-76] */
                                if(field.Value.Length >= 4)
                                {
                                    if(field.Value.Substring(field.Value.Length - 2, 2).Equals("cm"))
                                    {
                                        int height = int.Parse(field.Value.Substring(0, field.Value.Length - 2));
                                        if(height >= 150 && height <= 193)
                                        {
                                            fieldValid = true;
                                        }
                                    }
                                    else if(field.Value.Substring(field.Value.Length - 2, 2).Equals("in"))
                                    {
                                        int height = int.Parse(field.Value.Substring(0, field.Value.Length - 2));
                                        if(height >= 59 && height <= 76)
                                        {
                                            fieldValid = true;
                                        }
                                    }
                                }
                                break;

                            case RequiredFields.HairColor:
                                /* '#' followed by exactly 6 characters [0-9,a-f] */
                                if(field.Value[0] == '#')
                                {
                                    fieldValid = new Regex("[0-9,a-f]").IsMatch(field.Value);
                                }
                                break;

                            case RequiredFields.EyeColor:
                                /* Must be "amb", "blu", "brn", "gry", "grn", "hzl", or "oth" */
                                string[] validEyeColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                                fieldValid = validEyeColors.Any(eyeColor => field.Value.Equals(eyeColor));
                                break;

                            case RequiredFields.PassportID:
                                /* 9 digit number including leading zeroes */
                                if(field.Value.Length == 9)
                                {
                                    fieldValid = int.TryParse(field.Value, out _);
                                }
                                break;

                            default:
                                /* Unhandled Field */
                                break;
                        }

                        valid = valid && fieldValid;
                    }

                    if(valid)
                    {
                        result++;
                    }
                }
            }

            /* Return the result */
            return result;
        }
    }
}
