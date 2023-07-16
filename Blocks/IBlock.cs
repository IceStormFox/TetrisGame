using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.GameResources;

namespace TetrisGame.Blocks
{
    public class IBlock : Block
    {
        private readonly ElementPosition[][] _tiles = new ElementPosition[][]
        {
            new ElementPosition[] {new(1,0), new(1,1), new(1,2), new(1,3)},
            new ElementPosition[] {new(0,2), new(1,2),new(2,2), new(3,2)},
            new ElementPosition[]{new(2,0), new(2,1), new(2,2),new(2,3)},
            new ElementPosition[]{new(0,1), new(1,1), new(2,1), new(3,1)}
        };
        public override int Id => 1;
        protected override ElementPosition StartOffset => new ElementPosition(-1, 3);
        protected override ElementPosition[][] Tiles => _tiles;
    }
}
