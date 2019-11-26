using OpenTK;
using System;
using System.Collections.Generic;

namespace Project5
{
    class Map
    {
        private List<Tile> tiles;

        public float Height { get; }
        public float Width { get; }

        private int side;

        public Map(int a, Terrain terrain)
        {
            side = a;

            tiles = new List<Tile>();
            for (int y = 0; y < side; ++y)
            {
                for (int x = 0; x < side; ++x)
                {
                    Tile tile = new Tile(x, y, terrain);
                    tiles.Add(tile);
                }
            }

            Width = terrain.Texture.Width * side;
            Height = terrain.Texture.Height * side;
        }

        public void Draw(float x, float y)
        {
            foreach(var tile in tiles)
            {
                Vector2 vector = Transform(tile.X, tile.Y, tile.Width, tile.Height);
                tile.Draw(x + vector.X, y + vector.Y);
            }
        }

        public Tile TileAt(int x, int y)
        {
            return tiles.Find(tile => tile.IsAt(x, y));
        }

        private Vector2 Transform(float x, float y, float w, float h)
        {
            Vector4 vector = new Vector4(x, y, 0.0f, 1.0f);
            double phi = Math.PI / 4.0;

            vector = Matrix4.CreateRotationZ((float)-phi) * vector;
            vector = Matrix4.CreateScale((float)Math.Sin(-phi), (float)Math.Cos(-phi), 1.0f) * vector;
            vector.X += (side - 1) / 2;
            vector = Matrix4.CreateScale(w, h, 1.0f) * vector;

            return new Vector2(vector.X, vector.Y);
        }

        private Vector2 ReverseTransform(float x, float y, float w, float h)
        {
            Vector4 vector = new Vector4(x, y, 0.0f, 1.0f);
            double phi = Math.PI / 4.0;

            vector = Matrix4.CreateScale(1.0f / w, 1.0f / h, 1.0f) * vector;
            vector.X -= (side - 1) / 2;
            vector = Matrix4.CreateScale((float)(1.0f / Math.Sin(-phi)), (float)(1.0f / Math.Cos(-phi)), 1.0f) * vector;
            vector = Matrix4.CreateRotationZ((float)phi) * vector;

            return new Vector2(vector.X, vector.Y);
        }
    }
}
