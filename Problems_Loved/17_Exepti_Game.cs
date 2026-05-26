Random cookies = new Random();

List<int> chosenNumbers = new List<int>();

while (true)
{
    int oatmealCookie = cookies.Next(0, 10);
    int input;
    try
    {
        Console.Write("Enter a number between 0 and 10: ");
        input = Convert.ToInt32(Console.ReadLine());
        if (chosenNumbers.Contains(input))
        {
            throw new AlreadyChoosenException($"Number {input} was already chosen by the player.");
        }
        chosenNumbers.Add(input); Console.WriteLine($"You chose {input}.");
        
        if (input == oatmealCookie)
        {
            Console.WriteLine("You loose. You ate an oatmeal cookie.");
            break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid input: please enter a number.");
    }
    catch (AlreadyChoosenException ex)
    {
        Console.WriteLine(ex.Message);
    }
}


public class AlreadyChoosenException : Exception
{
    // default constructor
    public AlreadyChoosenException() { }

    public AlreadyChoosenException(string message) : base(message) { }
}

