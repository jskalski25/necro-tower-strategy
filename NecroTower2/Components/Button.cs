using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Components.Screens;
using NecroTower2.Graphics;
using OpenTK.Input;
using OpenTK;
using System.Drawing;

namespace NecroTower2.Components
{
    internal class Button
    {
        public Texture2D Background;

        public event EventHandler Click;

        public Button(Screen screen)
        {
            screen.Render += Render;
            screen.Update += Update;
        }

        private void Update(object sender, FrameEventArgs e)
        {
            var mouseState = Mouse.GetCursorState();
            var window = sender as NativeWindow;
            var mouse = new Point(mouseState.X, mouseState.Y);
            mouse = window.PointToClient(mouse);
            var rectangle = new Rectangle(0, 0, (int)Background.Width, (int)Background.Height);
            if (rectangle.Contains(mouse) && mouseState.LeftButton == ButtonState.Pressed) Click?.Invoke(this, EventArgs.Empty);
        }

        private void Render(object sender, FrameEventArgs e)
        {
            Background?.Render(0.0f, 0.0f);
        }
    }
}
