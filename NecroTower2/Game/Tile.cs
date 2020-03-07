using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Game
{
    internal class Tile
    {
        private Terrain terrain;
        private List<Unit> units;

        public Building Building;

        public int X;
        public int Y;

        public Tile(Terrain terrain, int x, int y)
        {
            this.terrain = terrain;
            X = x;
            Y = y;
            units = new List<Unit>();
        }
    }
}
