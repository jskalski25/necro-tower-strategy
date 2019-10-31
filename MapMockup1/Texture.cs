using System.Drawing;
using System.Drawing.Imaging;

using OpenTK.Graphics.OpenGL;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace MapMockup1
{
    class Texture
    {
        public readonly int TextureID;
        public readonly float Width;
        public readonly float Height;

        public Texture(string path)
        {
            TextureID = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            using (var image = new Bitmap(path))
            {
                Width = image.Width;
                Height = image.Height;

                var data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            }

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public void Render(float x, float y, float scale)
        {
            GL.LoadIdentity();
            GL.Translate(x, y, 0.0f);

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            GL.Begin(PrimitiveType.Quads);
                GL.TexCoord2(0.0f, 0.0f); GL.Vertex2(0.0f, 0.0f);
                GL.TexCoord2(1.0f, 0.0f); GL.Vertex2(Width * scale, 0.0f);
                GL.TexCoord2(1.0f, 1.0f); GL.Vertex2(Width * scale, Height * scale);
                GL.TexCoord2(0.0f, 1.0f); GL.Vertex2(0.0f, Height * scale);
            GL.End();
        }
    }
}
