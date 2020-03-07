using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Game.Items
{
    internal static class MapGen
    {
        public static Map Default()
        {
            var map = new Map(Terrains.Grass, 11);
            map.TileAt(1, 1).Building = new Building(Buildings.Tower);
            map.TileAt(9, 9).Building = new Building(Buildings.Tower);
            return map;
        }
    }
}
