using OpenTK.Graphics.OpenGL;
using System.IO;

namespace NecroTower.Graphics
{
    internal abstract class Shader
    {
        protected int programID;

        public Shader()
        {
            programID = 0;
        }

        public abstract void LoadProgram();

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

        public void Bind()
        {
            GL.UseProgram(programID);
        }

        public void Free()
        {
            if (programID != 0)
            {
                GL.DeleteProgram(programID);
                programID = 0;
            }
        }
    }
}
