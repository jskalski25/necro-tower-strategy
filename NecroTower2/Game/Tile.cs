using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Drawing;

namespace NecroTower2.Game
{
    internal class Tile
    {
        private Terrain terrain;
        private List<Unit> units;

        public Building Building;

        public Point MapCoords;
        public PointF ScreenCoords;

        public PointF Size { get => terrain.Size; }

        public Tile(Terrain terrain, int x, int y)
        {
            this.terrain = terrain;
            MapCoords = new Point(x, y);
            units = new List<Unit>();
            MapHelper.MapToScreen(MapCoords, Size, out ScreenCoords);
        }

        internal void Render(float x, float y)
        {
            terrain.Render(ScreenCoords.X + x, ScreenCoords.Y + y);
            Building?.Render(ScreenCoords.X + x, ScreenCoords.Y + y - Building.Height + terrain.Height);
        }
    }
}
