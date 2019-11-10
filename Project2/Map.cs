using OpenTK;

namespace Project2
{
    class Map
    {
        private int side;
        private int area;
        private Tile[] tiles;
        private TileType defaultTile;

        public float Width;
        public float Height;

        public Map(int a, TileType type)
        {
            side = a;
            area = a * a;
            tiles = new Tile[area];
            defaultTile = type;

            Width = type.Width * side;
            Height = type.Height * side;

            for (int i = 0; i < area; ++i)
            {
                tiles[i] = new Tile(type);
            }
        }

        public Tile GetTile(int x, int y)
        {
            int i = x + side * y;
            return tiles[i];
        }

        public void Draw(float x, float y)
        {
            for (int i = 0; i < area; ++i)
            {
                int xCoord = i % side;
                int yCoord = i / side;

                float xPos = xCoord * defaultTile.Width;
                float yPos = yCoord * defaultTile.Height;

                tiles[i].Draw(xPos + x, yPos + y);
            }
        }
    }
}