
//READ THE INPUT FILE
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

foreach (var id in idRanges)
{
    RangeEvaluator.Eval(id);
}

