using System;

namespace NecroTower.Controls
{
    internal abstract class Control
    {
        public abstract void Free();

        public abstract void Load();

        public virtual void Update(object sender, EventArgs e) { return; }

        public virtual void Render(object sender, EventArgs e) { return; }
    }
}
