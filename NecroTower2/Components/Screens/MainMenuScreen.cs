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
        private Button button1;
        private Button button2;

        public MainMenuScreen(TextureManager textures, NecroTower2 game) : base(textures, game)
        {
            Title = "Main Menu";

            var texture1 = textures.Load("Textures/test.png");
            button1 = new Button(this, texture1, 50, 150, 500, 200);

            var texture2 = textures.Duplicate(texture1);
            button2 = new Button(this, texture2, 200, 50, 200, 400);

            button1.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var screen = new GameScreen(textures, game);
            game.SetScreen(screen);
        }
    }
}
