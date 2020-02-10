﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using NecroTower2.Graphics;
using NecroTower2.Components.Screens;

namespace NecroTower2
{
    internal class Game : GameWindow
    {
        private Shader shader;
        private Screen screen;

        private TextureManager textures;

        public Game()
        {
            Title = "Hello, World!";
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Black);

            textures = new TextureManager();

            shader = new Shader("Graphics/GLSL/shader.vert", "Graphics/GLSL/shader.frag");
            shader.Bind();

            Texture2D.SetShader(shader);

            shader.SetModelview(Matrix4.Identity);
            shader.UpdateModelview();

            shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, -1.0f, 1.0f));
            shader.UpdateProjection();

            screen = new MainMenuScreen(textures);

            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            screen.OnUpdate(this, e);
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            screen.OnRender(this, e);

            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, -1.0f, 1.0f));
            shader.UpdateProjection();
            base.OnResize(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            shader.Dispose();
            textures.Dispose();

            base.OnUnload(e);
        }
    }
}
