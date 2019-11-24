﻿namespace Project5
{
    class Terrain
    {
        public static Terrain Grass = new Terrain(Content.LoadTexture("grass.png"));

        protected Texture texture;

        public Texture Texture => texture;

        public Terrain(Texture texture)
        {
            this.texture = texture;
        }
    }
}