using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace NecroTower
{
    internal abstract class Screen
    {
        public static SpriteBatch Sprites;
        public static ContentManager Content;
        public static GraphicsDeviceManager Graphics;

        protected Screen()
        {
            Initialize();
            LoadContent();
        }

        public abstract void Initialize();

        public abstract void LoadContent();

        public abstract Screen Update();

        public abstract void Draw();
    }
}
