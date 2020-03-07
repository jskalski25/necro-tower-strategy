using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Game
{
    internal class Map
    {
        private List<Tile> tiles;

        private int size;

        public Map(Terrain terrain, int size)
        {
            this.size = size;
            tiles = new List<Tile>();

            int area = size * size;
            for (int i = 0; i < area; ++i)
            {
                var tile = new Tile(terrain);
                tiles.Add(tile);
            }
        }
    }
}
