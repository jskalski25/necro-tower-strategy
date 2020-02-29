using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Graphics;
using OpenTK;
using OpenTK.Input;

namespace NecroTower2.Components.Screens
{
    internal class Screen
    {
        protected TextureManager textures;
        protected Game game;

        public event EventHandler<FrameEventArgs> Render;
        public event EventHandler<FrameEventArgs> Update;

        public event EventHandler<MouseEventArgs> MouseMove;
        public event EventHandler<MouseEventArgs> MouseDown;

        public Screen(TextureManager textures, Game game)
        {
            this.textures = textures;
            this.game = game;
        }

        public virtual void OnRender(object sender, FrameEventArgs e)
        {
            Render?.Invoke(this, e);
        }

        public virtual void OnUpdate(object sender, FrameEventArgs e)
        {
            Update?.Invoke(this, e);
        }

        internal void OnMouseMove(object sender, MouseMoveEventArgs e)
        {
            MouseMove?.Invoke(this, e);
        }

        internal void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MouseDown?.Invoke(this, e);
        }
    }
}
