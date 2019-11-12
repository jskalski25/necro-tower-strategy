using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Project4
{
    class Window : GameWindow
    {
        public Window() : base(800, 600, GraphicsMode.Default, "Hello, World!")
        {
            Load += InitGL;
            RenderFrame += Render;
        }

        private void Render(object sender, FrameEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void InitGL(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}