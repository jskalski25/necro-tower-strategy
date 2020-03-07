using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Game
{
    internal class Map
    {
        private readonly List<Tile> tiles;
        private readonly int size;

        public Map(Terrain terrain, int size)
        {
            this.size = size;
            tiles = new List<Tile>();

            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    var tile = new Tile(terrain, j, i);
                    tiles.Add(tile);
                }
            }
        }

        public Tile TileAt(int x, int y)
        {
            int index = size * y + x;
            return tiles[index];
        }
    }
}
