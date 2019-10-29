using System;
using OpenTK;

namespace MapMockup1
{
    class Map
    {
        private readonly int zCount;
        private readonly int area;
        private readonly int side;
        private readonly Texture texture;
        public readonly float Height;
        public readonly float Width;

        public Map(int a, Texture tex)
        {
            zCount = a + a - 1;
            area = a * a;
            side = a;
            texture = tex;

            Height = texture.Height * ((zCount + 1) / 2.0f);
            Width = texture.Width * ((zCount + 1) / 2.0f);
        }

        public void Render(float x, float y)
        {
            //for (int i = 0; i < zCount; ++i)
            //{
            //    for (int j = 0; j < zCount / 2 + 1 - Math.Abs(i - zCount / 2); ++j)
            //    {
            //        float xOffset = x + (Math.Abs(i - zCount / 2) - zCount / 2) * texture.Width / 2 + j * texture.Width + Width / 2;
            //        float yOffset = y + i * texture.Height / 2;
            //        texture.Render(xOffset - texture.Width / 2, yOffset);
            //    }
            //}

            for (int i = 0; i < area; ++i)
            {
                int xOffset = i % side;
                int yOffset = i / side;
                float extraOffset = ((side - 1) * texture.Width / 2);

                Vector2 offset = Translate(xOffset, yOffset, texture.Width, texture.Height);
                texture.Render(offset.X + extraOffset + x, offset.Y + y);
            }
        }

        private Vector2 Translate(float x, float y, float w, float h)
        {
            Vector2 result = new Vector2();

            double phi = Math.PI / 4.0;
            result.X = (float)((Math.Cos(phi) * x - Math.Sin(phi) * y) * Math.Sin(phi) * w);
            result.Y = (float)((Math.Sin(phi) * x + Math.Cos(phi) * y) * Math.Cos(phi) * h);

            return result;
        }
    }
}
