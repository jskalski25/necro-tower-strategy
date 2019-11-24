using System.Collections.Generic;
using OpenTK;

namespace Project5
{
    class Map
    {
        private List<Tile> tiles;
        private Vector2 camera;

        public Map(int a, Terrain terrain)
        {
            tiles = new List<Tile>();
            for (int y = 0; y < a; ++y)
            {
                for (int x = 0; x < a; ++x)
                {
                    Tile tile = new Tile(x, y, terrain);
                    tiles.Add(tile);
                }
            }

            float camX = terrain.Texture.Width * a / 2;
            float camY = terrain.Texture.Height * a / 2;
            camera = new Vector2(camX, camY);
        }

        public void Draw(float x, float y)
        {
            foreach(var tile in tiles)
            {
                tile.Draw(x - camera.X, y - camera.Y);
            }
        }
    }
}
