/*High-Low Game in C#*/
using static System.Console;

Clear();
// User1 input.
Write("User 1, enter a number between 0 and 100: ");
string? numStr = ReadLine();
uint num = uint.Parse(numStr);

Clear();

WriteLine("User 2, guess the number.");

while (true)
{
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
        continue;
    }
    if (guess < num)
    {
        WriteLine($"{guess} is too low.");
        continue;
    }
}
