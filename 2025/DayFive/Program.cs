using DayFive;

//READ THE INPUT FILE
FileInfo inputFile = new(args[0]);
List<FreshRange> freshRanges = [];
List<FoodId> spoiledIds = [];
bool spaceFound = false;
using (var reader = new StreamReader(inputFile.FullName))
{
    while (!reader.EndOfStream)
    {
        string currentline = reader.ReadLine();
        if (string.IsNullOrEmpty(currentline))
        {
            spaceFound = true;
            continue;
        }
        
        if (!spaceFound)
        {
            freshRanges.Add(new FreshRange(currentline));
        }
        else
        {
            spoiledIds.Add(new FoodId(currentline));
        }
    }
}

List<FoodId> freshFoods = [];
long freshIdCount = 0;
List<string> freshIds = [];
foreach (var freshRange in freshRanges)
{
    freshIds.AddRange(freshRange.GetAllValidIds());
}
freshIds.Distinct().ToList();

freshIdCount = freshIds.LongCount();

foreach (var id in spoiledIds)
{
    ulong currentId = ulong.Parse(id.Id);
    bool found = false;
    foreach (var freshRange in freshRanges)
    {
        ulong startRange = ulong.Parse(freshRange.RangeStart);
        ulong endRange = ulong.Parse(freshRange.RangeEnd);

        if (currentId <= endRange && currentId >= startRange)
        {
            found = true;
        }
    }

    if (found)
    {
        freshFoods.Add(id);
    }
}

Console.WriteLine($"The number of foods that are unspoiled = {freshFoods.Count}");
Console.WriteLine($"the number fo Fresh Food Ids = {freshIdCount}");

