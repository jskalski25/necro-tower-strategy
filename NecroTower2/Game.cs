using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using System.Drawing;

namespace NecroTower
{
    internal class Game : Framework.Game
    {
        private Framework.Texture texture;

        protected override void Load(object sender, EventArgs e)
        {
            texture = Framework.TextureManager.LoadTexture("Images/Bitmap1.bmp");
        }

        protected override void Render(object sender, FrameEventArgs e)
        {
            var window = sender as GameWindow;
            var rectangle = new Rectangle
            {
                Width = texture.Width * 8,
                Height = texture.Height * 8,
                X = (window.Width - texture.Width * 8) / 2,
                Y = (window.Height - texture.Height * 8) / 2
            };
            texture.Render(rectangle);
        }

        protected override void Update(object sender, FrameEventArgs e)
        {
            var window = sender as GameWindow;
            var state = Mouse.GetCursorState();
            var point = new Point(state.X, state.Y);
            point = window.PointToClient(point);
            Console.WriteLine("x: " + point.X.ToString() + "\t| y: " + point.Y.ToString());
        }
    }
}
