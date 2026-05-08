Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Hello, welcome to Vim Fletcher's Arrow Shop\n");
Console.ForegroundColor = ConsoleColor.White;

// Input begins
Console.WriteLine("Arrowhead Price: 1. Steel (10 gold) 2. Obsidian (5 gold) 3. Wood (3 gold)");
int arrowheadChoice = GetChoice();

Console.WriteLine("Fletching Price: 1. Plastic Feathers (10 gold) 2. Turkey Feathers (5 gold) 3. Goose Feathers (3 gold)");
int fletchingChoice = GetChoice();

Console.WriteLine("Shafts length can in between 60 to 100 centimeters. It cost 0.05 gold/centimeter.");
int shaftLength;
while (true)
{
    Console.Write("What do you choose? ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out shaftLength) &&
        shaftLength >= 60 && shaftLength <= 100)
    {
        break;
    }

    Console.WriteLine("Invalid range. Enter a number between 60 and 100.");
}
// Input ends

ArrowheadType arrowheadType = ArrowheadType.Steel;
FletchingType fletchingType = FletchingType.PlasticFeathers;
//  int shaftlength was directly initialised.

if (arrowheadChoice == 2) arrowheadType = ArrowheadType.Wood;
else arrowheadType = ArrowheadType.Obsidian;

if (fletchingChoice == 2) fletchingType = FletchingType.TurkeyFeathers;
else fletchingType = FletchingType.GooseFeathers;

// an Instance of arrow.
Arrow arrow_customer = new Arrow(arrowheadType, fletchingType, shaftLength);

Console.WriteLine($"The cost of your arrow is {arrow_customer.GetCost()} gold.");

// --> End of Main Method <---
int GetChoice()
{
    int temp;
    while (true)
    {
        Console.Write("What do you choose? ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out temp) &&
            temp >= 1 && temp <= 3)
        {
            break;
        }
    }
    return temp;
}

class Arrow
{

    private ArrowheadType m_ArrowheadType;
    private FletchingType m_FletchingType;
    private int m_shaftLength = 0;

    // class constructors
    public Arrow(ArrowheadType arrowheadType, FletchingType fletchingType, int shaftLength)
    {
        m_ArrowheadType = arrowheadType;
        m_FletchingType = fletchingType;
        m_shaftLength = shaftLength;
    }

    // methods / interfaces accessible to the program.
    public float GetCost()
    {
        float total = 0f;
        if (m_ArrowheadType == ArrowheadType.Steel) total += 10;
        else if (m_ArrowheadType == ArrowheadType.Obsidian) total += 5;
        else if (m_ArrowheadType == ArrowheadType.Wood) total += 3;

        if (m_FletchingType == FletchingType.PlasticFeathers) total += 10;
        else if (m_FletchingType == FletchingType.TurkeyFeathers) total += 5;
        else if (m_FletchingType == FletchingType.GooseFeathers) total += 3;

        // 0.05 gold per centimeter.
        total += m_shaftLength * 0.05f;
        return total;
    }

    // Getters
    public string GetArrowType() => m_ArrowheadType.ToString();
    public string GetFletchingType() => m_FletchingType.ToString();
    public int GetShaftLength() => m_shaftLength;
}

enum ArrowheadType { Steel, Wood, Obsidian };
enum FletchingType { PlasticFeathers, TurkeyFeathers, GooseFeathers };