using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Project5
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

            Unload += Free;

            RenderFrame += Render;
        }

        private void Free(object sender, EventArgs e)
        {
            _shader.Free();

            Content.Free();
        }

        private void Render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _texture.Render(50.0f, 50.0f);

            Context.SwapBuffers();
        }

        private void LoadMedia(object sender, EventArgs e)
        {
            _texture = Content.LoadTexture("image.png");
        }

        private void LoadShaders(object sender, EventArgs e)
        {
            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Bind();

            _shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f));
            _shader.UpdateProjection();

            _shader.SetModelview(Matrix4.Identity);
            _shader.UpdateModelview();

            Texture.SetShader(_shader);
        }

        private void InitGL(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}
