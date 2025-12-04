//READ THE INPUT FILE
using daythree;

FileInfo inputFile = new(args[0]);
IEnumerable<string> fileLines = [];
using (var reader = new StreamReader(inputFile.FullName))
{
    while (!reader.EndOfStream)
    {
        fileLines = fileLines.Append(reader.ReadLine());
    }
}

string[] banks = fileLines.ToArray();

//int totalJoltage = 0;
//totalJoltage = DayThreePart1.Run(banks);

ulong totalJoltage = 0;
totalJoltage = DayThreePart2.Run(banks);

Console.WriteLine($"Total Joltage: {totalJoltage}");