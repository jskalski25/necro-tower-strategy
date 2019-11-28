using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using Project5.GridElementsRepo;

namespace Project5
{
    internal class Tile
    {
        public int X { get; }
        public int Y { get; }

        private Terrain terrain;
        public List<GridItem> Items = new List<GridItem>();


        public Tile(int x, int y, Terrain terrain)
        {
            this.terrain = terrain;

            X = x;
            Y = y;
        }

        public float Width { get => terrain.Texture.Width; }
        public float Height { get => terrain.Texture.Height; }

        public void Draw(float x, float y)
        {
            terrain.Texture.Render(x, y);

            foreach (Building building in Items.OfType<Building>())
            {
                building.Texture.Render(x, y - building.Texture.Height + terrain.Texture.Height);
            }
        }

        public bool IsAt(int x, int y)
        {
            return X == x && Y == y;
        }
    }
}
