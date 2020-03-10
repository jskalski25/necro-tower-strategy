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

        public float Width { get => terrain.Width; }
        public float Height { get => terrain.Height; }

        private Vector4 screenCoord;

        public Tile(Terrain terrain, int x, int y)
        {
            this.terrain = terrain;
            X = x;
            Y = y;
            units = new List<Unit>();
            screenCoord = new Vector4(x, y, 0f, 1f);
            ProcessPos(ref screenCoord);
        }

        private void ProcessPos(ref Vector4 vec4)
        {
            var phi = -(Math.PI / 4.0);
            vec4 = Matrix4.CreateRotationZ((float)phi) * vec4;
            vec4 = Matrix4.CreateScale((float)Math.Sin(phi), (float)Math.Cos(phi), 1f) * vec4;
            vec4 = Matrix4.CreateScale(terrain.Width, terrain.Height, 1f) * vec4;
        }

        private void ReprocessPos(ref Vector4 vec4)
        {
            var phi = -(Math.PI / 4.0);
            vec4 = Matrix4.CreateScale(1f / terrain.Width, 1f / terrain.Height, 1f) * vec4;
            vec4 = Matrix4.CreateScale((float)(1 / Math.Sin(phi)), (float)(1 / Math.Cos(phi)), 1f) * vec4;
            vec4 = Matrix4.CreateRotationZ(-(float)phi) * vec4;
        }

        public bool Contains(float x, float y)
        {
            /* not sure if this works, needs testing */
            var vec4 = new Vector4(screenCoord);
            ReprocessPos(ref vec4);
            if (Math.Floor(vec4.X) == X && Math.Floor(vec4.Y) == Y) return true;
            return false;
        }

        internal void Render(float x, float y)
        {
            terrain.Render(screenCoord.X + x, screenCoord.Y + y);
            Building?.Render(screenCoord.X + x, screenCoord.Y + y - Building.Height + terrain.Height);
        }
    }
}
