/*With more features: 
1. Random Number generation, which makes the game fun to play.
2. 7 tries only using a counter variable.*/

/*High-Low Game in C#*/
using static System.Console;

// Generate and store random number between 0 and 100
Random rnd = new Random();
int num = rnd.Next(0,100);

Clear();

WriteLine("Welcome to the High-Low Game.");

ushort counter = 1;

while (counter < 8)
{
    WriteLine($"{8-counter} tries remaining.");

    WriteLine();

    Write("What is your next guess? ");
    string guessStr = ReadLine();
    uint guess = uint.Parse(guessStr);

    counter++;

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
        continue;
    }
    if (guess < num)
    {
        WriteLine($"{guess} is too low.");
        continue;
    }
}

WriteLine();
WriteLine("Game Over.");