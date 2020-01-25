using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower.Mapping
{
    internal class Map : GameObject // TODO: simplify this class
    {
        private List<Tile> tiles;
        private int size;

        public float Width
        {
            get
            {
                return size * Terrain.Default.Texture.Width;
            }
        }

        public float Height
        {
            get
            {
                return size * Terrain.Default.Texture.Height;
            }
        }

        public Map()
        {
            tiles = new List<Tile>();
        }

        public void Initialize(int size, Terrain terrain)
        {
            this.size = size;
            for(int i = 0; i < size*size; ++i)
            {
                Tile tile = new Tile
                {
                    Terrain = terrain,
                    X = i % size,
                    Y = i / size
                };
                tiles.Add(tile);
            }
        }

        public void Draw(Vector2 camera)
        {
            camera.X += (Graphics.GraphicsDevice.Viewport.Width - Width) / 2;
            camera.X += Terrain.Default.Texture.Width * size / 2;
            camera.Y += (Graphics.GraphicsDevice.Viewport.Height - Height) / 2;

            foreach (var tile in tiles)
            {
                tile.Draw(camera);
            }
        }
    }
}
