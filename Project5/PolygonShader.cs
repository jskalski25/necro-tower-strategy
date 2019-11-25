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

        public PolygonShader()
        {
            var vertexShaderSource = LoadShaderSource("Shaders/shader.vert");
            var vertexShader = LoadShader(ShaderType.VertexShader, vertexShaderSource);

            var fragmentShaderSource = LoadShaderSource("Shaders/shader.frag");
            var fragmentShader = LoadShader(ShaderType.FragmentShader, fragmentShaderSource);

            shaderProgram = GL.CreateProgram();
            GL.AttachShader(shaderProgram, vertexShader);
            GL.AttachShader(shaderProgram, fragmentShader);

            GL.LinkProgram(shaderProgram);

            vertexLocation = GL.GetAttribLocation(ShaderProgram, "aPosition");
            texCoordLocation = GL.GetAttribLocation(ShaderProgram, "aTexCoord");

            projectionMatrixLocation = GL.GetUniformLocation(ShaderProgram, "uProjectionMatrix");
            modelviewMatrixLocation = GL.GetUniformLocation(ShaderProgram, "uModelviewMatrix");
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
    }
}
