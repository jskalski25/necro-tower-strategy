using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing.Imaging;
using PixelFormat = OpenTK.Graphics.OpenGL.PixelFormat;

namespace NecroTower.Framework
{
    internal class Texture
    {
        private int textureID;
        private int vertexArrayObjectID;
        private int vertexBufferObjectID;
        private int elementBufferObjectID;

        public Texture()
        {
            Width = 0;
            Height = 0;

            textureID = 0;
            vertexBufferObjectID = 0;
            elementBufferObjectID = 0;
        }

        public void LoadImage(Bitmap image)
        {
            FreeTexture();

            Width = image.Width;
            Height = image.Height;

            textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureID);

            var data = image.LockBits(
                new Rectangle(0, 0, Width, Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                Width,
                Height,
                0,
                PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Nearest);

            InitBuffers();
            UpdateBuffers();
            InitVertexArray();
        }

        public void Render(Rectangle target)
        {
            GL.BindVertexArray(vertexArrayObjectID);

            GL.BindTexture(TextureTarget.Texture2D, textureID);

            Shader.Bind();

            Shader.SetModelview(Matrix4.Identity);
            Shader.LeftMultModelview(Matrix4.CreateTranslation(target.X, target.Y, 0.0f));
            Shader.LeftMultModelview(Matrix4.CreateScale((float)target.Width / Width, (float)target.Height / Height, 1.0f));
            Shader.UpdateModelview();

            GL.DrawElements(PrimitiveType.TriangleFan, 4, DrawElementsType.UnsignedInt, 0);
        }

        public void Render(int x, int y)
        {
            GL.BindVertexArray(vertexArrayObjectID);

            GL.BindTexture(TextureTarget.Texture2D, textureID);

            Shader.Bind();

            Shader.SetModelview(Matrix4.Identity);
            Shader.LeftMultModelview(Matrix4.CreateTranslation(x, y, 0.0f));
            Shader.UpdateModelview();

            GL.DrawElements(PrimitiveType.TriangleFan, 4, DrawElementsType.UnsignedInt, 0);
        }

        public void Free()
        {
            FreeBuffers();
            FreeVertexArray();
            FreeTexture();
        }

        public static TextureShader Shader { get; set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        private void InitBuffers()
        {
            if (vertexBufferObjectID == 0)
            {
                uint[] indices = { 0, 1, 2, 3 };
                float[] vertices = new float[16];

                vertexBufferObjectID = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectID);
                GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);

                elementBufferObjectID = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObjectID);
                GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.DynamicDraw);
            }
        }

        private void InitVertexArray()
        {
            if (vertexArrayObjectID == 0)
            {
                vertexArrayObjectID = GL.GenVertexArray();
                GL.BindVertexArray(vertexArrayObjectID);

                Shader.Bind();

                GL.BindTexture(TextureTarget.Texture2D, textureID);

                Shader.EnableVertexPointer();
                Shader.SetVertexPointer(4 * sizeof(float), 0);

                Shader.EnableTexCoordPointer();
                Shader.SetTexCoordPointer(4 * sizeof(float), 2 * sizeof(float));

                GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectID);
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObjectID);
            }
        }

        private void UpdateBuffers()
        {
            if (vertexBufferObjectID != 0)
            {
                float[] vertices =
                {
                    0.0f,   0.0f,   0.0f, 0.0f,
                    Width,  0.0f,   1.0f, 0.0f,
                    Width,  Height, 1.0f, 1.0f,
                    0.0f,   Height, 0.0f, 1.0f
                };

                GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObjectID);
                GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.DynamicDraw);
            }
        }

        private void FreeBuffers()
        {
            if (vertexBufferObjectID != 0)
            {
                GL.DeleteBuffer(vertexBufferObjectID);
                GL.DeleteBuffer(elementBufferObjectID);
            }
        }

        private void FreeVertexArray()
        {
            if (vertexArrayObjectID != 0)
            {
                GL.DeleteVertexArray(vertexArrayObjectID);
            }
        }

        private void FreeTexture()
        {
            if (textureID != 0)
            {
                GL.DeleteTexture(textureID);
                textureID = 0;
            }

            Width = 0;
            Height = 0;
        }
    }
}
