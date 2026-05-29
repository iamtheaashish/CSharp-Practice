CharberryTree tree = new CharberryTree();
Notifier newNoti = new Notifier(tree);
Harvester newHarv = new Harvester(tree);

while (true)
    tree.MaybeGrow();

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.Ripened += OnTreeRipe;
    }

    private void OnTreeRipe()
    {
        Console.WriteLine("A charberry fruit has ripened!");
    }
}

public class Harvester
{
    private CharberryTree _tree;
    public Harvester(CharberryTree tree)
    {
        _tree = tree;
        _tree.Ripened += OnTreeRipe;
    }

    private void OnTreeRipe()
    {
        Console.WriteLine("Ripe property is being set to false.");
        _tree.Ripe = false;
    }
}

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public event Action? Ripened;

    public void MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot!
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            Ripened.Invoke();
        }
    }

}