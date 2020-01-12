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
        private Point position;
        private Vector2 offset;

        public Terrain Terrain;

        public int X
        {
            get => position.X;

            set
            {
                position.X = value;
            }
        }

        public int Y
        {
            get => position.Y;

            set
            {
                position.Y = value;
            }
        }

        private void UpdateOffset()
        {
            double angle = Math.PI / 4;
            var temp = new Vector2
            {
                X = (float)((Math.Cos(angle) * position.X - Math.Sin(angle) * position.Y) * Math.Sin(angle)),
                Y = (float)((Math.Cos(angle) * position.Y + Math.Sin(angle) * position.X) * Math.Cos(angle))
            };
            offset.X = (temp.X - 0.5f) * Terrain.Texture.Width;
            offset.Y = temp.Y * Terrain.Texture.Height;
        }

        public void Draw(Vector2 camera)
        {
            UpdateOffset();
            Vector2 fullOffset = camera + offset;
            Sprites.Draw(Terrain.Texture, fullOffset, Color.White);
        }
    }
}
