using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower
{
    internal abstract class GameObject
    {
        public static SpriteBatch Sprites;
        public static ContentManager Content;
        public static GraphicsDeviceManager Graphics;
    }
}
