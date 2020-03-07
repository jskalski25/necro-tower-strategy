using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Game
{
    internal class Unit
    {
        private Texture texture;

        private int health;
        private int damage;

        public Unit(Texture texture, int health, int damage)
        {
            this.texture = texture;
            this.health = health;
            this.damage = damage;
        }

        public Unit(Unit unit)
        {
            texture = unit.texture;
            health = unit.health;
            damage = unit.damage;
        }
    }
}
