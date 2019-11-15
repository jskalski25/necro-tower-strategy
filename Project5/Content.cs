using System.Collections.Generic;

namespace Project5
{
    class Content
    {
        private static List<Texture> _textures = new List<Texture>();

        public static Texture LoadTexture(string path)
        {
            Texture texture = new Texture(path);
            _textures.Add(texture);
            return texture;
        }

        public static void Free()
        {
            foreach(var t in _textures)
            {
                t.Free();
            }
        }
    }
}
