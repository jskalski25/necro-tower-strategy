using NecroTower2.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Game;
using NecroTower2.Game.Items;

namespace NecroTower2.Components.Screens
{
    internal class GameScreen : Screen
    {
        private readonly Screen pauseScreen;

        public GameScreen(TextureManager textures, NecroTower2 game) : base(textures, game)
        {
            Buildings.Initialize(textures);
            Terrains.Initialize(textures);
            Units.Initialize(textures);

            pauseScreen = new PauseScreen(textures, game, this);
        }

        private void OnPause()
        {
            game.SetScreen(pauseScreen);
        }
    }
}
