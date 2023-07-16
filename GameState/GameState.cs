using TetrisGame.Blocks;
using TetrisGame.GameResources;

namespace TetrisGame.GameState
{
    public class GameState
    {
        private Block _currentBlock;

        public Block CurrentBlock
        {
            get => _currentBlock;
            private set
            {
                _currentBlock = value;
                _currentBlock.Reset();
            }
        }
        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }
        private bool BlockFits()
        {
            foreach (ElementPosition position in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmptyCell(position.Row, position.Column))
                {
                    return false;
                }
            }
            return true;
        }
        public void RotateBlockRight() 
        {
            CurrentBlock.RotateRight();
            if(!BlockFits()) 
            { 
                CurrentBlock.RotateLeft(); 
            }
        }
        public void RotateBlockLeft()
        {
            CurrentBlock.RotateLeft();
            if (!BlockFits())
            {
                CurrentBlock.RotateRight();
            }
        }
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }
        private void PlaceBlock()
        {
            foreach (ElementPosition position in CurrentBlock.TilePositions())
            {
                GameGrid[position.Row, position.Column] = CurrentBlock.Id;
            }
            GameGrid.ClearFullRows();

            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }
        public void MoveDown()
        {
            CurrentBlock.Move(1, 0);

            if(!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();
            }
        }
    }
}
