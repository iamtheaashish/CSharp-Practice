// Boss Battle : Hunting the Manticore

int cityHealth = 15;
int manticoreHealth = 10;
int roundNumber = 1;
bool endWhileLoop = false;

// Random Manticore's Range Generator, between 0 to 100.
Random rnd = new Random();
int manticoreRange = rnd.Next(0,101);

Console.Clear();

// functions
int CannonDamage(int roundNumber)
{
    int cannonDamage;
    if (roundNumber % 3 == 0 && roundNumber % 5 == 0)
    {
        cannonDamage = 10;
    }
    else if (roundNumber % 3 == 0 || roundNumber % 5 == 0)
    {
        cannonDamage = 3;
    }
    else
    {
        cannonDamage = 1;
    }
    return cannonDamage;
}

void EvaluateTargetHitMiss(int targetRange)
{
    if (targetRange == manticoreRange)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("That round was a DIRECT HIT!");
        manticoreHealth -= CannonDamage(roundNumber);
    }
    else if (targetRange < manticoreRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("That round FELL SHORT of the target.");
        cityHealth -= 1;
    }
    else if (targetRange > manticoreRange)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("That round OVERSHOT the target.");
        cityHealth -= 1;
    }
}

void EvaluateHealth()
{
    if (cityHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The city of Consolas has been destroyed! You Loose.");
        endWhileLoop = true;
    }
    if (manticoreHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        endWhileLoop = true;
    }
}

while (!endWhileLoop)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {roundNumber}\tCity: {cityHealth}/15\tManticore: {manticoreHealth}/10");

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"The cannon is expected to deal {CannonDamage(roundNumber)} damage this round.");

    Console.ForegroundColor = ConsoleColor.White;
    // Input from Player 2
    Console.Write("Enter desired cannon range: ");
    string? targetRangeStr = Console.ReadLine();
    int targetRange = int.Parse(targetRangeStr);

    EvaluateTargetHitMiss(targetRange);

    roundNumber++;

    EvaluateHealth();
}