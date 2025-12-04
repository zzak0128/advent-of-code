public static class RangeEvaluator
{
    public static void Eval(string idRange)
    {
        int rangeStart = int.Parse(idRange.Split("-")[0]);
        int rangeEnd = int.Parse(idRange.Split("-")[1]);

        System.Console.WriteLine(rangeStart);
        System.Console.WriteLine(rangeEnd);
    }
}