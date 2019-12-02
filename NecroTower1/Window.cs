﻿using NecroTower.Graphics;
using NecroTower.States;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace NecroTower
{
    internal class Window : GameWindow
    {
        private readonly TextureShader shader;
        private readonly StateStack states;
        private readonly MainMenuState mainMenu;
        private readonly GameState game;

        public Window(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            shader = new TextureShader();
            states = new StateStack();
            mainMenu = new MainMenuState();
            game = new GameState();

            mainMenu.Exit += (sender, e) =>
            {
                Exit();
            };

            mainMenu.Start += (sender, e) =>
            {
                states.Push(game);
            };
        }

        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);

            shader.Free();

            mainMenu.Free();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

            shader.LoadProgram();
            shader.Bind();

            shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f));
            shader.UpdateProjection();

            shader.SetModelview(Matrix4.Identity);
            shader.UpdateModelview();

            Texture.Shader = shader;

            mainMenu.Load();
            states.Push(mainMenu);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            states.Update(this, e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);

            states.Render(this, e);

            Context.SwapBuffers();
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            states.MouseDown(this, e);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);

            shader.SetProjection(Matrix4.CreateOrthographicOffCenter(0.0f, Width, Height, 0.0f, 1.0f, -1.0f));
            shader.UpdateProjection();

            states.Resize(this, e);
        }
    }
}