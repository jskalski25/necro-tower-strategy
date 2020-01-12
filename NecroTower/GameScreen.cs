using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using NecroTower.Mapping;
using Microsoft.Xna.Framework.Graphics;

namespace NecroTower
{
    internal class GameScreen : Screen
    {
        private Vector2 Camera;
        private Map Map;

        public override void Initialize()
        {
            Map = MapGenerator.Default();
            Camera = new Vector2(0, 0);
        }

        public override void LoadContent()
        {
            // TODO
        }

        public override Screen Update()
        {
            return this;
        }

        public override void Draw()
        {
            Sprites.Begin(SpriteSortMode.Deferred, BlendState.Additive);
            Map.Draw(Camera);
            Sprites.End();
        }
    }
}
