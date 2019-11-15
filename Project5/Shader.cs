using System;
using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Project5
{
    class Shader
    {
        public readonly int ProgramID;

        public readonly int VertexLocation;
        public readonly int TexCoordLocation;

        private Matrix4 _projectionMatrix;
        private Matrix4 _modelviewMatrix;

        public readonly int ProjectionMatrixLocation;
        public readonly int ModelviewMatrixLocation;

        public Shader(string vertexPath, string fragmentPath)
        {
            var vertexShaderSource = LoadSource(vertexPath);
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);

            var fragmentShaderSource = LoadSource(fragmentPath);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            ProgramID = GL.CreateProgram();

            GL.AttachShader(ProgramID, vertexShader);
            GL.AttachShader(ProgramID, fragmentShader);

            GL.LinkProgram(ProgramID);

            GL.DetachShader(ProgramID, vertexShader);
            GL.DetachShader(ProgramID, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            VertexLocation = GL.GetAttribLocation(ProgramID, "aPosition");
            TexCoordLocation = GL.GetAttribLocation(ProgramID, "aTexCoord");

            ProjectionMatrixLocation = GL.GetUniformLocation(ProgramID, "uProjectionMatrix");
            ModelviewMatrixLocation = GL.GetUniformLocation(ProgramID, "uModelviewMatrix");
        }

        private static string LoadSource(string path)
        {
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }

        public void Free()
        {
            GL.DeleteProgram(ProgramID);
        }

        public void Bind()
        {
            GL.UseProgram(ProgramID);
        }

        public void SetModelview(Matrix4 matrix)
        {
            _modelviewMatrix = matrix;
        }

        public void SetProjection(Matrix4 matrix)
        {
            _projectionMatrix = matrix;
        }

        public void LeftMultModelview(Matrix4 matrix)
        {
            _modelviewMatrix = matrix * _modelviewMatrix;
        }

        public void LeftMultProjection(Matrix4 matrix)
        {
            _projectionMatrix = matrix * _projectionMatrix;
        }

        public void UpdateModelview()
        {
            GL.UniformMatrix4(ModelviewMatrixLocation, false, ref _modelviewMatrix);
        }

        public void UpdateProjection()
        {
            GL.UniformMatrix4(ProjectionMatrixLocation, false, ref _projectionMatrix);
        }
    }
}
