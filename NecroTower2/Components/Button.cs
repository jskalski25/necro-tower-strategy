using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Components.Screens;
using NecroTower2.Graphics;
using OpenTK.Input;

namespace NecroTower2.Components
{
    internal class Button
    {
        public Texture2D Background;

        public Button(Screen screen)
        {
            screen.Render += Render;
            screen.Update += Update;
        }

        private void Update(object sender, EventArgs e)
        {
            var mouseState = Mouse.GetCursorState();
        }

        private void Render(object sender, EventArgs e)
        {
            Background?.Render(0.0f, 0.0f);
        }
    }
}
