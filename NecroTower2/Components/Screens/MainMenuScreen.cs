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

        public MainMenuScreen(TextureManager textures, Game game) : base(textures, game)
        {
            button = new Button(this)
            {
                Background = textures.LoadTexture("Textures/test.png")
            };

            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            game.Close();
        }
    }
}
