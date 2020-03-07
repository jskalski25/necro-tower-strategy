using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Game.Items
{
    internal static class Buildings
    {
        public static Building Tower;
        public static Building Cemetary;

        public static void Initialize(TextureManager textures)
        {
            Tower = new Building(textures.Load(""), 10);
            Cemetary = new Building(textures.Load(""), 10);
        }
    }
}
