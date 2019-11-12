using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Project3
{
    class Shader
    {
        public readonly int ProgramID;

        private readonly Dictionary<string, int> _uniformLocations;

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

            GL.GetProgram(ProgramID, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
            _uniformLocations = new Dictionary<string, int>();

            for (var i = 0; i < numberOfUniforms; i++)
            {
                var key = GL.GetActiveUniform(ProgramID, i, out _, out _);
                var location = GL.GetUniformLocation(ProgramID, key);
                _uniformLocations.Add(key, location);
            }
        }
        private static string LoadSource(string path)
        {
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                return sr.ReadToEnd();
            }
        }
        public void SetMatrix4(string name, Matrix4 data)
        {
            Use();
            GL.UniformMatrix4(_uniformLocations[name], true, ref data);
        }

        public int GetAttribLocation(string name)
        {
            return GL.GetAttribLocation(ProgramID, name);
        }

        public void Free()
        {
            GL.DeleteProgram(ProgramID);
        }

        public void Use()
        {
            GL.UseProgram(ProgramID);
        }
    }
}
