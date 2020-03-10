using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace NecroTower2.Game
{
    internal class Tile
    {
        private Terrain terrain;
        private List<Unit> units;

        public Building Building;

        public int X;
        public int Y;

        private Matrix4 bigMatrix;

        public Tile(Terrain terrain, int x, int y)
        {
            this.terrain = terrain;
            X = x;
            Y = y;
            units = new List<Unit>();
            var phi = (Math.PI / 4.0);
            bigMatrix = Matrix4.CreateRotationZ((float)phi) * Matrix4.CreateScale(terrain.Width * (float)Math.Sin(phi), terrain.Height * (float)Math.Cos(phi), 1f);
        }

        internal void Render(float x, float y)
        {
            var vec4 = bigMatrix * new Vector4(X, Y, 0f, 1f);
            //vec4 *= Matrix4.CreateTranslation(terrain.Width, 0f, 0f);
            terrain.Render(vec4.X + x, vec4.Y + y);
        }
    }
}
