using TetrisGame.GameResources;

namespace TetrisGame.Blocks
{
    public abstract class Block
    {
        protected abstract ElementPosition[][] Tiles { get; }
        protected abstract ElementPosition StartOffset { get; }
        public abstract int Id { get; }
        private int _rotation;
        private ElementPosition _offset;
        public Block()
        {
            _offset = new ElementPosition(StartOffset.Row, StartOffset.Column);
        }
        public IEnumerable<ElementPosition> TilePositions()
        {
            foreach (ElementPosition position in Tiles[_rotation])
            {
                yield return new ElementPosition(position.Row + _offset.Row, position.Column + _offset.Column);
            }
        }
        public void RotateRight()
        {
            _rotation = (_rotation + 1) % Tiles.Length;
        }
        public void RotateLeft()
        {
            if (_rotation == 0)
            {
                _rotation = Tiles.Length - 1;
            }
            else
            {
                _rotation--;
            }
        }
        public void Move(int rows, int columns)
        {
            _offset.Row += rows;
            _offset.Column += columns;
        }
        public void Reset()
        {
            _rotation = 0;
            _offset.Row = StartOffset.Row;
            _offset.Column = StartOffset.Column;
        }
    }
}
