using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NecroTower.GUI;

namespace NecroTower
{
    internal class MainScreen : GameObject, IScreen
    {
        Button button;

        public MainScreen()
        {
            button = new Button();
            button.Initialize(Vector2.Zero, "Start", Fonts.Default, Content.Load<Texture2D>("Graphics/tiny_button"));
            var rectangle = Graphics.GraphicsDevice.Viewport.Bounds;
            button.X = (rectangle.Width - button.Width) / 2;
            button.Y = (rectangle.Height - button.Height) / 2;
        }

        public IScreen Update()
        {
            button.Update();

            if (button.Clicked)
            {
                return new GameScreen();
            }

            return this;
        }

        public void Draw()
        {
            Sprites.Begin();
            button.Draw();
            Sprites.End();
        }
    }
}
