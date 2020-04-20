using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;
using System.Drawing;

namespace NecroTower2.Game
{
    internal class Terrain
    {
        private Texture texture;

        public PointF Size;

        public float Width { get => texture.Width; }
        public float Height { get => texture.Height; }

        public Terrain(Texture texture)
        {
            this.texture = texture;
            Size = new PointF(Width, Height);
        }

        public void Render(float x, float y)
        {
            texture.Render(x, y);
        }
    }
}
