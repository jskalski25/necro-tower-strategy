using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Drawing.Imaging;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;
using OpenTK;

namespace NecroTower2.Graphics
{
    internal class Texture : IDisposable
    {
        private int textureID;

        private int vertexBufferObjectID;
        private int vertexArrayObjectID;
        private int elementBufferObjectID;

        public float Width;
        public float Height;

        public Texture(Texture original) : this(original.GetImage())
        {
        }

        public Bitmap GetImage()
        {
            var image = new Bitmap((int)Width, (int)Height);
            var data = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.WriteOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.GetTexImage(
                TextureTarget.Texture2D,
                0,
                PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);

            image.UnlockBits(data);
            return image;
        }

        public Texture(Bitmap image)
        {
            textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);

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

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            InitVertexArrays();
        }

        public Texture(string path)
        {
            textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);

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

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);

            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

            InitVertexArrays();
        }

        private void InitVertexArrays()
        {
            float[] vertices = {
                0.0f,  0.0f,    0.0f, 0.0f,
                Width, 0.0f,    1.0f, 0.0f,
                Width, Height,  1.0f, 1.0f,
                0.0f,  Height,  0.0f, 1.0f
            };

            uint[] indices = { 0, 1, 2, 3 };

            vertexArrayObjectID = GL.GenVertexArray();
            vertexBufferObjectID = GL.GenBuffer();
            elementBufferObjectID = GL.GenBuffer();

            GL.BindVertexArray(vertexArrayObjectID);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectID);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObjectID);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            shader.Bind();

            shader.SetVertexPointer(4 * sizeof(float), 0);
            shader.EnableVertexPointer();

            shader.SetTexCoordPointer(4 * sizeof(float), 2 * sizeof(float));
            shader.EnableTexCoordPointer();
        }

        private void FreeVertexArrays()
        {
            GL.DeleteBuffer(vertexBufferObjectID);
            GL.DeleteBuffer(elementBufferObjectID);
            GL.DeleteVertexArray(vertexArrayObjectID);
        }

        private void FreeTexture()
        {
            GL.DeleteTexture(textureID);
        }

        private static Shader shader;

        public static void SetShader(Shader shader)
        {
            Texture.shader = shader;
        }

        public void Render(float x, float y, float width, float height)
        {
            shader.Bind();

            shader.SetModelview(Matrix4.Identity);

            var translationMatrix = Matrix4.CreateTranslation(x, y, 0);
            shader.MultiplyModelview(translationMatrix);

            var scaleX = width / Width;
            var scaleY = height / Height;
            var scaleMatrix = Matrix4.CreateScale(scaleX, scaleY, 1);
            shader.MultiplyModelview(scaleMatrix);

            shader.UpdateModelview();

            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.BindVertexArray(vertexArrayObjectID);
            GL.DrawElements(PrimitiveType.TriangleFan, 4, DrawElementsType.UnsignedInt, 0);
        }

        public void Render(float x, float y)
        {
            Render(x, y, Width, Height);
        }

        public void Render(RectangleF target)
        {
            Render(target.X, target.Y, target.Width, target.Height);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                FreeVertexArrays();
                FreeTexture();

                disposedValue = true;
            }
        }

        ~Texture()
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
