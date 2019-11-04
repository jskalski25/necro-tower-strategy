using OpenTK;
using OpenTK.Graphics;

namespace Project1
{
    class Game : GameWindow
    {
        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
            Load += InitGL;
        }

        private void InitGL(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
        }
    }
}
