namespace TetrisGame.GameResources
{
    public class GameGrid
    {
        private readonly int[,] _grid;
        public int Rows { get; }
        public int Columns { get; }
        public int this[int x, int y]
        {
            get => _grid[x, y];
            set => _grid[x, y] = value;
        }
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            _grid = new int[rows, columns];
        }
        public bool IsInsideGrid(int x, int y)
        {
            return x >= 0 && x < Rows && y >= 0 && y < Columns;
        }
        public bool IsEmptyCell(int x, int y)
        {
            return IsInsideGrid(x, y) && _grid[x, y] == 0;
        }
        public bool IsRowFull(int x)
        {
            for (int y = 0; y < Columns; y++)
            {
                if (_grid[x, y] == 0) return false;
            }
            return true;
        }
        public bool IsRowEmpty(int x)
        {
            for (int y = 0; y < Columns; y++)
            {
                if (_grid[x, y] != 0) return false;
            }
            return true;
        }
        private void ClearRow(int x)
        {
            for (int y = 0; y < Columns; y++)
            {
                _grid[x, y] = 0;
            }
        }
        private void MoveDown(int x, int rowsNum)
        {
            for (int i = 0; x < Columns; x++)
            {
                _grid[x + rowsNum, i] = 0;
                _grid[x, i] = 0;
            }
        }
        public int ClearFullRows()
        {
            int cleared = 0;
            for (int i = Rows - 1; i >= 0; i--)
            {
                if (IsRowFull(i))
                {
                    ClearRow(i);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveDown(i, cleared);
                }
            }
            return cleared;
        }
    }
}
