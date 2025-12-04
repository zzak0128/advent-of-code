//READ THE INPUT FILE
using daytwo;

FileInfo inputFile = new(args[0]);
string fileLine = string.Empty;
using (var reader = new StreamReader(inputFile.FullName))
{
    while (!reader.EndOfStream)
    {
        fileLine = reader.ReadLine();
    }
}

string[] idRanges = fileLine.Split(",");
ulong idTotals = 0;

foreach (var id in idRanges)
{
    idTotals += RangeEvaluator.EvalRepeat2(id);
}

Console.WriteLine($"Total of all id's = {idTotals}");
Console.WriteLine();

