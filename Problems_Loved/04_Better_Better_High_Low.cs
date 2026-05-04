/*High-Low Game in C#*/
using static System.Console;

// Generate and store random number between 0 and 100
Random rnd = new Random();
int num = rnd.Next(0,100);

Clear();

WriteLine("Welcome to the High-Low Game.");


for (ushort counter = 1; counter < 8; counter++)
{
    WriteLine($"{8-counter} tries remaining.");

    WriteLine();

    Write("What is your next guess? ");
    string guessStr = ReadLine();
    uint guess = uint.Parse(guessStr);

    if (guess == num)
    {
        WriteLine("You guessed the number!");
        break;
    }
    if (guess > 100)
    {
        WriteLine("Seriously? Are you dumb? ;/");
        continue;
    }
    if (guess > num)
    {
        WriteLine($"{guess} is too high.");
        
    }
    if (guess < num)
    {
        WriteLine($"{guess} is too low.");
        
    }
}


WriteLine($"The Answer was {num}.");

WriteLine();
WriteLine("Game Over.");
