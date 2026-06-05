RecentNumbers recentNumbers = new RecentNumbers {FirstRecent = -1, SecondRecent = -2};
Thread generatingThread = new Thread(GenerateNumbers);
generatingThread.Start(recentNumbers);

while (true)
{
    Console.ReadKey(false);

    bool isDuplicate;
    lock(recentNumbers)
        isDuplicate = recentNumbers.FirstRecent == recentNumbers.SecondRecent;
    
    if (isDuplicate) Console.WriteLine("\tYou found a duplicate!");
    else Console.WriteLine("\tThat is not a duplicate.");
}


void GenerateNumbers(object? o)
{
    if (o == null || o is not RecentNumbers) return;

    RecentNumbers recentNumbers = (RecentNumbers)o;
    Random random = new Random();

    while (true)
    {
        int nextNumber = random.Next(10);
        lock (recentNumbers)
        {
            recentNumbers.SecondRecent = recentNumbers.FirstRecent;
            recentNumbers.FirstRecent = nextNumber;
        }
        Console.WriteLine(nextNumber);
        Thread.Sleep(3000);
    }
}

public class RecentNumbers
{
    public int FirstRecent {get; set;}
    public int SecondRecent {get; set;}
}