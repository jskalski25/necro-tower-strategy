using System;

namespace MapMockup1
{
    class Map
    {
        private readonly int zCount;
        private readonly Texture texture;
        public readonly float Height;
        public readonly float Width;

        public Map(int a, Texture tex)
        {
            zCount = a + a - 1;
            texture = tex;

            Height = texture.Height * ((zCount + 1) / 2.0f);
            Width = texture.Width * ((zCount + 1) / 2.0f);
        }

        public void Render(float x, float y)
        {
            for (int i = 0; i < zCount; ++i)
            {
                for (int j = 0; j < zCount / 2 + 1 - Math.Abs(i - zCount / 2); ++j)
                {
                    float xOffset = x + (Math.Abs(i - zCount / 2) - zCount / 2) * texture.Width / 2 + j * texture.Width + Width / 2;
                    float yOffset = y + i * texture.Height / 2;
                    texture.Render(xOffset - texture.Width / 2, yOffset);
                }
            }
        }
    }
}
