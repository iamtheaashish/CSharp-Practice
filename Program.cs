Console.WriteLine("Hello world");

InventoryItem rope1 = new Rope();

Console.WriteLine(rope1.ItemVolume);

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
}
public class Bow : InventoryItem
{
    public Bow() : base(1f, 4f)
    {
        
    }
}
public class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f)
    {
        
    }
}
public class Water : InventoryItem
{
    public Water() : base(2f, 3f)
    {
        
    }
}
public class Food : InventoryItem
{
    public Food() : base(1f, 0.5f)
    {
        
    }
}
public class Sword : InventoryItem
{
    public Sword() : base(5f, 3f)
    {
        
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
        if(_items[_currentItemCount] >= _items[MaxItems]) // last valid index of MaxItems is -1
        return false;

        _items[_currentItemCount] = item;
        _currentItemCount++;
    }

}