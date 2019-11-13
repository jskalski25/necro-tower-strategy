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

        public Matrix4 ProjectionMatrix;
        public Matrix4 ModelviewMatrix;

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

        public void UpdateModelview()
        {
            GL.UniformMatrix4(ModelviewMatrixLocation, false, ref ModelviewMatrix);
        }

        public void UpdateProjection()
        {
            GL.UniformMatrix4(ProjectionMatrixLocation, false, ref ProjectionMatrix);
        }
    }
}
