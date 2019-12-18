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
    internal class MainScreen : Screen
    {
        Button button;

        public override void Initialize()
        {
            button = new Button();
        }

        public override void LoadContent()
        {
            button.Initialize(Content.Load<Texture2D>("Graphics/Bitmap1"), Vector2.Zero, "Start", Fonts.Default);
            var rectangle = Graphics.GraphicsDevice.Viewport.Bounds;
            button.X = (rectangle.Width - button.Width) / 2;
            button.Y = (rectangle.Height - button.Height) / 2;
        }

        public override void Draw()
        {
            Sprites.Begin();
            button.Draw(Sprites);
            Sprites.End();
        }

        public override Screen Update()
        {
            button.Update();

            if (button.State == GUIButtonState.Pressed)
            {
                return null;
            }

            return this;
        }
    }
}
