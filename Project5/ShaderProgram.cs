using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace Project5
{
    abstract class ShaderProgram
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

        protected string LoadShaderSource(string path)
        {
            using (var src = new StreamReader(path, Encoding.UTF8))
            {
                return src.ReadToEnd();
            }
        }
    }
}
