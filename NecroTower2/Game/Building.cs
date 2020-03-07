using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Game
{
    internal class Building
    {
        private Texture texture;

        private int health;

        public Building(Texture texture, int health)
        {
            this.texture = texture;
            this.health = health;
        }

        public Building(Building building)
        {
            texture = building.texture;
            health = building.health;
        }
    }
}
