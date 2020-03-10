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
        private Faction faction;
        private int health;

        public float Height { get => texture.Height; }
        public float Width { get => texture.Width; }

        public Building(Texture texture, int health, Faction faction = null)
        {
            this.texture = texture;
            this.health = health;
            this.faction = faction;
        }

        public Building(Building building, Faction faction) : this(building.texture, building.health, faction)
        {
        }

        public Building(Building building) : this(building, building.faction)
        {
        }

        internal void Render(float x, float y)
        {
            texture.Render(x, y);
        }
    }
}
