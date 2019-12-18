using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower
{
    internal static class Fonts
    {
        public static SpriteFont Default;

        public static void Initialize(ContentManager content)
        {
            Default = content.Load<SpriteFont>("Fonts/Arial");
        }
    }
}
