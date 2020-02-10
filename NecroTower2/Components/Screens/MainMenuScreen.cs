using NecroTower2.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Components.Screens
{
    internal class MainMenuScreen : Screen
    {
        private Button button;

        public MainMenuScreen(TextureManager textures) : base(textures)
        {
            button = new Button(this)
            {
                Background = textures.LoadTexture("Textures/test.png")
            };
        }
    }
}
