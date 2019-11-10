using System;

namespace Project2
{
    internal class Building
    {
        private BuildingType type;

        public Building(BuildingType type)
        {
            this.type = type;
        }

        public void Draw(float x, float y)
        {
            type.Render(x, y);
        }
    }
}