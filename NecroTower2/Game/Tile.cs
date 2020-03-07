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
        private Building building;

        public Tile(Terrain terrain)
        {
            this.terrain = terrain;
            units = new List<Unit>();
        }
    }
}
