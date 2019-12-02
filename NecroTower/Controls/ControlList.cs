using System;
using System.Collections.Generic;

namespace NecroTower.Controls
{
    internal class ControlList
    {
        private readonly List<Control> controls;

        public ControlList()
        {
            controls = new List<Control>();
        }

        public void Add(Control control)
        {
            controls.Add(control);
        }

        public void Free()
        {
            foreach (var control in controls)
            {
                control.Free();
            }
        }

        public void Load()
        {
            foreach(var control in controls)
            {
                control.Load();
            }
        }

        public void Update(object sender, EventArgs e)
        {
            foreach(var control in controls)
            {
                control.Update(sender, e);
            }
        }

        public void Render(object sender, EventArgs e)
        {
            foreach(var control in controls)
            {
                control.Render(sender, e);
            }
        }

        public void MouseDown(object sender, EventArgs e)
        {
            foreach(var control in controls)
            {
                control.MouseDown(sender, e);
            }
        }
    }
}
