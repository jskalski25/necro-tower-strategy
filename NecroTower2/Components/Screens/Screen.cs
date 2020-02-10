using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;

namespace NecroTower2.Components.Screens
{
    internal class Screen
    {
        private TextureManager textures;

        public event EventHandler Render;
        public event EventHandler Update;

        public Screen(TextureManager textures)
        {
            this.textures = textures;
        }

        public virtual void OnRender()
        {
            Render?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnUpdate()
        {
            Update?.Invoke(this, EventArgs.Empty);
        }
    }
}
