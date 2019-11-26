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

            foreach(Unit unit in units)
            {
                unit.Texture.Render(x, y - unit.Texture.Height + terrain.Texture.Height);
            }
        }

        public bool IsAt(int x, int y)
        {
            return X == x && Y == y;
        }

        public void Draw(float x, float y) //todo mozna by nazwe zmienic tak zeby mowila ze to tylko terrain
        {
            terrain.Texture.Render(x + TextureX, y + TextureY);
        }

        public void DrawFileContent(float x, float y)
        {
            //Renderowanie budynków
            foreach (Building building in Items.OfType<Building>())
            {
                building.Texture.Render(x + TextureX, y + TextureY);
            }
        }
    }
}
