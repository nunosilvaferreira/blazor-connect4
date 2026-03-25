namespace blazor_connect4;

public sealed class GameState
{
    private const int Rows = 6;
    private const int Columns = 7;
    private readonly byte[,] _board = new byte[Rows, Columns];

    public enum WinState
    {
        None,
        Player1_Wins,
        Player2_Wins,
        Tie
    }

    public int CurrentTurn { get; private set; }

    public byte PlayerTurn => (byte)(CurrentTurn % 2 + 1);

    public void ResetBoard()
    {
        Array.Clear(_board);
        CurrentTurn = 0;
    }

    public byte PlayPiece(byte col)
    {
        if (col >= Columns)
        {
            throw new ArgumentException("Invalid column.");
        }

        if (CheckForWin() is not WinState.None)
        {
            throw new ArgumentException("The game is already finished. Reset to play again.");
        }

        for (var row = Rows - 1; row >= 0; row--)
        {
            if (_board[row, col] != 0)
            {
                continue;
            }

            _board[row, col] = PlayerTurn;
            CurrentTurn++;
            return (byte)(Rows - row);
        }

        throw new ArgumentException("That column is full. Choose another column.");
    }

    public WinState CheckForWin()
    {
        for (var row = 0; row < Rows; row++)
        {
            for (var col = 0; col < Columns; col++)
            {
                var player = _board[row, col];
                if (player == 0)
                {
                    continue;
                }

                if (HasConnectFour(row, col, 0, 1, player) ||
                    HasConnectFour(row, col, 1, 0, player) ||
                    HasConnectFour(row, col, 1, 1, player) ||
                    HasConnectFour(row, col, 1, -1, player))
                {
                    return player == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }
            }
        }

        return CurrentTurn == Rows * Columns ? WinState.Tie : WinState.None;
    }

    private bool HasConnectFour(int row, int col, int rowStep, int colStep, byte player)
    {
        for (var i = 1; i < 4; i++)
        {
            var nextRow = row + rowStep * i;
            var nextCol = col + colStep * i;
            if (nextRow < 0 || nextRow >= Rows || nextCol < 0 || nextCol >= Columns)
            {
                return false;
            }

            if (_board[nextRow, nextCol] != player)
            {
                return false;
            }
        }

        return true;
    }
}
