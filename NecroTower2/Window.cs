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
        private readonly Framework.Texture buttonTexture;
        private readonly Framework.Texture menuTexture;
        private readonly GUI.Element button1;
        private readonly GUI.Element button2;
        private readonly GUI.ElementGroup menu;

        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            WindowBorder = WindowBorder.Fixed;

            shader = new Framework.TextureShader();
            buttonTexture = new Framework.Texture();
            menuTexture = new Framework.Texture();

            button1 = new GUI.Element
            {
                Background = buttonTexture,
                Y = 40,
                Width = 128,
                Height = 64,
                VerticalAlignment = GUI.Alignment.Center,
                HorizontalAlignment = GUI.Alignment.Center
            };

            button2 = new GUI.Element
            {
                Background = buttonTexture,
                Y = -40,
                Width = 128,
                Height = 64,
                VerticalAlignment = GUI.Alignment.Center,
                HorizontalAlignment = GUI.Alignment.Center
            };

            menu = new GUI.ElementGroup
            {
                Background = menuTexture,
                Width = 256,
                Height = 256,
                VerticalAlignment = GUI.Alignment.Center,
                HorizontalAlignment = GUI.Alignment.Center
            };

            button1.Click += (sender, e) =>
            {
                Exit();
            };

            menu.Add(button1);
            menu.Add(button2);
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

            buttonTexture.LoadImage(new Bitmap("Images/Button.bmp"));
            menuTexture.LoadImage(new Bitmap("Images/Menu.bmp"));

            GL.ClearColor(Color.Black);
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);
            shader.Free();
            buttonTexture.Free();
            menuTexture.Free();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            menu.Render(ClientRectangle, e);
            Context.SwapBuffers();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            menu.MouseDown(ClientRectangle, e);
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
