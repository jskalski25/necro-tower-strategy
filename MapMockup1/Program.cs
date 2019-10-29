﻿using System;
using System.Drawing;

using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace MapMockup1
{
    class Program
    {
        static private GameWindow window;
        static private Texture texture;
        static private Map map;
        static private float xCamera;
        static private float yCamera;

        static void Main(string[] args)
        {
            window = new GameWindow(800, 600, GraphicsMode.Default, "Map Mockup");

            xCamera = 0.0f;
            yCamera = 0.0f;

            window.Load += InitGL;
            window.Load += LoadMedia;
            window.UpdateFrame += Update;
            window.RenderFrame += Render;
            window.KeyDown += HandleKeyDown;
            window.Resize += HandleResize;
            window.Unload += FreeMedia;

            window.Run(60.0);
        }

        private static void Update(object sender, FrameEventArgs e)
        {
            KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.W))
            {
                yCamera += 5.0f;
            }

            if (input.IsKeyDown(Key.S))
            {
                yCamera -= 5.0f;
            }

            if (input.IsKeyDown(Key.D))
            {
                xCamera -= 5.0f;
            }

            if (input.IsKeyDown(Key.A))
            {
                xCamera += 5.0f;
            }
        }

        private static void FreeMedia(object sender, EventArgs e)
        {
            GL.DeleteTexture(texture.TextureID);
        }

        private static void LoadMedia(object sender, EventArgs e)
        {
            texture = new Texture("tile.png");

            map = new Map(11, texture);
        }

        private static void HandleKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                window.Close();
            }
        }

        private static void InitGL(object sender, EventArgs e)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, window.Width, window.Height, 0.0, 1.0, -1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.Enable(EnableCap.Texture2D);

            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.ClearColor(Color.Black);
        }

        private static void Render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            map.Render(xCamera + window.Width / 2 - map.Width / 2, yCamera + window.Height / 2 - map.Height / 2);

            window.Context.SwapBuffers();
        }

        private static void HandleResize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
        }
    }
}
