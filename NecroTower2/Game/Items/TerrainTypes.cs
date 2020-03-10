﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Game.Items
{
    internal static class TerrainTypes
    {
        public static Terrain Grass;

        public static void Initialize(TextureManager textures)
        {
            Grass = new Terrain(textures.FromFile("Textures/tile.png"));
        }
    }
}
