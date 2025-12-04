using System.Text;

namespace daythree;

internal static class DayThreePart2
{
    public static ulong Run(string[] banks)
    {
        ulong output = 0;
        foreach (var bank in banks)
        {
            Console.WriteLine(bank);

           int[] batteries = [];
           string topNums = FindHighestNumbersString(bank);
            Console.WriteLine($"num = {topNums}");
            output += ulong.Parse(topNums);
        }


        return output;
    }

    private static string FindHighestNumbersString(string bank)
    {
        Dictionary<int, int> bankAsDict = new();
        int currentIndex = 0;
        foreach (var ch in bank.ToCharArray())
        {
            bankAsDict.Add(currentIndex ,int.Parse(ch.ToString()));
            currentIndex++;
        }

        bankAsDict = bankAsDict.OrderByDescending(x => x.Value).Take(12).ToDictionary();
        bankAsDict = bankAsDict.OrderBy(x => x.Key).ToDictionary();

        StringBuilder sb = new();
        foreach (var num in bankAsDict)
        {
            sb.Append(num.Value.ToString());
        }

        return sb.ToString();
    }
}
