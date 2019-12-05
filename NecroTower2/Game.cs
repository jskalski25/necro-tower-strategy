using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower
{
    internal class Game : Framework.Game
    {
        private Framework.Texture texture;

        protected override void Initialize()
        {
            texture = null;
        }

        protected override void Load()
        {
            texture = Framework.TextureManager.LoadTexture("Images/Bitmap1.bmp");
        }

        protected override void Render(double frametime)
        {
            texture.Render(Window.ClientRectangle);
        }

        protected override void Update(double frametime)
        {
            // TODO
        }
    }
}
