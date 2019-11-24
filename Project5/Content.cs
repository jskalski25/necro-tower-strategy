using System.Collections.Generic;
using System.Drawing;

namespace Project5
{
    class Content
    {
        private static List<Texture> _textures = new List<Texture>();

        public static Texture LoadTexture(string path)
        {
            Texture texture = new Texture(path);
            Bitmap bmp = texture.GetBitmap();

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                Font font = new Font("Arial", 10);
                gfx.DrawString("text", font, Brushes.Black, 18.0f, (bmp.Height - font.Height) / 2);
            }

            texture.ModifyImage(bmp);

            _textures.Add(texture);
            return texture;
        }

        public static void FreeAll()
        {
            foreach(var t in _textures)
            {
                t.Free();
            }
        }
    }
}
