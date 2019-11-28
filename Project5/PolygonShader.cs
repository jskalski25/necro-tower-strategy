using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Project5
{
    public class PolygonShader : Shader
    {
        private int vertexLocation;
        private int texCoordLocation;

        private Matrix4 projectionMatrix;
        private int projectionMatrixLocation;

        private Matrix4 modelviewMatrix;
        private int modelviewMatrixLocation;

        public Matrix4 ProjectionMatrix { get => projectionMatrix; set => projectionMatrix = value; }

        public Matrix4 ModelviewMatrix { get => modelviewMatrix; set => modelviewMatrix = value; }

        public PolygonShader()
        {
            var vertexShaderSource = LoadShaderSource("Shaders/shader.vert");
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, vertexShaderSource);
            GL.CompileShader(vertexShader);

            var fragmentShaderSource = LoadShaderSource("Shaders/shader.frag");
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, fragmentShaderSource);
            GL.CompileShader(fragmentShader);

            programID = GL.CreateProgram();

            GL.AttachShader(programID, vertexShader);
            GL.AttachShader(programID, fragmentShader);

            GL.LinkProgram(programID);

            GL.DetachShader(programID, vertexShader);
            GL.DetachShader(programID, fragmentShader);
            GL.DeleteShader(vertexShader);
            GL.DeleteShader(fragmentShader);

            vertexLocation = GL.GetAttribLocation(ProgramID, "aPosition");
            texCoordLocation = GL.GetAttribLocation(ProgramID, "aTexCoord");

            projectionMatrixLocation = GL.GetUniformLocation(ProgramID, "uProjectionMatrix");
            modelviewMatrixLocation = GL.GetUniformLocation(ProgramID, "uModelviewMatrix");
        }

        public void EnableVertexPointer()
        {
            GL.EnableVertexAttribArray(vertexLocation);
        }

        public void EnableTexCoordPointer()
        {
            GL.EnableVertexAttribArray(texCoordLocation);
        }

        public void SetVertexPointer(int stride, int offset)
        {
            GL.VertexAttribPointer(vertexLocation, 2, VertexAttribPointerType.Float, false, stride, offset);
        }

        public void SetTexCoordPointer(int stride, int offset)
        {
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, stride, offset);
        }

        public void UpdateProjection()
        {
            GL.UniformMatrix4(projectionMatrixLocation, false, ref projectionMatrix);
        }

        public void UpdateModelview()
        {
            GL.UniformMatrix4(modelviewMatrixLocation, false, ref modelviewMatrix);
        }
    }
}
