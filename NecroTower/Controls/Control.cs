using System;
using OpenTK.Input;

namespace NecroTower.Controls
{
    internal abstract class Control
    {
        public event EventHandler Click;

        public int X { get; set; }

        public int Y { get; set; }

        public abstract int Width { get; }

        public abstract int Height { get; }

        public abstract void Free();

        public abstract void Load();

        public virtual void Update(object sender, EventArgs e) { return; }

        public virtual void Render(object sender, EventArgs e) { return; }

        public virtual void MouseDown(object sender, EventArgs e)
        {
            var args = e as MouseButtonEventArgs;
            if (args.X > X && args.X < X + Width && args.Y > Y && args.Y < Y + Height) Click(this, e);
        }
    }
}
