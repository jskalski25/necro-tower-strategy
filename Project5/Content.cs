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

        public static void FreeAll()
        {
            foreach(var t in textures)
            {
                t.Free();
            }
        }
    }
}
