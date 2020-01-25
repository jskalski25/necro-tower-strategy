using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace NecroTower.Mapping
{
    internal class Tile : GameObject
    {
        private Point coords;
        private Vector2 position;

        public Terrain Terrain;

        public int X { get => coords.X; set => coords.X = value; }

        public int Y { get => coords.Y; set => coords.Y = value; }

        private void UpdateOffset()
        {
            double angle = Math.PI / 4;
            var temp = new Vector2
            {
                X = (float)((Math.Cos(angle) * coords.X - Math.Sin(angle) * coords.Y) * Math.Sin(angle)),
                Y = (float)((Math.Cos(angle) * coords.Y + Math.Sin(angle) * coords.X) * Math.Cos(angle))
            };
            position.X = (temp.X - 0.5f) * Terrain.Texture.Width;
            position.Y = temp.Y * Terrain.Texture.Height;
        }

        public void Draw(Vector2 camera)
        {
            UpdateOffset();
            Vector2 offset = camera + position;
            Sprites.Draw(Terrain.Texture, offset, Color.White);
        }
    }
}
