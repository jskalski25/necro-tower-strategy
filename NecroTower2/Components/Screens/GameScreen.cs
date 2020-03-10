using NecroTower2.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Game;
using NecroTower2.Game.Items;
using OpenTK.Input;
using OpenTK;
using System.Drawing;

namespace NecroTower2.Components.Screens
{
    internal class GameScreen : Screen
    {
        private readonly Screen pauseScreen;
        private readonly Map map;

        PointF camera;

        public GameScreen(TextureManager textures, NecroTower2 game) : base(textures, game)
        {
            Title = "Playing";

            BuildingTypes.Initialize(textures);
            TerrainTypes.Initialize(textures);
            UnitTypes.Initialize(textures);

            pauseScreen = new PauseScreen(textures, game, this);
            map = MapGenerator.Default();
            camera = new PointF();
        }

        public override void OnUpdateFrame(object sender, FrameEventArgs e)
        {
            var keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Key.W)) camera.Y += 1f;
            if (keyboard.IsKeyDown(Key.S)) camera.Y -= 1f;
            if (keyboard.IsKeyDown(Key.A)) camera.X += 1f;
            if (keyboard.IsKeyDown(Key.D)) camera.X -= 1f;
            base.OnUpdateFrame(sender, e);
        }

        public override void OnRenderFrame(object sender, FrameEventArgs e)
        {
            map.Render(camera.X, camera.Y);
            base.OnRenderFrame(sender, e);
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
