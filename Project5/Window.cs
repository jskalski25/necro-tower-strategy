﻿using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Project5.ConfigManager;

namespace Project5
{
    class Window : GameWindow
    {
        private PolygonShader shader;
        private Map map;

        public Window(int width, int height, string title, WindowState windowState) : base(width, height, GraphicsMode.Default, title)
        {
            WindowState = windowState;

            Load += InitGL;
            Load += LoadShaders;
            Load += LoadMedia;

            Unload += Free;

            RenderFrame += Render;
        }

        private void Free(object sender, EventArgs e)
        {
            shader.FreeProgram();

            Content.FreeAll();
        }

        private void Render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            map.Draw((Width - map.Width) / 2, (Height - map.Height) / 2);

            Context.SwapBuffers();
        }

        private void LoadMedia(object sender, EventArgs e)
        {
            map = new Map(5, Terrain.Grass);
        }

        private void LoadShaders(object sender, EventArgs e)
        {
            shader = new PolygonShader();
            shader.Bind();

            shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f));
            shader.UpdateProjection();

            shader.SetModelview(Matrix4.Identity);
            shader.UpdateModelview();

            Texture.SetShader(shader);
        }

        private void InitGL(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}
