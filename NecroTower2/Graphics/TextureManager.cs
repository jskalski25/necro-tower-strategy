using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Graphics
{
    internal class TextureManager : IDisposable
    {
        private List<Texture> textures;

        public TextureManager()
        {
            textures = new List<Texture>();
        }

        public Texture Load(string path)
        {
            var texture = new Texture(path);
            textures.Add(texture);
            return texture;
        }

        public Texture Duplicate(Texture texture)
        {
            var newTexture = new Texture(texture);
            textures.Add(newTexture);
            return newTexture;
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
