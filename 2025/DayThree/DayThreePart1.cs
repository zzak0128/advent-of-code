namespace daythree;

internal static class DayThreePart1
{
    public static int Run(string[] banks)
    {
        int totalJoltage = 0;

        foreach (string bank in banks)
        {
            Console.WriteLine(bank);

            char? highestNumber = null;
            int highIndex = -1;
            char? secondNumber = null;

            int searchNum = 9;
            while (searchNum >= 0)
            {
                var foundIndex = bank.IndexOf(searchNum.ToString());
                if (foundIndex > -1 && foundIndex < bank.Length - 1)
                {
                    highestNumber = bank.ElementAt(foundIndex);
                    highIndex = foundIndex;
                    break;
                }

                searchNum--;
            }

            string secondNumString = bank.Substring(highIndex + 1);
            int secondSearchNum = 9;
            while (secondSearchNum >= 0)
            {
                var foundIndex = secondNumString.IndexOf(secondSearchNum.ToString());
                if (foundIndex > -1)
                {
                    secondNumber = secondNumString.ElementAt(foundIndex);
                    break;
                }

                secondSearchNum--;
            }

            string lineJoltage = $"{highestNumber}{secondNumber}";
            int joltageAsInt = int.Parse(lineJoltage);

            Console.WriteLine(lineJoltage);
            Console.WriteLine();

            totalJoltage += joltageAsInt;
        }

        return totalJoltage;
    }
}
