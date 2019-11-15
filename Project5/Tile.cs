namespace Project5
{
    class Tile
    {
        public readonly int X;
        public readonly int Y;

        private Texture _texture;

        public Tile(int x, int y, Texture texture)
        {
            _texture = texture;

            X = x;
            Y = y;
        }

        public float Width { get => _texture.Width; }
        public float Height { get => _texture.Height; }

        public void Draw(float x, float y)
        {
            _texture.Render(x, y);
        }
    }
}
