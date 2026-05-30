Console.WriteLine("1 - Even");
Console.WriteLine("2 - Positive");
Console.WriteLine("3 - Multiple of 10");

int input = int.Parse(Console.ReadLine()!);

Sieve sieve = input switch
{
    // lamda expressions used with delegate
    1 => new Sieve(x => x % 2 == 0),
    2 => new Sieve(x => x > 0),
    3 => new Sieve(x => x % 10 == 0),
    _ => throw new Exception("Invalid choice!"),
};

while (true)
{
    Console.Write("Enter a number to sieve: ");
    int inpNum = int.Parse(Console.ReadLine()!);

    Console.WriteLine(sieve.IsGood(inpNum) ? "Good" : "Bad");
}


bool IsEven(int x) => x % 2 == 0;
bool IsPositive(int x) => x > 0;
bool IsMultiple10(int x) => x % 10 == 0;

public class Sieve
{
    private readonly Func<int, bool> _refine;

    public Sieve(Func<int, bool> refine)
    {
        _refine = refine;
    }

    public bool IsGood(int number) => _refine(number);
}