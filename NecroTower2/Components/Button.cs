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
            screen.MouseDown += MouseDown;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            var rect = new Rectangle(0, 0, (int)Background.Width, (int)Background.Height);
            if (rect.Contains(e.Position)) Click?.Invoke(this, e);
        }

        private void Render(object sender, FrameEventArgs e)
        {
            Background?.Render(0.0f, 0.0f);
        }
    }
}
