using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NecroTower2.Game.Items;

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

        public Tile GetTile(int x, int y)
        {
            int index = size * y + x;
            return tiles[index];
        }

        public Tile TileAt(float x, float y)
        {
            PointF point = new PointF(x, y);
            MapHelper.ScreenToMap(point, TerrainTypes.Grass.Size, out Point coords);
            return GetTile(coords.X, coords.Y);
        }

        public void Render(float x, float y)
        {
            foreach(var tile in tiles)
            {
                tile.Render(x, y);
            }
        }
    }
}
