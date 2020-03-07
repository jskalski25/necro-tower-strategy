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
    internal class GameScreen : Screen
    {
        private readonly Screen pauseScreen;
        private readonly Map map;

        public GameScreen(TextureManager textures, NecroTower2 game) : base(textures, game)
        {
            BuildingTypes.Initialize(textures);
            TerrainTypes.Initialize(textures);
            UnitTypes.Initialize(textures);

            pauseScreen = new PauseScreen(textures, game, this);
            map = MapGenerator.Default();
        }

        public override void OnKeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape) OnPause();
            base.OnKeyDown(sender, e);
        }

        private void OnPause()
        {
            game.SetScreen(pauseScreen);
        }
    }
}
