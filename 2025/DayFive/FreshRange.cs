namespace DayFive;

public class FreshRange
{
    public string RangeStart { get; set; }

    public string RangeEnd { get; set; }

    public FreshRange(string range)
    {
        string[] rangeSplit = range.Split('-');
        RangeStart = rangeSplit[0];
        RangeEnd = rangeSplit[1];
    }

    public List<string> GetAllValidIds()
    {
        List<string> output = [];
        ulong startRange = ulong.Parse(RangeStart);
        ulong endRange = ulong.Parse(RangeEnd);
        
        for (ulong i = startRange; i <= endRange; i++)
        {
            output.Add(i.ToString());
        }

        return output;
    }
}