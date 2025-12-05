//READ THE INPUT FILE
using DayFour;

FileInfo inputFile = new(args[0]);

IEnumerable<string> fileLines = [];
using (var reader = new StreamReader(inputFile.FullName))
{
    while (!reader.EndOfStream)
    {
        fileLines = fileLines.Append(reader.ReadLine());
    }
}

char[,] grid = new char[fileLines.Count(), fileLines.First().ToArray().Length];
char[,] updatedGrid = new char[fileLines.Count(), fileLines.First().ToArray().Length];

int totalValidPapers = 0;

for (int i = 0; i < fileLines.Count(); i++)
{
    var lineAsArray = fileLines.ElementAt(i).ToArray();
    for (var j = 0; j < lineAsArray.Length; j++)
    {
        grid.SetValue(lineAsArray[j], i, j);
    }
}

//grid.Print();

int paperCount = 0;
do
{
    updatedGrid = grid.ScanGrid();
    //Console.WriteLine();
    //updatedGrid.Print();
    paperCount = updatedGrid.CountValidPapers();
    totalValidPapers += paperCount;
    grid = updatedGrid.CleanGrid();
    //Console.WriteLine();
    //grid.Print();
}
while (paperCount > 0);

Console.WriteLine($"Total papers to pull: {totalValidPapers}");