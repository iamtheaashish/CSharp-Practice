Console.Clear();

TicTacToe Game1 = new TicTacToe();

Game1.GameLoop();


// ==> End of main method.
class TicTacToe
{
    private char _player1 = 'O';
    private char _player2 = 'X';
    private char[] _grid = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };

    // default constructor
    public TicTacToe()
    {
    }

    // methods
    private void DisplayGrid()
    {
        Console.WriteLine($" {_grid[6]} | {_grid[7]} | {_grid[8]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {_grid[3]} | {_grid[4]} | {_grid[5]} ");
        Console.WriteLine("---+---+---");
        Console.WriteLine($" {_grid[0]} | {_grid[1]} | {_grid[2]} ");
        // Console.WriteLine("---|---|---");
    }
    private byte TakeInput(char player)
    {
        while (true)
        {
            Console.Write($"It is {player}'s turn. What position do you want to play in?: ");

            if (byte.TryParse(Console.ReadLine(), out byte position) && position >= 1 && position <= 9 && _grid[position - 1] == ' ' /*Position Occupied*/)
                return position;

            Console.WriteLine("Invalid option. Enter a number between 1 and 9. Make sure the position is empty.");
        }
    }

    private void StoreValueInGrid(char player, byte position)
    {
        _grid[position - 1] = player;
    }

    private bool CheckWin(char player)
    {
        // columns
        if ((_grid[6] == player) && (_grid[3] == player) && (_grid[0] == player))
            return true;
        if ((_grid[7] == player) && (_grid[4] == player) && (_grid[1] == player))
            return true;
        if ((_grid[8] == player) && (_grid[5] == player) && (_grid[2] == player))
            return true;

        // rows
        if ((_grid[6] == player) && (_grid[7] == player) && (_grid[8] == player))
            return true;
        if ((_grid[3] == player) && (_grid[4] == player) && (_grid[5] == player))
            return true;
        if ((_grid[0] == player) && (_grid[1] == player) && (_grid[2] == player))
            return true;

        // diagonals
        if ((_grid[6] == player) && (_grid[4] == player) && (_grid[2] == player))
            return true;
        if ((_grid[8] == player) && (_grid[4] == player) && (_grid[0] == player))
            return true;

        return false;
    }

    private bool CheckDraw()
    {
        foreach (char position in _grid)
        {
            if (position == ' ')
                return false;
        }

        return true;
    }

    public void GameLoop()
    {
        char currentPlayer = _player1;
        while (true)
        {
            Console.WriteLine("Use your numpad as a reference to play.");
            DisplayGrid();
            byte position = TakeInput(currentPlayer);

            StoreValueInGrid(currentPlayer, position);

            if (CheckWin(currentPlayer))
            {
                Console.Clear();
                Console.WriteLine($"The {currentPlayer} has won!");
                break;
            }
            if (CheckDraw())
            {
                Console.Clear();
                Console.WriteLine("It's a draw, Nobody won!");
                break;
            }
            
            // switch turns between players
            if (currentPlayer == _player1) currentPlayer = _player2;
            else currentPlayer = _player1;
        }
        DisplayGrid();

        Console.WriteLine("Game over!");
    }

}