// string[] inputs = ["L68",
// "L30",
// "R48",
// "L5",
// "R60",
// "L55",
// "L1",
// "L99",
// "R14",
// "L82"];

//READ THE INPUT FILE
FileInfo inputFile = new(args[0]);
IEnumerable<string> fileLines = [];
using (var reader = new StreamReader(inputFile.FullName))
{
    while (!reader.EndOfStream)
    {
        fileLines = fileLines.Append(reader.ReadLine());
    }
}

string[] inputs = fileLines.ToArray();


int dialMin = 0;
int dialMax = 99;
int dialPosition = 50;
int timesOnZero = 0;

Console.WriteLine($"dial current position: {dialPosition}");
Console.WriteLine();

foreach (var input in inputs)
{
    string direction = input.Substring(0, 1);
    int number = int.Parse(input.Substring(1, input.Length - 1));

    var dialStart = dialPosition;
    var inputNumber = number;

    Console.WriteLine($"Start position: {dialStart}");
    Console.WriteLine($"Turn {direction} -- {inputNumber}");

    if (number > dialMax)
    {
        timesOnZero += number / (dialMax + 1);
        number %= dialMax + 1;
    }

    if (direction == "L")
    {
        if (dialPosition - number < dialMin)
        {
            var numberPastZero = number - dialPosition;
            dialPosition = dialMax + 1 - numberPastZero;
            timesOnZero++;
        }
        else
        {
            dialPosition -= number;
        }
    }
    else if (direction == "R")
    {
        if (dialPosition + number > dialMax)
        {
            var numberPastNineNine = number + dialPosition - (dialMax + 1);
            dialPosition = dialMin + numberPastNineNine;
            timesOnZero++;
        }
        else
        {
            dialPosition += number;
        }
    }

    System.Console.WriteLine($"Dial ends on: {dialPosition}");
    Console.WriteLine($"Times on Zero After Update: {timesOnZero}");

    Console.WriteLine();

    //Console.ReadLine();
}

Console.WriteLine($"FINAL RESULT");

Console.WriteLine($"Times on Zero: {timesOnZero}");
Console.WriteLine($"dial current position: {dialPosition}");
Console.WriteLine();
