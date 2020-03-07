using NecroTower2.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Game;
using NecroTower2.Game.Items;
using OpenTK.Input;

namespace NecroTower2.Components.Screens
{
    internal class PauseScreen : Screen
    {
        private Screen prevScreen;

        public PauseScreen(TextureManager textures, NecroTower2 game, Screen screen) : base(textures, game)
        {
            Title = "Paused";

            prevScreen = screen;
        }

        public override void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape) OnUnpause();
            base.OnKeyDown(sender, e);
        }

        private void OnUnpause()
        {
            game.SetScreen(prevScreen);
        }
    }
}
