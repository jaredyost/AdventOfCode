using System.Globalization;

namespace AdventOfCode.Solvers.Y2020
{
    public class Day04 : BaseDay2020
    {
        protected override int Day => 4;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            List<string> passports = GetPassports(aInput);
            return new(passports.Where(ValidatePassportFieldCount).Count().ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            List<string> passports = GetPassports(aInput);
            return new(passports.Where(ValidatePassportData).Count().ToString());
        }

        private static List<string> GetPassports(string[] aInput)
        {
            List<string> passports = [""];
            foreach (string line in aInput)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    passports[passports.Count - 1] = $"{passports[passports.Count - 1]} {line}";
                    continue;
                }

                passports.Add("");
            }

            return passports.Where(x => !string.IsNullOrEmpty(x)).ToList();
        }

        private static bool ValidatePassportFieldCount(string aPassport)
        {
            int fieldCount = aPassport.Count(x => x == ':');
            return fieldCount == 8 || (fieldCount == 7 && !aPassport.Contains("cid"));
        }

        private static bool ValidatePassportData(string aPassport)
        {
            if (ValidatePassportFieldCount(aPassport))
            {
                List<string> data =
                [
                    .. aPassport.Split(' ', StringSplitOptions.RemoveEmptyEntries),
                ];
                foreach (string entry in data)
                {
                    string[] pieces = entry.Split(':');
                    switch (pieces[0])
                    {
                        case "byr":
                            {
                                int year = int.Parse(pieces[1]);
                                if (year < 1920 || year > 2002)
                                {
                                    return false;
                                }
                            }
                            break;

                        case "iyr":
                            {
                                int year = int.Parse(pieces[1]);
                                if (year < 2010 || year > 2020)
                                {
                                    return false;
                                }
                            }
                            break;

                        case "eyr":
                            {
                                int year = int.Parse(pieces[1]);
                                if (year < 2020 || year > 2030)
                                {
                                    return false;
                                }
                            }
                            break;

                        case "hgt":
                            {
                                string units = pieces[1].Substring(pieces[1].Length - 2);
                                switch (units)
                                {
                                    case "cm":
                                        {
                                            int height = int.Parse(
                                                pieces[1].Substring(0, pieces[1].Length - 2)
                                            );
                                            if (height < 150 || height > 193)
                                            {
                                                return false;
                                            }
                                        }
                                        break;

                                    case "in":
                                        {
                                            int height = int.Parse(
                                                pieces[1].Substring(0, pieces[1].Length - 2)
                                            );
                                            if (height < 59 || height > 76)
                                            {
                                                return false;
                                            }
                                        }
                                        break;

                                    default:
                                        return false;
                                }
                            }
                            break;

                        case "hcl":
                            if (
                                pieces[1].Length < 7
                                || pieces[1][0] != '#'
                                || !int.TryParse(
                                    pieces[1].AsSpan(1),
                                    NumberStyles.HexNumber,
                                    CultureInfo.CurrentCulture,
                                    out _
                                )
                            )
                            {
                                return false;
                            }
                            break;

                        case "ecl":
                            if (
                                pieces[1] != "amb"
                                && pieces[1] != "blu"
                                && pieces[1] != "brn"
                                && pieces[1] != "gry"
                                && pieces[1] != "grn"
                                && pieces[1] != "hzl"
                                && pieces[1] != "oth"
                            )
                            {
                                return false;
                            }
                            break;

                        case "pid":
                            if (pieces[1].Length != 9 || !int.TryParse(pieces[1], out _))
                            {
                                return false;
                            }
                            break;

                        default:
                            break;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
