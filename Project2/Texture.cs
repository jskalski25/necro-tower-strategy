using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using System.Drawing;

using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace Project2
{
    class Texture
    {
        private Vector2 offset;

        public readonly float Width;
        public readonly float Height;

        public readonly int TextureID;

        public Texture(string path)
        {
            offset = new Vector2();

            TextureID = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            using (var image = new Bitmap(path))
            {
                Width = image.Width;
                Height = image.Height;

                var data = image.LockBits(
                    new Rectangle(0, 0, image.Width, image.Height),
                    ImageLockMode.ReadOnly,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D,
                    0,
                    PixelInternalFormat.Rgba,
                    image.Width,
                    image.Height,
                    0,
                    PixelFormat.Bgra,
                    PixelType.UnsignedByte,
                    data.Scan0);
            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        }

        public void Render(float x, float y)
        {
            GL.LoadIdentity();
            GL.Translate(x - offset.X, y - offset.Y, 0);
            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            GL.Begin(PrimitiveType.Quads);

            GL.TexCoord2(0, 0); GL.Vertex2(0,       0);
            GL.TexCoord2(1, 0); GL.Vertex2(Width,   0);
            GL.TexCoord2(1, 1); GL.Vertex2(Width,   Height);
            GL.TexCoord2(0, 1); GL.Vertex2(0,       Height);

            GL.End();
        }

        public void FreeTexture()
        {
            GL.DeleteTexture(TextureID);
        }

        public void SetOffset(int x, int y)
        {
            offset.X = x;
            offset.Y = y;
        }
    }
}
