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
        private readonly Texture hover;

        public readonly float Height;
        public readonly float Width;

        public Map(int a, Texture tex, Texture hov)
        {
            zCount = a + a - 1;
            area = a * a;
            side = a;

            texture = tex;
            hover = hov;

            Height = texture.Height * ((zCount + 1) / 2.0f);
            Width = texture.Width * ((zCount + 1) / 2.0f);
        }

        public void Render(float x, float y, float scale)
        {
            float extraOffset = ((side - 1) * texture.Width * scale / 2);

            for (int i = 0; i < area; ++i)
            {
                int xOffset = i % side;
                int yOffset = i / side;

                Vector2 offset = Translate(xOffset, yOffset, texture.Width * scale, texture.Height * scale);

                /* test code */
                //offset = BackTranslate(offset.X, offset.Y, texture.Width, texture.Height);
                //offset = Translate(offset.X, offset.Y, texture.Width, texture.Height);

                texture.Render(offset.X + extraOffset + x, offset.Y + y, scale);
            }

            Vector2 floorPos = BackTranslate(Program.mousePos.X - extraOffset - x - texture.Width * scale / 2, Program.mousePos.Y - y - texture.Height * scale / 2, texture.Width * scale, texture.Height * scale);
            if (0 <= floorPos.X && floorPos.X <= side - 1 && 0 <= floorPos.Y && floorPos.Y <= side - 1)
            {
                Vector2 actualPos = Translate(floorPos.X, floorPos.Y, hover.Width * scale, hover.Height * scale);
                hover.Render(actualPos.X + extraOffset + x, actualPos.Y + y, scale);
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

        private Vector2 BackTranslate(float x, float y, float w, float h)
        {
            Vector2 result = new Vector2();

            double phi = Math.PI / 4.0;
            double negaphi = Math.PI * 2.0 - phi;

            result.X = (float)Math.Round((Math.Cos(negaphi) * (x / (w * Math.Sin(phi))) - Math.Sin(negaphi) * (y / (h * Math.Cos(negaphi)))));
            result.Y = (float)Math.Round((Math.Sin(negaphi) * (x / (w * Math.Sin(phi))) + Math.Cos(negaphi) * (y / (h * Math.Cos(negaphi)))));

            return result;
        }
    }
}
