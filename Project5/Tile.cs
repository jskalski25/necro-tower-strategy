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

        public float TextureX { get; }
        public float TextureY { get; }

        private Terrain terrain;
        public List<GridItem> Items = new List<GridItem>();


        public Tile(int x, int y, Terrain terrain)
        {
            this.terrain = terrain;

            X = x;
            Y = y;

            Vector4 vector = new Vector4(X, Y, 0.0f, 1.0f);
            vector = Matrix4.CreateRotationZ((float)(Math.PI / 4.0f)) * vector;
            vector = Matrix4.CreateScale((float)Math.Sin(Math.PI / 4.0f), (float)Math.Cos(Math.PI / 4.0f), 1.0f) * vector;
            vector = Matrix4.CreateScale(TextureWidth, TextureHeight, 1.0f) * vector;

            TextureX = vector.X;
            TextureY = vector.Y;
        }

        public float TextureWidth { get => terrain.Texture.Width; }
        public float TextureHeight { get => terrain.Texture.Height; }

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
