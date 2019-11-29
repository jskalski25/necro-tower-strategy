using System.Collections.Generic;
using System.Drawing;

namespace Project5
{
    class Content
    {
        private static List<Texture> textures = new List<Texture>();

        public static Texture LoadTexture(string path)
        {
            Texture texture = new Texture(path);

            textures.Add(texture);

            return texture;
        }

        public static Texture CreateText(int width, int height, string text)
        {
            Texture texture;

            using (Bitmap bmp = new Bitmap(width, height))
            {
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    Font font = new Font("Arial", 14);
                    gfx.DrawString(text, font, Brushes.Black, 18.0f, (bmp.Height - font.Height) / 2);
                }

                texture = new Texture(bmp);
            }

            textures.Add(texture);

            return texture;
        }

        public static void FreeAll()
        {
            foreach(var t in textures)
            {
                t.Free();
            }
        }
    }
}
