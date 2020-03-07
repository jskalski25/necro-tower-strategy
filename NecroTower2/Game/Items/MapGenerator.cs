using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2.Game.Items
{
    internal static class MapGenerator
    {
        public static Map Default()
        {
            var map = new Map(TerrainTypes.Grass, 11);
            map.TileAt(1, 1).Building = new Building(BuildingTypes.Tower);
            map.TileAt(9, 9).Building = new Building(BuildingTypes.Tower);
            return map;
        }
    }
}
