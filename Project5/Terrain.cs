namespace Project5
{
    internal class Terrain
    {
        public static Terrain Grass = new Terrain(Content.LoadTexture("Images/grass.png"));

        protected Texture texture;

        public Texture Texture => texture;

        public Terrain(Texture texture)
        {
            this.texture = texture;
        }
    }
}
