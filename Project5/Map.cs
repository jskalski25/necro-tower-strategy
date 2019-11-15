using System.Collections.Generic;
using OpenTK;

namespace Project5
{
    class Map
    {
        private List<Tile> _tiles;
        private Vector2 _camera;

        public Map(int a, Texture texture)
        {
            _tiles = new List<Tile>();
            for (int y = 0; y < a; ++y)
            {
                for (int x = 0; x < a; ++x)
                {
                    Tile tile = new Tile(x, y, texture);
                    _tiles.Add(tile);
                }
            }

            float camX = texture.Width * a / 2;
            float camY = texture.Height * a / 2;
            _camera = new Vector2(camX, camY);
        }

        public void Draw(float x, float y)
        {
            foreach(var tile in _tiles)
            {
                float newX = x + tile.X * tile.Width - _camera.X;
                float newY = y + tile.Y * tile.Height - _camera.Y;

                tile.Draw(newX, newY);
            }
        }
    }
}
