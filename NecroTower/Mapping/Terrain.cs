using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace NecroTower.Mapping
{
    internal class Terrain // TODO: replace this useless class
    {
        public static Terrain Default;

        public static void Initialize(ContentManager Content)
        {
            Default = new Terrain
            {
                Texture = Content.Load<Texture2D>("Graphics/tiny_tile")
            };
        }

        public Texture2D Texture;
    }
}
