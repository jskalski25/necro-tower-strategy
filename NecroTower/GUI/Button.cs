using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NecroTower.GUI
{
    internal class Button : GameObject
    {
        private Rectangle rectangle;
        private Texture2D background;

        public int X { get => rectangle.X; set => rectangle.X = value; }
        public int Y { get => rectangle.Y; set => rectangle.Y = value; }

        public int Width { get => rectangle.Width; set => rectangle.Width = value; }
        public int Height { get => rectangle.Height; set => rectangle.Height = value; }

        public Rectangle Bounds { get => rectangle; }

        public SpriteFont Font { get; set; }

        public string Text { get; set; }

        public Texture2D Background
        {
            get => background;
            set
            {
                if (Bounds.Size.Equals(Point.Zero))
                {
                    Width = value.Width;
                    Height = value.Height;
                }
                background = value;
            }
        }

        public Button()
        {
            Font = Fonts.Default;
            rectangle = new Rectangle();
        }

        public bool IsDown { get; private set; }

        public void Update()
        {
            var mouse = Mouse.GetState();
            if (Bounds.Contains(mouse.Position) && mouse.LeftButton == ButtonState.Pressed)
            {
                IsDown = true;
            }
            else
            {
                IsDown = false;
            }
        }

        public void Draw()
        {
            if (Background != null)
            {
                Sprites.Draw(Background, Bounds, Color.White);
            }

            if (Text != null && Font != null)
            {
                var textMiddlePoint = Font.MeasureString(Text) / 2;
                var textPosition = Bounds.Center.ToVector2();
                Sprites.DrawString(Font, Text, textPosition, Color.Black, 0f, textMiddlePoint, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
