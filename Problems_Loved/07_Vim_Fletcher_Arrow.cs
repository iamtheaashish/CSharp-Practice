Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Welcome to Vim Fletcher's Arrow Shop");

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Hi, Do you want to buy 1. Standard Arrows or 2. Custom Arrows ?");

Console.ForegroundColor = ConsoleColor.White;
int buyChoice = GetChoice(1, 2, "Invalid Buying Choice, Try Again!");

if (buyChoice == 1) StandardArrow();
else CustomArrow();

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

void StandardArrow()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("========== Standard Arrow ==========");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Here are the specifications for our standard arrows:\n" +
                      "1. The Elite Arrow (Steel, Plastic, 95)\n" +
                      "2. The Beginner Arrow (Wood, Goose, 75)\n" +
                      "3. The Marksman Arrow (Steel, Goose, 65)");

    int standardChoice = GetChoice(1, 3, "Invalid Standard Arrow Choice, Try Again!");

    Arrow arrow = standardChoice switch
    {
        1 => Arrow.CreateEliteArrow(),
        2 => Arrow.CreateBeginnerArrow(),
        3 => Arrow.CreateMarksmanArrow(),
        _ => throw new Exception("Invalid choice")
    };

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine($"The cost of your arrow is {arrow.GetCost()} gold.");
}

void CustomArrow()
{
    Console.Clear();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("========== Custom Arrow ==========");

    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Arrowhead Price: 1. Steel (10 gold) 2. Obsidian (5 gold) 3. Wood (3 gold)");
    int arrowheadChoice = GetChoice(1, 3, "Wrong Arrowhead choice, Try Again!");

    Console.WriteLine("Fletching Price: 1. Plastic Feathers (10 gold) 2. Turkey Feathers (5 gold) 3. Goose Feathers (3 gold)");
    int fletchingChoice = GetChoice(1, 3, "Wrong Fletching choice, Try Again!");

    Console.WriteLine("Shaft length must be between 60 to 100 cm (0.05 gold/cm)");
    int shaftLength = GetChoice(60, 100, "Not within shaft length range, Try Again!");

    ArrowheadType arrowheadType = arrowheadChoice switch
    {
        1 => ArrowheadType.Steel,
        2 => ArrowheadType.Obsidian,
        3 => ArrowheadType.Wood,
        _ => throw new Exception()
    };

    FletchingType fletchingType = fletchingChoice switch
    {
        1 => FletchingType.PlasticFeathers,
        2 => FletchingType.TurkeyFeathers,
        3 => FletchingType.GooseFeathers,
        _ => throw new Exception()
    };

    Arrow arrow = new Arrow(arrowheadType, fletchingType, shaftLength);

    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine($"The cost of your arrow is {arrow.GetCost()} gold.");
}

class Arrow
{
    private ArrowheadType m_ArrowheadType;
    private FletchingType m_FletchingType;
    private int m_shaftLength;

    public Arrow(ArrowheadType arrowheadType, FletchingType fletchingType, int shaftLength)
    {
        m_ArrowheadType = arrowheadType;
        m_FletchingType = fletchingType;
        m_shaftLength = shaftLength;
    }

    public float GetCost()
    {
        float total = m_ArrowheadType switch
        {
            ArrowheadType.Steel => 10,
            ArrowheadType.Obsidian => 5,
            ArrowheadType.Wood => 3
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

    public static Arrow CreateEliteArrow() =>
        new Arrow(ArrowheadType.Steel, FletchingType.PlasticFeathers, 95);

    public static Arrow CreateBeginnerArrow() =>
        new Arrow(ArrowheadType.Wood, FletchingType.GooseFeathers, 75);

    public static Arrow CreateMarksmanArrow() =>
        new Arrow(ArrowheadType.Steel, FletchingType.GooseFeathers, 65);
}

enum ArrowheadType { Steel, Wood, Obsidian }
enum FletchingType { PlasticFeathers, TurkeyFeathers, GooseFeathers }