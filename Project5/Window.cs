using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Project5.ConfigManager;
using Project5.Controls;

namespace Project5
{
    enum GameState { Menu, Game }

    class Window : GameWindow
    {
        private PolygonShader shader;
        private Map map;

        private Image banner;
        private Button startButton;
        private Button exitButton;

        private GameState state = GameState.Menu;

        public Window(int width, int height, string title, WindowState windowState) : base(width, height, GraphicsMode.Default, title)
        {
            WindowState = windowState;

            Load += InitGL;
            Load += LoadShaders;
            Load += LoadMedia;

            Unload += Free;

            RenderFrame += Render;

            MouseDown += HandleMouseDown;
        }

        private void HandleMouseDown(object sender, OpenTK.Input.MouseButtonEventArgs e)
        {
            var buttonX = Width / 2 - startButton.Texture.Width / 2;
            var buttonY = Height / 2;
            var buttonHeight = startButton.Texture.Height;
            var buttonWidth = startButton.Texture.Width;
            if (e.X > buttonX && e.X < buttonX + buttonWidth && e.Y > buttonY && e.Y < buttonY + buttonHeight)
            {
                startButton.OnClick(this, EventArgs.Empty);
            }
        }

        private void Free(object sender, EventArgs e)
        {
            shader.FreeProgram();

            Content.FreeAll();
        }

        private void Render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            switch (state)
            {
                case GameState.Menu:
                    DrawStartMenu();
                    break;

                case GameState.Game:
                    map.Draw((Width - map.Width) / 2, (Height - map.Height) / 2);
                    break;
            }

            Context.SwapBuffers();
        }

        private void LoadMedia(object sender, EventArgs e)
        {
            map = new Map(11, Terrain.Grass);

            exitButton = new Button("Exit");
            startButton = new Button("Start");
            banner = new Image("Images/banner.png");
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

        private void DrawStartMenu()
        {
            banner.Texture.Render(Width / 2 - banner.Texture.Width / 2, Height / 6);

            startButton.Render(Width / 2 - startButton.Texture.Width / 2, Height / 2); //new OpenTK.Vector2(10, 10));

            startButton.Click += HandleStart;

            exitButton.Render(Width / 2 - exitButton.Texture.Width / 2, Height / 2 + startButton.Texture.Height + 10);
        }

        private void HandleStart(object sender, EventArgs e)
        {
            state = GameState.Game;
        }
    }
}
