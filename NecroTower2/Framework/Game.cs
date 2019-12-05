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

        public GameWindow Window { get; private set; }

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

            Initialize();
        }

        public void Start()
        {
            Window.Run(60.0);
        }

        private void WindowResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Window.Width, Window.Height);
            Shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Window.Width, Window.Height, 0.0f, 1.0f, -1.0f));
            Shader.UpdateProjection();
        }

        private void WindowUnload(object sender, EventArgs e)
        {
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

            Load();
        }

        private void WindowRender(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Render(e.Time);

            Window.Context.SwapBuffers();
        }

        private void WindowUpdate(object sender, FrameEventArgs e)
        {
            Update(e.Time);
        }

        protected abstract void Initialize();

        protected abstract void Load();

        protected abstract void Render(double frametime);

        protected abstract void Update(double frametime);

        public void Dispose()
        {
            Window.Dispose();
        }
    }
}
