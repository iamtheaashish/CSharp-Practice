Door Steel = new Door("sexy69");

while (true)
{
    // Console.Clear();
    Console.WriteLine($"The steel door is currently {Steel.CurrentState}.");
    Console.WriteLine("Press: 1. Open, 2. Close, 3. Lock, 4. Change Passcode");
    int input = userInput();

    if (input == 1 && Steel.CurrentState == DoorState.Closed) Steel.ChangeDoorState(Steel.CurrentState, DoorState.Open); // Open if the door is closed.
    if (input == 1 && Steel.CurrentState == DoorState.Locked) Steel.ChangeDoorState(Steel.CurrentState, DoorState.Open); // Open if the door is closed and locked.

    if (input == 2 && Steel.CurrentState == DoorState.Open) Steel.ChangeDoorState(Steel.CurrentState, DoorState.Closed); // Close if the door is open.
    if (input == 2 && Steel.CurrentState == DoorState.Locked) Steel.ChangeDoorState(Steel.CurrentState, DoorState.Closed); // Unlock the door, but keep it closed.

    if (input == 3 && Steel.CurrentState == DoorState.Open) Steel.ChangeDoorState(Steel.CurrentState, DoorState.Locked); // Lock if the door is open.
    if (input == 3 && Steel.CurrentState == DoorState.Closed) Steel.ChangeDoorState(Steel.CurrentState, DoorState.Locked); // Lock if the door is closed.

    if (input == 4)
    {
        Console.Write("Enter Current Passcode: ");
        string? currentCode = Console.ReadLine();
        Console.Write("Enter New Passcode: ");
        string? newCode = Console.ReadLine();

        Steel.ChangePasscode(currentCode, newCode);
    }
}

// ==> The Locked Door --- End of the Main Method.

int userInput()
{
    int input;
    while (true)
    {
        Console.Write("Enter option (1-4): ");

        bool isValid = int.TryParse(Console.ReadLine(), out input);

        if (isValid && input >= 1 && input <= 4)
        {
            break;
        }

        Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
    }
    return input;
}

public class Door
{
    private DoorState _currentState;
    private string _passCode;

    public Door(string passCode)
    {
        _currentState = DoorState.Locked;
        _passCode = passCode;
    }

    // properties
    public DoorState CurrentState
    {
        get => _currentState;
        private set => _currentState = value;
    }     

    // member methods
    public void ChangePasscode(string currentCode, string newCode)
    {
        Console.Clear();
        if (currentCode == _passCode)
        {
            _passCode = newCode;
            Console.WriteLine("Passcode successfully changed.");
        }
        else
        {
            Console.WriteLine("Passcode change was unsuccessful.");
        }

    }
    public void ChangeDoorState(DoorState currentState, DoorState desiredState)
    {
        if (currentState == DoorState.Open && desiredState == DoorState.Closed) CurrentState = DoorState.Closed;
        if (currentState == DoorState.Open && desiredState == DoorState.Locked) CurrentState = DoorState.Locked;

        if (currentState == DoorState.Closed && desiredState == DoorState.Open) CurrentState = DoorState.Open;
        if (currentState == DoorState.Closed && desiredState == DoorState.Locked) CurrentState = DoorState.Locked;

        if (currentState == DoorState.Locked && desiredState == DoorState.Open) // Unlock and open
        {
            Console.Write("The door is currently locked. Enter the passcode: ");
            string? passcodeStr = Console.ReadLine();
            if (passcodeStr != _passCode) Console.WriteLine("Sorry, the passcode was wrong. You can't unlock and open it.");
            else CurrentState = DoorState.Open;
        }
        if (currentState == DoorState.Locked && desiredState == DoorState.Closed) // Unlock but not open
        {
            Console.Write("The door is currently locked. Enter the passcode: ");
            string? passcodeStr = Console.ReadLine();
            if (passcodeStr != _passCode) Console.WriteLine("Sorry, the passcode was wrong. You can't unlock and open it.");
            else CurrentState = DoorState.Closed;
        }
    }
}
public enum DoorState { Open, Closed, Locked }
