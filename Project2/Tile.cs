using System;

namespace Project2
{
    class Tile
    {
        private TileType type;
        private Building building;

        public Tile(TileType type)
        {
            this.type = type;
            building = null;
        }

        public void Draw(float x, float y)
        {
            type.Render(x, y);
            if (building != null)
            {
                building.Draw(x, y);
            }
        }

        public void SetBuilding(Building building)
        {
            this.building = building;
        }
    }
}