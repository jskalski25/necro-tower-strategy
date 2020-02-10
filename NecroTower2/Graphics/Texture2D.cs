﻿using System;
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
    internal class Texture2D : IDisposable
    {
        private int textureID;

        private int vertexBufferObjectID;
        private int vertexArrayObjectID;
        private int elementBufferObjectID;

        public float Width;
        public float Height;

        public Texture2D(string path)
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
            Texture2D.shader = shader;
        }

        public void Render(float x, float y)
        {
            shader.Bind();
            shader.SetModelview(Matrix4.Identity);
            shader.MultiplyModelview(Matrix4.CreateTranslation(x, y, 0));
            shader.UpdateModelview();

            GL.BindTexture(TextureTarget.Texture2D, textureID);
            GL.BindVertexArray(vertexArrayObjectID);
            GL.DrawElements(PrimitiveType.TriangleFan, 4, DrawElementsType.UnsignedInt, 0);
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

        ~Texture2D()
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
