int cityHealth = 15;
int manticoreHealth = 10;
int roundNumber = 1;

Random rnd = new();
int manticoreRange = rnd.Next(0, 101);

Console.Clear();


while (true)
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {roundNumber}\tCity: {cityHealth}/15\tManticore: {manticoreHealth}/10");

    int expectedDamage = GetCannonDamage(roundNumber);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine($"The cannon is expected to deal {expectedDamage} damage this round.");
    Console.ForegroundColor = ConsoleColor.White;

    Console.Write("Enter desired cannon range: ");
    string? targetRangeStr = Console.ReadLine();

    if (int.TryParse(targetRangeStr, out int targetRange))
    {
        if (targetRange < 0 || targetRange > 100)
            continue;

        cityHealth--;

        if (EvaluateTargetHit(targetRange))
            manticoreHealth -= expectedDamage;

        if (EvaluateHealth())
            break;

        roundNumber++;
    }
}

int GetCannonDamage(int roundNumber)
{
    if (roundNumber % 3 == 0 && roundNumber % 5 == 0)
        return 10;
    else if (roundNumber % 3 == 0 || roundNumber % 5 == 0)
        return 3;
    else
        return 1;
}

bool EvaluateTargetHit(int targetRange)
{
    if (targetRange == manticoreRange)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("That round was a DIRECT HIT!");
        return true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        if (targetRange < manticoreRange)
            Console.WriteLine("That round FELL SHORT of the target.");

        if (targetRange > manticoreRange)
            Console.WriteLine("That round OVERSHOT the target.");

        return false;
    }
}

bool EvaluateHealth()
{
    if (cityHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The city of Consolas has been destroyed! You lose.");
        return true;
    }

    if (manticoreHealth <= 0)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        return true;
    }

    return false;
}