using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace Project5
{
    abstract class ShaderProgram
    {
        protected int programID;

        public int ProgramID { get => programID; }

        public ShaderProgram()
        {
            programID = 0;
        }

        public abstract void LoadProgram();

        public void FreeProgram()
        {
            GL.DeleteProgram(ProgramID);
        }

        public void Bind()
        {
            GL.UseProgram(ProgramID);
        }

        protected string LoadShaderSource(string path)
        {
            using (var src = new StreamReader(path, Encoding.UTF8))
            {
                return src.ReadToEnd();
            }
        }
    }
}
