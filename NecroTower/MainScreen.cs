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
            var rect = Graphics.GraphicsDevice.Viewport.Bounds;
            button = new Button
            {
                Text = "Start",
                Background = Content.Load<Texture2D>("Graphics/tiny_button")
            };
            button.X = (rect.Width - button.Width) / 2;
            button.Y = (rect.Height - button.Height) / 2;
        }

        public IScreen Update()
        {
            button.Update();

            if (button.IsDown)
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
