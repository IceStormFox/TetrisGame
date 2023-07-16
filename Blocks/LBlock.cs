﻿using TetrisGame.GameResources;

namespace TetrisGame.Blocks
{
    public class LBlock : Block
    {
        private readonly ElementPosition[][] _tiles = new ElementPosition[][]
        {
            new ElementPosition[] {new(0,2), new(1,0), new(1,1), new(1,2)},
            new ElementPosition[] {new(0,1), new(1,1),new(2,1), new(2,2)},
            new ElementPosition[]{new(1,0), new(1,1), new(1,2),new(2,0)},
            new ElementPosition[]{new(0,0), new(0,1), new(1,1), new(2,1)}
        };
        public override int Id => 3;
        protected override ElementPosition StartOffset => new ElementPosition(0, 3);
        protected override ElementPosition[][] Tiles => _tiles;
    }
}
