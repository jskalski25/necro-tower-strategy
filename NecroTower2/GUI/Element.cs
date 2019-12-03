using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NecroTower.GUI
{
    internal class Element
    {
        public Element()
        {
            X = 0;
            Y = 0;
            Width = 0;
            Height = 0;
            Background = null;
        }

        public void Render(Rectangle target)
        {
            Rectangle renderTarget = new Rectangle
            {
                X = X + target.X,
                Y = Y + target.Y,
                Width = Width != 0 ? Width : target.Width,
                Height = Height != 0 ? Height : target.Height
            };
            RenderElement(renderTarget);
        }

        protected virtual void RenderElement(Rectangle target)
        {
            Background?.Render(target);
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Framework.Texture Background { get; set; }
    }
}
