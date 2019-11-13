using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Project4
{
    class Window : GameWindow
    {
        private Shader _shader;
        private Texture _texture;

        public Window() : base(800, 600, GraphicsMode.Default, "Hello, World!")
        {
            Load += InitGL;
            Load += LoadShaders;
            Load += LoadMedia;

            RenderFrame += Render;
        }

        private void Render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _shader.SetModelview(Matrix4.Identity);
            _texture.Render(0.0f, 0.0f);

            Context.SwapBuffers();
        }

        private void LoadMedia(object sender, System.EventArgs e)
        {
            _texture = new Texture("Textures/image.png");
        }

        private void LoadShaders(object sender, System.EventArgs e)
        {
            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");

            _shader.Bind();
            _shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f));
            _shader.UpdateProjection();

            _shader.SetModelview(Matrix4.Identity);
            _shader.UpdateModelview();

            Texture.SetShader(_shader);
        }

        private void InitGL(object sender, System.EventArgs e)
        {
            GL.ClearColor(0.8f, 0.8f, 0.8f, 1.0f);
        }
    }
}