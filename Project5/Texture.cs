using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;

using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace Project5
{
    class Texture
    {
        public readonly int TextureID;

        public readonly float Width;
        public readonly float Height;

        private static Shader _shader;

        private float[] _vertices;
        private uint[] _indices;

        private int _vertexArrayObject;

        private int _vertexBufferObject;
        private int _elementBufferObject;

        public static void SetShader(Shader shader)
        {
            _shader = shader;
        }

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

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            _vertices = new float[]
            {
                0.0f,   0.0f,   0.0f, 0.0f,
                Width,  0.0f,   1.0f, 0.0f,
                Width,  Height, 1.0f, 1.0f,
                0.0f,   Height, 0.0f, 1.0f
            };

            _indices = new uint[] { 0, 1, 2, 3 };

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            _shader.Bind();

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            GL.EnableVertexAttribArray(_shader.VertexLocation);
            GL.VertexAttribPointer(_shader.VertexLocation, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);

            GL.EnableVertexAttribArray(_shader.TexCoordLocation);
            GL.VertexAttribPointer(_shader.TexCoordLocation, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), 2 * sizeof(float));

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        }

        public void Render(float x, float y, Vector2? scale = null)
        {
            GL.BindVertexArray(_vertexArrayObject);

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            _shader.Bind();

            _shader.SetModelview(Matrix4.Identity);
            _shader.LeftMultModelview(Matrix4.CreateTranslation(new Vector3(x, y, 0.0f)));

            if (scale != null)
            {
                _shader.LeftMultModelview(Matrix4.CreateScale(new Vector3(scale.Value.X, scale.Value.Y, 1.0f)));
            }

            _shader.UpdateModelview();

            GL.DrawElements(PrimitiveType.TriangleFan, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Free()
        {
            GL.DeleteTexture(TextureID);

            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);
        }
    }
}
