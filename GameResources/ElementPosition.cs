namespace TetrisGame.GameResources
{
    public class ElementPosition
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public ElementPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
