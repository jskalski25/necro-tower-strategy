using NecroTower2.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NecroTower2.Components.Screens
{
    internal class MainMenuScreen : Screen
    {
        private readonly Button button1;

        public MainMenuScreen(TextureManager textures, NecroTower2 game) : base(textures, game)
        {
            Title = "Main Menu";

            var texture1 = textures.FromFile("Textures/test.png");
            button1 = new Button(this, texture1, (int)(game.Width - texture1.Width) / 2, (int)(game.Height - texture1.Height) / 2);
            button1.AddText(textures, "Hello", 50f);

            button1.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var screen = new GameScreen(textures, game);
            game.SetScreen(screen);
        }
    }
}
