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
        private Faction faction;

        private int health;
        private int damage;

        public Unit(Texture texture, int health, int damage, Faction faction = null)
        {
            this.texture = texture;
            this.health = health;
            this.damage = damage;
        }

        public Unit(Unit unit, Faction faction) : this(unit.texture, unit.health, unit.damage, faction)
        {
        }

        public Unit(Unit unit) : this(unit, unit.faction)
        {
        }
    }
}
