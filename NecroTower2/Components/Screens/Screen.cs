using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;
using OpenTK;

namespace NecroTower2.Components.Screens
{
    internal class Screen
    {
        private TextureManager textures;

        public event EventHandler<FrameEventArgs> Render;
        public event EventHandler<FrameEventArgs> Update;

        public Screen(TextureManager textures)
        {
            this.textures = textures;
        }

        public virtual void OnRender(object sender, FrameEventArgs e)
        {
            Render?.Invoke(sender, e);
        }

        public virtual void OnUpdate(object sender, FrameEventArgs e)
        {
            Update?.Invoke(sender, e);
        }
    }
}
