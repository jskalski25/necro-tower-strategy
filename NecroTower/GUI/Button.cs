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
        private Vector2 position;

        public Vector2 Position { get => position; set => position = value; }

        public float X { get => position.X; set => position.X = value; }
        public float Y { get => position.Y; set => position.Y = value; }

        public float Width { get => Background.Width; }
        public float Height { get => Background.Height; }

        public Rectangle Bounds
        {
            get
            {
                return new Rectangle
                {
                    X = (int)Position.X,
                    Y = (int)Position.Y,
                    Width = (int)Width,
                    Height = (int)Height
                };
            }
        }

        public SpriteFont Font { get; set; }

        public string Text { get; set; }

        public Texture2D Background { get; set; }

        public Button()
        {
            Font = Fonts.Default;
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
                Sprites.Draw(Background, Position, Color.White);
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
