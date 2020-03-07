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

        public MainMenuScreen(TextureManager textures, NecroTower2 game) : base(textures, game)
        {
            Title = "Main Menu";

            button = new Button(this, textures.Load("Textures/test.png"), 50, 100, 500, 200);

            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var screen = new GameScreen(textures, game);
            game.SetScreen(screen);
        }
    }
}
