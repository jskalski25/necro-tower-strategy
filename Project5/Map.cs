using System.Collections.Generic;
using OpenTK;

namespace Project5
{
    class Map
    {
        private List<Tile> tiles;
        private Vector2 camera;

        public float Height { get; }
        public float Width { get; }

        public Map(int a, Terrain terrain)
        {
            //tiles = MapGenerator.GetSample1(a, terrain); //Pusta mapa

            tiles = MapTemplates.GetSample2(a, terrain); //Mapa z budynkami

            Width = terrain.Texture.Width * a;
            Height = terrain.Texture.Height * a;

            camera = new Vector2(0, 0 - (Height - terrain.Texture.Height) / 2);
        }

        public void Draw(float x, float y)
        {
            foreach(var tile in tiles)
            {
                tile.Draw(x - camera.X, y - camera.Y);
            }

            foreach (var tile in tiles)
            {
                tile.DrawFileContent(x - camera.X, y - camera.Y);
            }
        }
    }
}
