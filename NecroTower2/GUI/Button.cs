using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using OpenTK.Input;

namespace NecroTower.GUI
{
    internal class Button
    {
        private Framework.Graphics.Texture texture;

        public Framework.Graphics.Texture Texture {
            get => texture; 
            set
            {
                texture = value;
                if (Width == 0 && Height == 0 && texture != null)
                {
                    Width = texture.Width;
                    Height = texture.Height;
                }
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }

        public bool Clicked { get; private set; }

        public Button()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
            Texture = null;
        }

        public void Update(object sender, FrameEventArgs e)
        {
            var window = sender as NativeWindow;
            var state = Mouse.GetCursorState();
            var point = new Point(state.X, state.Y);
            point = window.PointToClient(point);
            Clicked = state.LeftButton == ButtonState.Pressed && Rectangle.Contains(point);
        }

        public void Render(object sender, FrameEventArgs e)
        {
            Texture?.Render(Rectangle);
        }
    }
}
