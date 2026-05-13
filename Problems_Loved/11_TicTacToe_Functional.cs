char[] grid = [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '];

int round = 1;
char currentPlayer = 'X';
bool hasWon = false;

while (true)
{
    Console.Clear();
    Console.WriteLine($"""
        Round {round}, Player: {currentPlayer}
        
         {grid[0]} | {grid[1]} | {grid[2]}
        -----------
         {grid[3]} | {grid[4]} | {grid[5]}
        -----------
         {grid[6]} | {grid[7]} | {grid[8]}
        """);

    if (hasWon || round > 9)
    {
        Console.WriteLine(hasWon ? $"\nPlayer {currentPlayer} wins!" : $"\nDraw!");
        break;
    }

    Console.WriteLine($"\nPress 1-9 to place your {currentPlayer}.");

    char key;
    while ((key = Console.ReadKey(true).KeyChar) is < '1' or > '9' || grid[key - '1'] != ' ');

    grid[key - '1'] = currentPlayer;

    hasWon = (grid[0] != ' ' && grid[0] == grid[1] && grid[1] == grid[2]) ||
          (grid[3] != ' ' && grid[3] == grid[4] && grid[4] == grid[5]) ||
          (grid[6] != ' ' && grid[6] == grid[7] && grid[7] == grid[8]) ||
          (grid[0] != ' ' && grid[0] == grid[3] && grid[3] == grid[6]) ||
          (grid[1] != ' ' && grid[1] == grid[4] && grid[4] == grid[7]) ||
          (grid[2] != ' ' && grid[2] == grid[5] && grid[5] == grid[8]) ||
          (grid[0] != ' ' && grid[0] == grid[4] && grid[4] == grid[8]) ||
          (grid[2] != ' ' && grid[2] == grid[4] && grid[4] == grid[6]);

    if (!hasWon)
    {
        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
        round++;
    }
}