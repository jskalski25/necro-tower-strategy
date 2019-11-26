using System.Collections.Generic;

namespace Project5
{
    class Tile
    {
        public int X { get; }
        public int Y { get; }

        private Terrain terrain;

        private List<Unit> units;

        public Tile(int x, int y, Terrain terrain)
        {
            this.terrain = terrain;
            units = new List<Unit>();

            X = x;
            Y = y;
        }

        public float Width { get => terrain.Texture.Width; }
        public float Height { get => terrain.Texture.Height; }

        public void Draw(float x, float y)
        {
            terrain.Texture.Render(x, y);

            foreach(Unit unit in units)
            {
                unit.Texture.Render(x, y - unit.Texture.Height + terrain.Texture.Height);
            }
        }

        public bool IsAt(int x, int y)
        {
            return X == x && Y == y;
        }

        public void AddUnit(Unit unit)
        {
            units.Add(unit);
        }
    }
}
