using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace NecroTower.Framework
{
    internal abstract class Game : IDisposable
    {
        private readonly TextureShader Shader;

        private readonly GameWindow Window;

        public Game()
        {
            Shader = new TextureShader();

            Window = new GameWindow
            {
                WindowBorder = WindowBorder.Fixed,
                Width = 800,
                Height = 600,
                Title = "NecroTower"
            };

            Window.UpdateFrame += WindowUpdate;
            Window.RenderFrame += WindowRender;
            Window.Load += WindowLoad;
            Window.Unload += WindowUnload;
            Window.Resize += WindowResize;
        }

        public void Start()
        {
            Window.Run();
        }

        private void WindowResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Window.Width, Window.Height);
            Shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Window.Width, Window.Height, 0.0f, 1.0f, -1.0f));
            Shader.UpdateProjection();
        }

        private void WindowUnload(object sender, EventArgs e)
        {
            TextureManager.FreeAll();
            Shader.Free();
        }

        private void WindowLoad(object sender, EventArgs e)
        {
            Shader.LoadProgram();
            Shader.Bind();

            Shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Window.Width, Window.Height, 0.0f, 1.0f, -1.0f));
            Shader.UpdateProjection();

            Shader.SetModelview(Matrix4.Identity);
            Shader.UpdateModelview();

            Texture.Shader = Shader;

            GL.ClearColor(Color.Black);

            Load(sender, e);
        }

        private void WindowRender(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Render(sender, e);

            Window.Context.SwapBuffers();
        }

        private void WindowUpdate(object sender, FrameEventArgs e)
        {
            Update(sender, e);
        }

        protected abstract void Load(object sender, EventArgs e);

        protected abstract void Render(object sender, FrameEventArgs e);

        protected abstract void Update(object sender, FrameEventArgs e);

        public void Dispose()
        {
            Window.Dispose();
        }
    }
}
