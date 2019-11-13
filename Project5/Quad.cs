using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Project5
{
    class Quad
    {
        private static Shader _shader;

        private float[] _vertices;
        private uint[] _indices;

        private int _vertexArrayObject;

        private int _vertexBufferObject;
        private int _elementBufferObject;

        public static void SetShader(Shader shader)
        {
            _shader = shader;
        }

        public Quad(float w, float h)
        {
            _vertices = new float[]
            {
                0, 0,
                w, 0,
                w, h,
                0, h
            };

            _indices = new uint[] { 0, 1, 2, 3 };

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            _shader.Bind();

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            GL.EnableVertexAttribArray(_shader.VertexLocation);
            GL.VertexAttribPointer(_shader.VertexLocation, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
        }

        public void Render(float x, float y)
        {
            _shader.Bind();

            _shader.ModelviewMatrix = Matrix4.CreateTranslation(new Vector3(x, y, 0.0f)) * _shader.ModelviewMatrix;
            _shader.UpdateModelview();

            GL.BindVertexArray(_vertexArrayObject);

            GL.DrawElements(PrimitiveType.TriangleFan, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Free()
        {
            GL.DeleteBuffer(_vertexBufferObject);
            GL.DeleteVertexArray(_vertexArrayObject);
        }
    }
}
