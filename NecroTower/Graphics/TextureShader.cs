using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace NecroTower.Graphics
{
    internal class TextureShader : Shader
    {
        private int vertexLocation;
        private int texCoordLocation;
        private int projectionMatrixLocation;
        private int modelviewMatrixLocation;

        private Matrix4 projectionMatrix;
        private Matrix4 modelviewMatrix;

        public TextureShader() : base()
        {
            vertexLocation = 0;
            texCoordLocation = 0;
            projectionMatrixLocation = 0;
            modelviewMatrixLocation = 0;
        }

        public override void LoadProgram()
        {
            var vertexSource = LoadShaderSource("Graphics/shader.vert");
            var vertexShader = LoadShader(ShaderType.VertexShader, vertexSource);

            var fragmentSource = LoadShaderSource("Graphics/shader.frag");
            var fragmentShader = LoadShader(ShaderType.FragmentShader, fragmentSource);

            programID = GL.CreateProgram();
            GL.AttachShader(programID, vertexShader);
            GL.AttachShader(programID, fragmentShader);
            GL.LinkProgram(programID);

            vertexLocation = GL.GetAttribLocation(programID, "aPosition");
            texCoordLocation = GL.GetAttribLocation(programID, "aTexCoord");
            projectionMatrixLocation = GL.GetUniformLocation(programID, "uProjectionMatrix");
            modelviewMatrixLocation = GL.GetUniformLocation(programID, "uModelviewMatrix");
        }

        public void SetVertexPointer(int stride, int offset)
        {
            GL.VertexAttribPointer(vertexLocation, 2, VertexAttribPointerType.Float, false, stride, offset);
        }

        public void EnableVertexPointer()
        {
            GL.EnableVertexAttribArray(vertexLocation);
        }

        public void SetTexCoordPointer(int stride, int offset)
        {
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, stride, offset);
        }

        public void EnableTexCoordPointer()
        {
            GL.EnableVertexAttribArray(texCoordLocation);
        }

        public void SetProjection(Matrix4 matrix)
        {
            projectionMatrix = matrix;
        }

        public void SetModelview(Matrix4 matrix)
        {
            modelviewMatrix = matrix;
        }

        public void LeftMultProjection(Matrix4 matrix)
        {
            projectionMatrix = matrix * projectionMatrix;
        }

        public void LeftMultModelview(Matrix4 matrix)
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
    }
}
