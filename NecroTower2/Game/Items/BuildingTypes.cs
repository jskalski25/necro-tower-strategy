using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Game.Items
{
    internal static class BuildingTypes
    {
        public static Building Tower;

        public static void Initialize(TextureManager textures)
        {
            Tower = new Building(textures.Load("Textures/test.png"), 10);
        }
    }
}
