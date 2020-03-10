using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NecroTower2.Graphics
{
    internal class TextureManager : IDisposable
    {
        private List<Texture> textures;

        public TextureManager()
        {
            textures = new List<Texture>();
        }

        public Texture FromFile(string path)
        {
            var texture = new Texture(path);
            textures.Add(texture);
            return texture;
        }

        public Texture FromText(int width, int height, string text, Font font, Brush brush)
        {
            using (var image = new Bitmap(width, height))
            {
                using (var gfx = System.Drawing.Graphics.FromImage(image))
                {
                    var size = gfx.MeasureString(text, font);
                    var offsetX = (width - size.Width) / 2;
                    var offsetY = (width - size.Height) / 2;
                    gfx.DrawString(text, font, brush, offsetX, offsetY);
                }
                var texture = new Texture(image);
                textures.Add(texture);
                return texture;
            }
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
