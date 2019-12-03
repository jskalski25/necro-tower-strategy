using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Input;

namespace NecroTower.GUI
{
    internal class Element
    {
        public event EventHandler Click;

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
            Rectangle renderTarget = CreateTargetRectangle(target);
            RenderElement(renderTarget);
        }

        protected virtual void RenderElement(Rectangle target)
        {
            Background?.Render(target);
        }

        public void MouseDown(Window sender, MouseEventArgs e)
        {
            Rectangle renderTarget = CreateTargetRectangle(sender.ClientRectangle);
            Point point = new Point(e.X, e.Y);
            if (renderTarget.Contains(point)) Click?.Invoke(this, EventArgs.Empty);
        }

        private Rectangle CreateTargetRectangle(Rectangle target)
        {
            Rectangle renderTarget = new Rectangle
            {
                Width = Width != 0 ? Width : target.Width,
                Height = Height != 0 ? Height : target.Height
            };

            switch(VerticalAlignment)
            {
                case Alignment.Bottom:
                    renderTarget.Y = Y + target.Y + target.Height - Height;
                    break;

                case Alignment.Center:
                    renderTarget.Y = Y + target.Y + (target.Height - Height) / 2;
                    break;

                default:
                    renderTarget.Y = Y + target.Y;
                    break;
            }

            switch (HorizontalAlignment)
            {
                case Alignment.Right:
                    renderTarget.X = X + target.X + target.Width - Width;
                    break;

                case Alignment.Center:
                    renderTarget.X = X + target.X + (target.Width - Width) / 2;
                    break;

                default:
                    renderTarget.X = X + target.X;
                    break;
            }

            return renderTarget;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Framework.Texture Background { get; set; }
        public Alignment VerticalAlignment { get; set; }
        public Alignment HorizontalAlignment { get; set; }
    }
}
