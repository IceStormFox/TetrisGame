using TetrisGame.GameResources;

namespace TetrisGame.Blocks
{
    public class OBlock : Block
    {
        private readonly ElementPosition[][] _tiles = new ElementPosition[][]
        {
            new ElementPosition[] {new (0,0), new (0,1), new (1,0), new (1,1)}
        };
        public override int Id => 4;
        protected override ElementPosition StartOffset => new ElementPosition(0, 4);
        protected override ElementPosition[][] Tiles => _tiles;

    }
}
