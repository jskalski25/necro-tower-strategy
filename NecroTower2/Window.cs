using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace NecroTower
{
    internal class Window : GameWindow
    {
        private readonly Framework.TextureShader shader;
        private readonly Framework.Texture texture;
        private readonly GUI.Element element;

        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            WindowBorder = WindowBorder.Fixed;

            shader = new Framework.TextureShader();
            texture = new Framework.Texture();

            element = new GUI.Element
            {
                Background = texture,
                Width = Width / 2,
                Height = Height / 2,
                VerticalAlignment = GUI.Alignment.Center,
                HorizontalAlignment = GUI.Alignment.Center
            };

            element.Click += (sender, e) =>
            {
                Exit();
            };
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            shader.LoadProgram();
            shader.Bind();

            shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f));
            shader.UpdateProjection();

            shader.SetModelview(Matrix4.Identity);
            shader.UpdateModelview();

            Framework.Texture.Shader = shader;

            texture.LoadImage(new Bitmap("Images/Bitmap1.bmp"));

            GL.ClearColor(Color.Black);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            shader.Free();
            texture.Free();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            element.Render(ClientRectangle, e);
            Context.SwapBuffers();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            element.MouseDown(ClientRectangle, e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
            shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f));
            shader.UpdateProjection();
        }
    }
}
