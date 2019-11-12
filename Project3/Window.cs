using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Project3
{
    class Window : GameWindow
    {
        private int _vertexBufferObject;
        private int _vertexArrayObject;

        private Shader _shader;

        private readonly float[] _vertices =
        {
            // Position     // Texture
              0.0f,   0.0f, 0.0f, 0.0f,
            200.0f,   0.0f, 1.0f, 0.0f,
            200.0f, 200.0f, 1.0f, 1.0f,
              0.0f, 200.0f, 0.0f, 1.0f
        };

        public Window() : base(800, 600, GraphicsMode.Default, "Hello, World!")
        {
            Load += HandleLoad;
            Unload += HandleUnload;

            UpdateFrame += HandleUpdate;
            RenderFrame += HandleRender;

            Resize += HandleResize;
        }

        private void HandleLoad(object sender, System.EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            var vertexLocation = _shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 2, VertexAttribPointerType.Float, false, 4 * sizeof(float), 0);

            Matrix4 projectionMatrix = Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f);
            _shader.SetMatrix4("uProjectionMatrix", projectionMatrix);

            Matrix4 modelviewMatrix = Matrix4.Identity;
            _shader.SetMatrix4("uModelviewMatrix", modelviewMatrix);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
        }

        private void HandleUnload(object sender, System.EventArgs e)
        {
            _shader.Free();
        }

        private void HandleUpdate(object sender, FrameEventArgs e)
        {
            // TODO
        }

        private void HandleRender(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            GL.DrawArrays(PrimitiveType.Quads, 0, 4);

            Context.SwapBuffers();
        }

        private void HandleResize(object sender, System.EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
        }
    }
}
