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
        GUIButton button;

        public override void Initialize()
        {
            button = new GUIButton();
        }

        public override void LoadContent()
        {
            button.Initialize(Content.Load<Texture2D>("Graphics\\Bitmap1"), Vector2.Zero);
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

            if (button.State == GUIButtonState.Clicked)
            {
                return null;
            }

            return this;
        }
    }
}
