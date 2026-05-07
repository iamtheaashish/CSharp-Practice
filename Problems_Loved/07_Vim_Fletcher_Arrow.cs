Console.Clear();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Hello, welcome to Vim Fletcher's Arrow Shop\n");
Console.ForegroundColor = ConsoleColor.White;

// Input begins
Console.WriteLine("Arrowhead Price: 1. Steel (10 gold) 2. Wood (3 gold) 3. Obsidian(5 gold)");
int arrowheadChoice;
while (true)
{
    Console.Write("What do you choose? ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out arrowheadChoice) &&
        arrowheadChoice >= 1 && arrowheadChoice <= 3)
    {
        break;
    }

    Console.WriteLine("Invalid choice. Enter 1, 2, or 3.");
}

Console.WriteLine("Fletching Price: 1. Plastic Feathers (10 gold) 2. Turkey Feathers (5 gold) 3. Goose Feathers (3 gold)");
int fletchingChoice;
while (true)
{
    Console.Write("What do you choose? ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out fletchingChoice) &&
        fletchingChoice >= 1 && fletchingChoice <= 3)
    {
        break;
    }

    Console.WriteLine("Invalid choice. Enter 1, 2, or 3.");
}

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

ArrowheadType arrowheadType = new();
FletchingType fletchingType = new();
//  int shaftlength is already there.


if (arrowheadChoice == 1) arrowheadType = ArrowheadType.steel;
else if (arrowheadChoice == 2) arrowheadType = ArrowheadType.wood;
else if (arrowheadChoice == 3) arrowheadType = ArrowheadType.obsidian;

if (fletchingChoice == 1) fletchingType = FletchingType.plasticFeathers;
else if (fletchingChoice == 2) fletchingType = FletchingType.turkeyFeathers;
else if (fletchingChoice == 3) fletchingType = FletchingType.gooseFeathers;

// an Instance of arrow.
Arrow arrow_customer = new Arrow(arrowheadType, fletchingType, shaftLength);

Console.WriteLine($"The cost of your arrow is {arrow_customer.GetCost()} gold sir.");

// --> End of Main Method

class Arrow
{

    public ArrowheadType m_ArrowheadType;
    public FletchingType m_FletchingType;
    public int m_shaftLength = 0;

    public Arrow(ArrowheadType arrowheadType, FletchingType fletchingType, int shaftLength)
    {
        m_ArrowheadType = arrowheadType;
        m_FletchingType = fletchingType;
        m_shaftLength = shaftLength;
    }

    public float GetCost()
    {
        float total = 0f;
        if(m_ArrowheadType == ArrowheadType.steel) total+=10;
        else if(m_ArrowheadType == ArrowheadType.wood) total+=3;
        else if(m_ArrowheadType == ArrowheadType.obsidian) total+=5;

        if(m_FletchingType == FletchingType.plasticFeathers) total+=10;
        else if(m_FletchingType == FletchingType.turkeyFeathers) total+=5;
        else if(m_FletchingType == FletchingType.gooseFeathers) total+=3;

// 0.05 gold per centimeter.
        total += m_shaftLength * 0.05f;
        return total;
    }
}


enum ArrowheadType { steel, wood, obsidian };
enum FletchingType { plasticFeathers, turkeyFeathers, gooseFeathers };