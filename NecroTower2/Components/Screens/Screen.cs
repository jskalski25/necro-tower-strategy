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
        protected NecroTower2 game;

        public event EventHandler<FrameEventArgs> RenderFrame;
        public event EventHandler<FrameEventArgs> UpdateFrame;
        public event EventHandler<MouseEventArgs> MouseMove;
        public event EventHandler<MouseEventArgs> MouseDown;

        public Screen(TextureManager textures, NecroTower2 game)
        {
            this.textures = textures;
            this.game = game;
        }

        public virtual void OnRenderFrame(object sender, FrameEventArgs e)
        {
            RenderFrame?.Invoke(this, e);
        }

        public virtual void OnUpdateFrame(object sender, FrameEventArgs e)
        {
            UpdateFrame?.Invoke(this, e);
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
