namespace Project5
{
    public class Terrain
    {
        public static Terrain Grass = new Terrain(Content.LoadTexture("img/grass.png"));

        protected Texture texture;

        public Texture Texture => texture;

        public Terrain(Texture texture)
        {
            this.texture = texture;
        }
    }
}
