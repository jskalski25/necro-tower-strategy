using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Game.Items
{
    internal static class UnitTypes
    {
        public static Unit Zombie;
        public static Unit Skeleton;

        public static void Initialize(TextureManager textures)
        {
            Zombie = new Unit(textures.Load("Textures/test.png"), 10, 10);
            Skeleton = new Unit(textures.Load("Textures/test.png"), 10, 10);
        }
    }
}
