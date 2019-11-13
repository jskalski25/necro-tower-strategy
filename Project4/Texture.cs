using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;

using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace Project4
{
    class Texture
    {
        public readonly int TextureID;

        public readonly float Width;
        public readonly float Height;

        private static Shader shader;

        private int _vertexBufferObject;
        private int _elementBufferObject;

        public Texture(string path)
        {
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

                GL.TexImage2D(
                    TextureTarget.Texture2D,
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

            _vertexBufferObject = GL.GenBuffer();
            _elementBufferObject = GL.GenBuffer();

            uint[] indices = { 0, 1, 2, 3 };

            GL.BindBuffer(BufferTarget.ArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        }

        public void Free()
        {
            GL.DeleteTexture(TextureID);

            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteBuffer(_elementBufferObject);
        }

        public static void SetShader(Shader shader)
        {
            Texture.shader = shader;
        }

        public void Render(float x, float y)
        {
            float[] vertices =
            {
                0.0f,  0.0f,
                Width, 0.0f,
                Width, Height,
                0.0f,  Height
            };

            shader.Bind();
            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            shader.EnableVertexPointer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            shader.SetVertexPointer(2 * sizeof(float), 0);

            GL.DrawElements(PrimitiveType.TriangleFan, 4, DrawElementsType.UnsignedInt, 0);
        }
    }
}
