using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Graphics
{
    internal class TextureManager : IDisposable
    {
        List<Texture2D> textures;

        public TextureManager()
        {
            textures = new List<Texture2D>();
        }

        public Texture2D LoadTexture(string path)
        {
            var texture = new Texture2D(path);
            textures.Add(texture);
            return texture;
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                foreach(var texture in textures)
                {
                    texture.Dispose();
                }

                disposedValue = true;
            }
        }

        ~TextureManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
