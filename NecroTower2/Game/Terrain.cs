using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Game
{
    internal class Terrain
    {
        private Texture texture;

        public float Width { get => texture.Width; }
        public float Height { get => texture.Height; }

        public Terrain(Texture texture)
        {
            this.texture = texture;
        }

        public void Render(float x, float y)
        {
            texture.Render(x, y);
        }
    }
}
