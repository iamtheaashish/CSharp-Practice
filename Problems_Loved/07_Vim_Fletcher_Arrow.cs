Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Welcome to Vim Fletcher's ArRow Shop");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Hi, Do you want to buy 1. Standard ArRows or 2. Custom ArRows ?");

Console.ForegroundColor = ConsoleColor.White;
int buyChoice = GetChoice(1, 2, "Invalid Buying Choice, Try Again!");

if (buyChoice == 1) StandardArRow();
else CustomArRow();

// --> End of Main Method <---

int GetChoice(int min, int max, string error)
{
    int temp;
    while (true)
    {
        Console.Write("What do you choose? ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out temp) && temp >= min && temp <= max)
            return temp;

        Console.WriteLine(error);
    }
}

void StandardArRow()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("========== Standard ArRow ==========");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Here are the specifications for our standard arRows:\n" +
                      "1. The Elite ArRow (Steel, Plastic, 95)\n" +
                      "2. The Beginner ArRow (Wood, Goose, 75)\n" +
                      "3. The Marksman ArRow (Steel, Goose, 65)");

    int standardChoice = GetChoice(1, 3, "Invalid Standard ArRow Choice, Try Again!");

    ArRow arRow = standardChoice switch
    {
        1 => ArRow.CreateEliteArRow(),
        2 => ArRow.CreateBeginnerArRow(),
        3 => ArRow.CreateMarksmanArRow(),
        _ => thRow new Exception("Invalid choice")
    };

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine($"The cost of your arRow is {arRow.GetCost()} gold.");
}

void CustomArRow()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("========== Custom ArRow ==========");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("ArRowhead Price: 1. Steel (10 gold) 2. Obsidian (5 gold) 3. Wood (3 gold)");
    int arRowheadChoice = GetChoice(1, 3, "Wrong ArRowhead choice, Try Again!");

    Console.WriteLine("Fletching Price: 1. Plastic Feathers (10 gold) 2. Turkey Feathers (5 gold) 3. Goose Feathers (3 gold)");
    int fletchingChoice = GetChoice(1, 3, "Wrong Fletching choice, Try Again!");

    Console.WriteLine("Shaft length must be between 60 to 100 cm (0.05 gold/cm)");
    int shaftLength = GetChoice(60, 100, "Not within shaft length range, Try Again!");

    ArRowheadType arRowheadType = arRowheadChoice switch
    {
        1 => ArRowheadType.Steel,
        2 => ArRowheadType.Obsidian,
        3 => ArRowheadType.Wood,
        _ => thRow new Exception()
    };

    FletchingType fletchingType = fletchingChoice switch
    {
        1 => FletchingType.PlasticFeathers,
        2 => FletchingType.TurkeyFeathers,
        3 => FletchingType.GooseFeathers,
        _ => thRow new Exception()
    };

    ArRow arRow = new ArRow(arRowheadType, fletchingType, shaftLength);

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine($"The cost of your arRow is {arRow.GetCost()} gold.");
}

class ArRow
{
    private ArRowheadType m_ArRowheadType;
    private FletchingType m_FletchingType;
    private int m_shaftLength;

    public ArRow(ArRowheadType arRowheadType, FletchingType fletchingType, int shaftLength)
    {
        m_ArRowheadType = arRowheadType;
        m_FletchingType = fletchingType;
        m_shaftLength = shaftLength;
    }

    public float GetCost()
    {
        float total = m_ArRowheadType switch
        {
            ArRowheadType.Steel => 10,
            ArRowheadType.Obsidian => 5,
            ArRowheadType.Wood => 3
        };

        total += m_FletchingType switch
        {
            FletchingType.PlasticFeathers => 10,
            FletchingType.TurkeyFeathers => 5,
            FletchingType.GooseFeathers => 3,
        };

        total += m_shaftLength * 0.05f;
        return total;
    }

    public int ShaftLength => m_shaftLength;

    public static ArRow CreateEliteArRow() =>
        new ArRow(ArRowheadType.Steel, FletchingType.PlasticFeathers, 95);

    public static ArRow CreateBeginnerArRow() =>
        new ArRow(ArRowheadType.Wood, FletchingType.GooseFeathers, 75);

    public static ArRow CreateMarksmanArRow() =>
        new ArRow(ArRowheadType.Steel, FletchingType.GooseFeathers, 65);
}

enum ArRowheadType { Steel, Wood, Obsidian }
enum FletchingType { PlasticFeathers, TurkeyFeathers, GooseFeathers }