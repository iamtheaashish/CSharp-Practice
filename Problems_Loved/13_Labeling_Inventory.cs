Console.Clear();
Console.ForegroundColor = ConsoleColor.White;
Console.BackgroundColor = ConsoleColor.Black;

Pack newPack = new Pack(15, 15, 15);
Console.WriteLine($"New Pack is ready.\nMaximum {newPack.MaxItems} items are allowed.\nMaximum {newPack.MaxWeight}KG weight is allowed.\nMaximum {newPack.MaxVolume}L volume is allowed.");
Console.WriteLine("Press the corresponding number to choose an item to pack:");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("1. Arrow(0.1 Kg, 0.05 L)\n2. Bow(1 Kg, 4 L)\n3. Rope(1 Kg, 1.5 L)\n4. Water(2 Kg, 3 L)\n5. Food(1 Kg, 0.5 L)\n6. Sword(5 Kg, 3 L)");

Console.ForegroundColor = ConsoleColor.White;

while (true)
{
    Console.Write("Enter your input: ");
    byte input;

    if (byte.TryParse(Console.ReadLine(), out input) &&
        input >= 1 && input <= 6)
    {
        switch (input)
        {
            case 1:
                if (newPack.Add(new Arrow())) Console.WriteLine("Item was added.");
                else Console.WriteLine("Item wasn't added.");
                break;

            case 2:
                if (newPack.Add(new Bow())) Console.WriteLine("Item was added.");
                else Console.WriteLine("Item wasn't added.");
                break;

            case 3:
                if (newPack.Add(new Rope())) Console.WriteLine("Item was added.");
                else Console.WriteLine("Item wasn't added.");
                break;

            case 4:
                if (newPack.Add(new Water())) Console.WriteLine("Item was added.");
                else Console.WriteLine("Item wasn't added.");
                break;

            case 5:
                if (newPack.Add(new Food())) Console.WriteLine("Item was added.");
                else Console.WriteLine("Item wasn't added.");
                break;

            case 6:
                if (newPack.Add(new Sword())) Console.WriteLine("Item was added.");
                else Console.WriteLine("Item wasn't added.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Enter a number between 1 and 6");
    }
    Console.WriteLine(newPack.ToString());

}


// InventoryItem arrow1 = new Arrow()
//
// Console.WriteLine($"{arrow1.ToString()}")


// ===> End of the main method.

public class InventoryItem
{
    public float ItemWeight { get; }
    public float ItemVolume { get; }

    public InventoryItem(float itemWeight, float itemVolume)
    {
        ItemWeight = itemWeight;
        ItemVolume = itemVolume;
    }
}

public class Arrow : InventoryItem
{
    // constructor
    public Arrow() : base(0.1f, 0.05f)
    {

    }

    public override string ToString()
    {
        return "Arrow";
    }
}
public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f)
    {

    }

    public override string ToString()
    {
        return "Bow";
    }
}
public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f)
    {

    }

    public override string ToString()
    {
        return "Rope";
    }
}
public class Water : InventoryItem
{
    public Water() : base(2f, 3f)
    {

    }

    public override string ToString()
    {
        return "Water";
    }
}
public class Food : InventoryItem
{
    public Food() : base(1f, 0.5f)
    {

    }

    public override string ToString()
    {
        return "Food";
    }
}
public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f)
    {

    }

    public override string ToString()
    {
        return "Sword";
    }
}

// tough one

public class Pack
{
    // array of inventory items
    private InventoryItem[] _items;
    private int _currentItemCount;

    // auto property
    public int MaxItems { get; }
    public float MaxWeight { get; }
    public float MaxVolume { get; }

    // constructor
    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        MaxItems = maxItems;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;

        _items = new InventoryItem[maxItems];
    }

    public bool Add(InventoryItem item)
    {
        if (_currentItemCount >= MaxItems) // last valid index of MaxItems is -1
            return false;

        _items[_currentItemCount] = item;
        _currentItemCount++;

        return true;
    }

    public int CurrentItemCount
    {
        get => _currentItemCount;
    }
    public float CurrentWeight
    {
        get
        {
            float total = 0;
            for (int i = 0; i < _currentItemCount; i++) total += _items[i].ItemWeight;

            return total;
        }
    }
    public float CurrentVolume
    {
        get
        {
            float total = 0;
            for (int i = 0; i < _currentItemCount; i++) total += _items[i].ItemVolume;

            return total;
        }
    }

    // override ToString and method hiding

    public override string ToString()
    {
        string result = "Pack containing: ";
        for (int i = 0; i < _currentItemCount; i++)
        {
            result += $"{_items[i]} ";
        }

        return result;
    }
}