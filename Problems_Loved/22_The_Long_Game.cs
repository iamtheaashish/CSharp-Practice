string? name;

do
{
    Console.Write("Enter your name: ");
    name = Console.ReadLine();
} while (string.IsNullOrWhiteSpace(name));

Player newPlayer = new Player(name);

newPlayer.GameLoop();

public class Player
{
    public string Name { get; private set; }
    public int Score { get; private set; } = 0;

    public Player(string name)
    {
        Name = name;

        if (File.Exists($"{Name}.txt"))
        {
            LoadPreviousScore();
        }
        else
        {
            File.WriteAllText($"{Name}.txt", "0");
            Score = 0;
        }
    }

    public void GameLoop()
    {
        while (true)
        {
            Console.WriteLine("Press a key (Enter to exit)");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Enter)
            {
                File.WriteAllText($"{Name}.txt", Score.ToString());
                break;
            }
            Score++;
            DisplayScore();
        }
    }

    private void DisplayScore()
    {
        Console.WriteLine($"\t{Name} your current score is {Score}.");
    }

    private void LoadPreviousScore()
    {
        string StoredScore = File.ReadAllText($"{Name}.txt");

        Score = Convert.ToInt32(StoredScore);
    }
}