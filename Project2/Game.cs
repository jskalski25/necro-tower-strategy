using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Project2
{
    class Game : GameWindow
    {
        private TileType grassTile;
        private BuildingType towerBuilding;
        private Map map;

        private Vector2 Camera;

        public Game() : base(800, 600, GraphicsMode.Default, "Hello, World!")
        {
            Load += LoadMedia;
            Unload += FreeMedia;

            UpdateFrame += Update;
            RenderFrame += Render;

            Load += InitGL;
        }

        private void InitGL(object sender, System.EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0.0, Width, Height, 0.0, -1.0, 1.0);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();

            GL.ClearColor(0.0f, 0.0f, 0.2f, 1.0f);

            GL.Enable(EnableCap.Texture2D);
        }

        private void Update(object sender, FrameEventArgs e)
        {
            // TODO
        }

        private void Render(object sender, FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            map.Draw(Camera.X , Camera.Y);

            Context.SwapBuffers();
        }

        private void FreeMedia(object sender, System.EventArgs e)
        {
            grassTile.FreeTexture();
            towerBuilding.FreeTexture();
        }

        private void LoadMedia(object sender, System.EventArgs e)
        {
            grassTile = new TileType("Textures/Grass.png");
            towerBuilding = new BuildingType("Textures/Tower.png");
            towerBuilding.SetOffset(0, 32);

            map = new Map(11, grassTile);
            map.GetTile(1, 1).SetBuilding(new Building(towerBuilding));

            Camera = new Vector2((Width - map.Width) / 2, (Height - map.Height) / 2);
        }
    }
}
