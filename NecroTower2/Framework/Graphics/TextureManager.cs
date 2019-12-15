using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NecroTower.Framework.Graphics
{
    internal static class TextureManager
    {
        private static List<Texture> textures;

        public static Texture LoadTexture(string path)
        {
            if (textures == null) textures = new List<Texture>();
            var texture = new Texture();
            texture.LoadImage(new Bitmap(path));
            textures.Add(texture);
            return texture;
        }

        public static void FreeTexture(Texture texture)
        {
            textures.Remove(texture);
            texture.Free();
        }

        public static void FreeAll()
        {
            foreach (var texture in textures)
            {
                texture.Free();
            }
            textures.Clear();
        }
    }
}
