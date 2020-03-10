using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NecroTower2.Components.Screens;
using NecroTower2.Graphics;
using OpenTK.Input;
using OpenTK;
using System.Drawing;

namespace NecroTower2.Components
{
    internal class Button
    {
        public Texture Background;
        public Texture TextTexture;

        public event EventHandler Click;

        public RectangleF BoundingBox;

        public float X { get => BoundingBox.X; set => BoundingBox.X = value; }
        public float Y { get => BoundingBox.Y; set => BoundingBox.Y = value; }
        public float Width { get => BoundingBox.Width; set => BoundingBox.Width = value; }
        public float Height { get => BoundingBox.Height; set => BoundingBox.Height = value; }

        public Button(Screen screen, Texture texture, int x, int y, int w, int h)
        {
            InitEvents(screen);

            X = x;
            Y = y;
            Width = w;
            Height = h;
            Background = texture;
        }

        public Button(Screen screen, Texture texture, int x, int y) : this(screen, texture, x, y, 0, 0)
        {
            Width = texture.Width;
            Height = texture.Height;
        }

        public void AddText(TextureManager textures, string text, float size)
        {
            using (var font = new Font(FontFamily.GenericSansSerif, size))
            {
                var texture = textures.FromText(400, 400, text, font, Brushes.Black);
                TextTexture = texture;
            }
        }

        private void InitEvents(Screen screen)
        {
            screen.RenderFrame += Render;
            screen.MouseDown += MouseDown;
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if (BoundingBox.Contains(e.Position)) Click?.Invoke(this, e);
        }

        private void Render(object sender, FrameEventArgs e)
        {
            Background?.Render(BoundingBox);
            TextTexture?.Render(BoundingBox);
        }
    }
}
