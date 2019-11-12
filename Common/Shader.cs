using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Text;

namespace Project4
{
    class Shader
    {
        public readonly int ProgramID;

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
    }
}
