using System.IO;
using OpenTK.Graphics.OpenGL;

namespace Project5
{
    public abstract class Shader
    {
        protected int programID;

        public int ProgramID { get => programID; }

        public void FreeProgram()
        {
            GL.DeleteProgram(ProgramID);
        }

        public void Bind()
        {
            GL.UseProgram(ProgramID);
        }

        protected int LoadShader(ShaderType type, string source)
        {
            var shader = GL.CreateShader(type);

            GL.ShaderSource(shader, source);

            GL.CompileShader(shader);

            return shader;
        }

        protected string LoadShaderSource(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
