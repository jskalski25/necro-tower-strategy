using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Project5
{
    class Window : GameWindow
    {
        private PolygonProgram _shader = new PolygonProgram();
        private Map _map;

        public Window() : base(800, 600, GraphicsMode.Default, "Hello, World!")
        {
            Load += InitGL;
            Load += LoadShaders;
            Load += LoadMedia;

            Unload += Free;

            RenderFrame += Render;
        }

        private void Free(object sender, EventArgs e)
        {
            _shader.FreeProgram();

            Content.Free();
        }

        private void Render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _map.Draw(Width / 2, Height / 2);

            Context.SwapBuffers();
        }

        private void LoadMedia(object sender, EventArgs e)
        {
            _map = new Map(3, Content.LoadTexture("image.png"));
        }

        private void LoadShaders(object sender, EventArgs e)
        {
            _shader.LoadProgram();
            _shader.Bind();

            _shader.ProjectionMatrix = Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f);
            _shader.UpdateProjection();

            _shader.ModelviewMatrix = Matrix4.Identity;
            _shader.UpdateModelview();

            Texture.SetShader(_shader);
        }

        private void InitGL(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}
