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
        private GUI.Button Button;

        protected override void Load(object sender, EventArgs e)
        {
            var window = sender as NativeWindow;
            var texture = Framework.TextureManager.LoadTexture("Images/Bitmap1.bmp");
            Button = new GUI.Button
            {
                Width = texture.Width * 4,
                Height = texture.Height * 4,
                X = (window.Width - texture.Width * 4) / 2,
                Y = (window.Height - texture.Height * 4) / 2,
                Texture = texture
            };
        }

        protected override void Render(object sender, FrameEventArgs e)
        {
            Button.Render(sender, e);
        }

        protected override void Update(object sender, FrameEventArgs e)
        {
            Button.Update(sender, e);

            var window = sender as NativeWindow;
            if (Button.Clicked) window.Close();
        }
    }
}
