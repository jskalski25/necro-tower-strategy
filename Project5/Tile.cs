using OpenTK;
using System;

namespace Project5
{
    class Tile
    {
        public int X { get; }
        public int Y { get; }

        public float TextureX { get; }
        public float TextureY { get; }

        private Terrain terrain;

        public Tile(int x, int y, Terrain terrain)
        {
            this.terrain = terrain;

            X = x;
            Y = y;

            Vector4 vector = new Vector4(X, Y, 0.0f, 1.0f);
            vector = Matrix4.CreateRotationZ((float)(Math.PI / 4.0f)) * vector;
            vector = Matrix4.CreateScale((float)Math.Sin(Math.PI / 4.0f), (float)Math.Cos(Math.PI / 4.0f), 1.0f) * vector;
            vector = Matrix4.CreateScale(TextureWidth, TextureHeight, 1.0f) * vector;

            TextureX = vector.X;
            TextureY = vector.Y;
        }

        public float TextureWidth { get => terrain.Texture.Width; }
        public float TextureHeight { get => terrain.Texture.Height; }

        public void Draw(float x, float y)
        {
            terrain.Texture.Render(x + TextureX, y + TextureY);
        }
    }
}
