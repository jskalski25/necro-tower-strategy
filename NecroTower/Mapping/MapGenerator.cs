using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower.Mapping
{
    internal static class MapGenerator
    {
        public static Map Default()
        {
            Map map = new Map();
            map.Initialize(5, Terrain.Default);
            return map;
        }
    }
}
