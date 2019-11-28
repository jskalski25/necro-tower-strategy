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

        private static PolygonShader shader;

        private float[] vertices;
        private uint[] indices;

        private int vertexArrayObject;

        private int vertexBufferObject;
        private int elementBufferObject;

        public static void SetShader(PolygonShader shader)
        {
            Texture.shader = shader;
        }

        public Texture(Bitmap image)
        {
            TextureID = GL.GenTexture();

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

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

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            vertices = new float[]
            {
                0.0f,   0.0f,   0.0f, 0.0f,
                Width,  0.0f,   1.0f, 0.0f,
                Width,  Height, 1.0f, 1.0f,
                0.0f,   Height, 0.0f, 1.0f
            };

            indices = new uint[] { 0, 1, 2, 3 };

            vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);

            shader.Bind();

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            shader.EnableVertexPointer();
            shader.SetVertexPointer(4 * sizeof(float), 0);

            shader.EnableTexCoordPointer();
            shader.SetTexCoordPointer(4 * sizeof(float), 2 * sizeof(float));

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
        }

        public Texture(string path) : this(new Bitmap(path)) { }

        public void Render(float x, float y, Vector2? scale = null)
        {
            GL.BindVertexArray(vertexArrayObject);

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            shader.Bind();

            shader.SetModelview(Matrix4.Identity);

            if (scale != null)
            {
                shader.LeftMultModelview(Matrix4.CreateScale(new Vector3(scale.Value.X, scale.Value.Y, 1.0f)));
            }

            shader.LeftMultModelview(Matrix4.CreateTranslation(new Vector3(x, y, 0.0f)));

            shader.UpdateModelview();

            GL.DrawElements(PrimitiveType.TriangleFan, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Free()
        {
            GL.DeleteTexture(TextureID);

            GL.DeleteBuffer(vertexBufferObject);
            GL.DeleteVertexArray(vertexArrayObject);
        }

        public Bitmap GetBitmap()
        {
            GL.Ext.GenFramebuffers(1, out int fboID);
            GL.Ext.BindFramebuffer(FramebufferTarget.FramebufferExt, fboID);
            GL.Ext.FramebufferTexture2D(FramebufferTarget.FramebufferExt, FramebufferAttachment.ColorAttachment0Ext, TextureTarget.Texture2D, TextureID, 0);

            Bitmap bmp = new Bitmap((int)Width, (int)Height);
            var data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.ReadPixels(0, 0, bmp.Width, bmp.Height, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            GL.Ext.BindFramebuffer(FramebufferTarget.FramebufferExt, 0);
            GL.Ext.DeleteFramebuffers(1, ref fboID);
            bmp.UnlockBits(data);

            return bmp;
        }

        public void ModifyImage(Bitmap bmp)
        {
            var data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.BindTexture(TextureTarget.Texture2D, TextureID);

            GL.TexSubImage2D(TextureTarget.Texture2D, 0, 0, 0, bmp.Width, bmp.Height, PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
        }
    }
}
