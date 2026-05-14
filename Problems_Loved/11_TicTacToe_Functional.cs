char[] board = [' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '];
int[] winLines = [0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 3, 6, 1, 4, 7, 2, 5, 8, 0, 4, 8, 2, 4, 6];
char player = 'X';
int movesLeft = 9;

while (true)
{
    Console.Clear();
    Console.WriteLine($"Player: {player}\n\n {board[0]} | {board[1]} | {board[2]}\n---+---+---\n {board[3]} | {board[4]} | {board[5]}\n---+---+---\n {board[6]} | {board[7]} | {board[8]}");
    Console.WriteLine($"\nPress 1-9 on numpad player {player}.");

    int selectedCell;
    while ((selectedCell = "789456123".IndexOf(Console.ReadKey(true).KeyChar)) < 0 || board[selectedCell] != ' ') ;

    board[selectedCell] = player;
    movesLeft--;
    bool hasWinner = false;

    for (int lineStart = 0; lineStart < 24 && !hasWinner; lineStart += 3)
        hasWinner = board[winLines[lineStart]] != ' ' && board[winLines[lineStart]] == board[winLines[lineStart + 1]] && board[winLines[lineStart]] == board[winLines[lineStart + 2]];

    if (hasWinner || movesLeft == 0)
    {
        Console.Clear();
        Console.WriteLine($"Player: {player}\n\n {board[0]} | {board[1]} | {board[2]}\n---+---+---\n {board[3]} | {board[4]} | {board[5]}\n---+---+---\n {board[6]} | {board[7]} | {board[8]}");
        Console.WriteLine(hasWinner ? $"\nPlayer {player} wins!" : "\nDraw!");
        break;
    }
    player = (char)('X' + 'O' - player);
}