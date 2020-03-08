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
        private Button button1;
        private Button button2;

        public MainMenuScreen(TextureManager textures, NecroTower2 game) : base(textures, game)
        {
            Title = "Main Menu";

            var texture1 = textures.Load("Textures/test.png");
            button1 = new Button(this, texture1, (game.Width - 600) / 2, (game.Height - 200) / 2, 600, 200);

            /* temporary solution */
            var texture2 = textures.Duplicate(texture1);
            using (var image = texture2.GetImage())
            {
                using (var gfx = System.Drawing.Graphics.FromImage(image))
                {
                    var font = new Font(FontFamily.GenericSansSerif, 50);
                    var middle = new PointF((image.Width - gfx.MeasureString("Click me", font).Width) / 2, (image.Height - font.Height) / 2);
                    gfx.DrawString("Click me", font, Brushes.Black, middle);
                }
                texture2.LoadImage(image);
            }
            
            button2 = new Button(this, texture2, (game.Width - 400) / 2, (game.Height - 400) / 2, 400, 400);

            button1.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var screen = new GameScreen(textures, game);
            game.SetScreen(screen);
        }
    }
}
