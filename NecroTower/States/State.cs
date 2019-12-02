using NecroTower.Controls;
using System;

namespace NecroTower.States
{
    class State
    {
        protected ControlList controls;

        public State()
        {
            controls = new ControlList();
        }

        public virtual void Free()
        {
            controls.Free();
        }

        public virtual void Load()
        {
            controls.Load();
        }

        public virtual void Leave() { return; }

        public virtual void Enter() { return; }

        public virtual void Update(object sender, EventArgs e)
        {
            controls.Update(sender, e);
        }

        public virtual void Render(object sender, EventArgs e)
        {
            controls.Render(sender, e);
        }

        public virtual void MouseDown(object sender, EventArgs e)
        {
            controls.MouseDown(sender, e);
        }
    }
}
