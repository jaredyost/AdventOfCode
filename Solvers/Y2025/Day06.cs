namespace AdventOfCode.Solvers.Y2025
{
    public class Day06 : BaseDay2025
    {
        protected override int Day => 6;

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            // Parse the input
            int numRowDigits = GetNumRowsDigits(aInput);
            ulong[][] digits = new ulong[numRowDigits][];
            for (int i = 0; i < numRowDigits; i++)
            {
                digits[i] =
                [
                    .. aInput[i]
                        .Split(null)
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .Select(ulong.Parse),
                ];
            }

            char[] operators =
            [
                .. aInput[numRowDigits]
                    .Split(null)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x[0]),
            ];

            // Do the math
            ulong grandTotal = 0;
            for (int i = 0; i < operators.Length; i++)
            {
                ulong total = 0;
                if (operators[i] == '*')
                {
                    total = digits[0][i];
                    for (int j = 1; j < digits.Length; j++)
                    {
                        total *= digits[j][i];
                    }
                }
                else
                {
                    for (int j = 0; j < digits.Length; j++)
                    {
                        total += digits[j][i];
                    }
                }

                grandTotal += total;
            }

            return new(grandTotal.ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            // Parse the input
            int numRowDigits = GetNumRowsDigits(aInput);
            List<List<ulong>> digits = [];

            int position = 0;
            do
            {
                int length = aInput[..numRowDigits]
                    .Max(x => x[position..].Split(null)[0].Trim().Length);

                List<ulong> currentDigits = [];
                for (int i = length - 1; i >= 0; i--)
                {
                    ulong currentNumber = 0;
                    for (int j = 0; j < numRowDigits; j++)
                    {
                        if (char.IsNumber(aInput[j][position + i]))
                        {
                            currentNumber =
                                (currentNumber * 10)
                                + ulong.Parse(aInput[j][position + i].ToString());
                        }
                    }
                    currentDigits.Add(currentNumber);
                }

                digits.Add(currentDigits);
                position += length + 1;
            } while (position < aInput[0].Length);
            digits.Reverse();

            char[] operators =
            [
                .. aInput[numRowDigits]
                    .Split(null)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => x[0])
                    .Reverse(),
            ];

            // Do the math
            ulong grandTotal = 0;
            for (int i = 0; i < operators.Length; i++)
            {
                ulong total = 0;
                if (operators[i] == '*')
                {
                    total = digits[i][0];
                    for (int j = 1; j < digits[i].Count; j++)
                    {
                        total *= digits[i][j];
                    }
                }
                else
                {
                    for (int j = 0; j < digits[i].Count; j++)
                    {
                        total += digits[i][j];
                    }
                }

                grandTotal += total;
            }

            return new(grandTotal.ToString());
        }

        private static int GetNumRowsDigits(string[] aInput)
        {
            return aInput.Where(x => !string.IsNullOrWhiteSpace(x)).Count() - 1;
        }
    }
}
