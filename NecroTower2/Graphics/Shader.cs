using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace NecroTower2.Graphics
{
    internal class Shader : IDisposable
    {
        private int programID;

        private int vertexLocation;
        private int texCoordLocation;

        private int modelviewMatrixLocation;
        private Matrix4 modelviewMatrix;

        private int projectionMatrixLocation;
        private Matrix4 projectionMatrix;

        public Shader(string vertexPath, string fragmentPath)
        {
            programID = GL.CreateProgram();

            var vertexShader = LoadShader(vertexPath, ShaderType.VertexShader);
            var fragmentShader = LoadShader(fragmentPath, ShaderType.FragmentShader);

            GL.AttachShader(programID, vertexShader);
            GL.AttachShader(programID, fragmentShader);

            GL.LinkProgram(programID);

            GL.DetachShader(programID, vertexShader);
            GL.DetachShader(programID, fragmentShader);

            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            vertexLocation = GL.GetAttribLocation(programID, "aPosition");
            texCoordLocation = GL.GetAttribLocation(programID, "aTexCoord");

            modelviewMatrixLocation = GL.GetUniformLocation(programID, "uModelviewMatrix");
            projectionMatrixLocation = GL.GetUniformLocation(programID, "uProjectionMatrix");
        }

        private string LoadShaderSource(string path)
        {
            using (var reader =  new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        private int LoadShader(string path, ShaderType type)
        {
            var source = LoadShaderSource(path);
            var shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);
            return shader;
        }

        public void Bind()
        {
            GL.UseProgram(programID);
        }

        public void EnableVertexPointer()
        {
            GL.EnableVertexAttribArray(vertexLocation);
        }

        public void EnableTexCoordPointer()
        {
            GL.EnableVertexAttribArray(texCoordLocation);
        }

        public void DisableVertexPointer()
        {
            GL.DisableVertexAttribArray(vertexLocation);
        }

        public void DisableTexCoordPointer()
        {
            GL.DisableVertexAttribArray(texCoordLocation);
        }

        public void SetVertexPointer(int stride, int offset)
        {
            GL.VertexAttribPointer(vertexLocation, 2, VertexAttribPointerType.Float, false, stride, offset);
        }

        public void SetTexCoordPointer(int stride, int offset)
        {
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, stride, offset);
        }

        public void SetProjection(Matrix4 matrix)
        {
            projectionMatrix = matrix;
        }

        public void SetModelview(Matrix4 matrix)
        {
            modelviewMatrix = matrix;
        }

        public void MultiplyProjection(Matrix4 matrix)
        {
            projectionMatrix = matrix * projectionMatrix;
        }

        public void MultiplyModelview(Matrix4 matrix)
        {
            modelviewMatrix = matrix * modelviewMatrix;
        }

        public void UpdateProjection()
        {
            GL.UniformMatrix4(projectionMatrixLocation, false, ref projectionMatrix);
        }

        public void UpdateModelview()
        {
            GL.UniformMatrix4(modelviewMatrixLocation, false, ref modelviewMatrix);
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(programID);
                disposedValue = true;
            }
        }

        ~Shader()
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
