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
    internal class GameScreen : GameObject, IScreen
    {
        private Vector2 Camera;
        private Map Map;

        public GameScreen()
        {
            Map = MapGen.Default();
            Camera = new Vector2(0, 0);
        }

        public IScreen Update()
        {
            return this;
        }

        public void Draw()
        {
            Sprites.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Map.Draw(Camera);
            Sprites.End();
        }
    }
}
