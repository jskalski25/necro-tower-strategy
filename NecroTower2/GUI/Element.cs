using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK.Input;
using OpenTK;

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

        public void Render(Rectangle bounds, FrameEventArgs e)
        {
            Rectangle target = CreateAlignedRectangle(bounds);
            OnRender(target, e);
        }

        protected virtual void OnRender(Rectangle target, FrameEventArgs e)
        {
            Background?.Render(target);
        }

        public void MouseDown(Rectangle bounds, MouseEventArgs e)
        {
            Rectangle target = CreateAlignedRectangle(bounds);
            Point pointer = new Point(e.X, e.Y);
            if (target.Contains(pointer)) OnMouseDown(target, e);
        }

        protected virtual void OnMouseDown(Rectangle target, MouseEventArgs e)
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        private Rectangle CreateAlignedRectangle(Rectangle bounds)
        {
            Rectangle renderTarget = new Rectangle
            {
                Width = Width != 0 ? Width : bounds.Width,
                Height = Height != 0 ? Height : bounds.Height
            };

            switch(VerticalAlignment)
            {
                case Alignment.Bottom:
                    renderTarget.Y = Y + bounds.Y + bounds.Height - Height;
                    break;

                case Alignment.Center:
                    renderTarget.Y = Y + bounds.Y + (bounds.Height - Height) / 2;
                    break;

                default:
                    renderTarget.Y = Y + bounds.Y;
                    break;
            }

            switch (HorizontalAlignment)
            {
                case Alignment.Right:
                    renderTarget.X = X + bounds.X + bounds.Width - Width;
                    break;

                case Alignment.Center:
                    renderTarget.X = X + bounds.X + (bounds.Width - Width) / 2;
                    break;

                default:
                    renderTarget.X = X + bounds.X;
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
