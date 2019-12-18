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
    public enum GUIButtonState
    {
        Default, Hovered, Pressed
    }

    internal class Button
    {
        private MouseState mouseState;
        private Texture2D texture;
        private Vector2 position;

        private SpriteFont font;
        private string text;

        public float X { get => position.X; set => position.X = value; }

        public float Y { get => position.Y; set => position.Y = value; }

        public float Width { get => texture.Width; }

        public float Height { get => texture.Height; }

        public GUIButtonState State { get; private set; }

        public Rectangle Bounds
        {
            get
            {
                var point = position.ToPoint();
                var rectangle = new Rectangle
                {
                    X = point.X,
                    Y = point.Y,
                    Width = texture.Width,
                    Height = texture.Height
                };
                return rectangle;
            }
        }

        public void Initialize(Texture2D texture, Vector2 position, string text, SpriteFont font)
        {
            this.texture = texture;
            this.position = position;
            this.text = text;
            this.font = font;
        }

        public void Update()
        {
            mouseState = Mouse.GetState();
            if (Bounds.Contains(mouseState.Position))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    State = GUIButtonState.Pressed;
                }
                else
                {
                    State = GUIButtonState.Hovered;
                }
            }
            else
            {
                State = GUIButtonState.Default;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);

            var textMiddlePoint = font.MeasureString(text) / 2;
            var textPosition = Bounds.Center.ToVector2();
            spriteBatch.DrawString(font, text, textPosition, Color.Black, 0f, textMiddlePoint, 1f, SpriteEffects.None, 0f);
        }
    }
}
