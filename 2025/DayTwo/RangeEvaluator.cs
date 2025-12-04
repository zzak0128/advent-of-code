namespace daytwo;

public static class RangeEvaluator
{
    public static ulong EvalRepeat1(string idRange)
    {
        ulong output = 0;

        ulong startingInt = ulong.Parse(idRange.Split("-")[0]);
        ulong endingInt = ulong.Parse(idRange.Split("-")[1]);

        Console.WriteLine($"Range: {startingInt} -- {endingInt}");
        for (ulong i = startingInt; i < endingInt + 1; i++)
        {
            int iLength = i.ToString().Length;

            string firstHalf = i.ToString().Substring(0, iLength / 2);
            string secondHalf = i.ToString().Substring(iLength / 2);

            if (firstHalf.Equals(secondHalf))
            {
                output += i;

                Console.WriteLine($"InvalidId: {i}");
            }
        }

        return output;
    }

    public static ulong EvalRepeat2(string idRange)
    {
        ulong output = 0;

        ulong startingInt = ulong.Parse(idRange.Split("-")[0]);
        ulong endingInt = ulong.Parse(idRange.Split("-")[1]);

        Console.WriteLine($"Range: {startingInt} -- {endingInt}");
        for (ulong i = startingInt; i < endingInt + 1; i++)
        {
            int iLength = i.ToString().Length;

            for (int j = 0; j < iLength; j++)
            {
                int splitBy = iLength / (j + 1);

                //string[] idSplit = i.ToString().Split(""[splitBy]);

                string[] idSplit = SplitStringToSections(i.ToString(), splitBy);
                bool isEqual = true;

                if (idSplit.Length < 2)
                {
                    isEqual = false;
                    break;
                }

                for (int k = 1; k < idSplit.Length; k++)
                {
                    if (!idSplit[0].Equals(idSplit[k]))
                    {
                        isEqual = false;
                        break;
                    }
                }

                if (isEqual)
                {
                    output += i;

                    Console.WriteLine($"InvalidId: {i}");
                    break;
                }
            }
        }

        return output;
    }

    private static string[] SplitStringToSections(string input, int splitInto)
    {
        string[] output = [];
        int totalStringLength = input.Length;
        int sectionSize = totalStringLength / splitInto;

        for (int i = 0; i < totalStringLength; i += sectionSize)
        {
            if (i + sectionSize <= totalStringLength)
            {
                output = output.Append(input.Substring(i, sectionSize)).ToArray();
            }
            else
            {
                output = output.Append(input.Substring(i)).ToArray();
            }
        }

        return output;
    }
}