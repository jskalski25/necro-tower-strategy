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
        /*
        private MouseState mouseState;
        private Texture2D defaultTexture;
        private Texture2D hoverTexture;
        private Vector2 position;

        private SpriteFont font;
        private string text;

        public float X { get => position.X; set => position.X = value; }

        public float Y { get => position.Y; set => position.Y = value; }

        public float Width { get => defaultTexture.Width; }

        public float Height { get => defaultTexture.Height; }

        public bool Pressed { get; private set; }

        public bool Hovered { get; private set; }

        public bool Clicked { get; private set; }

        public Rectangle Bounds
        {
            get
            {
                var point = position.ToPoint();
                var rectangle = new Rectangle
                {
                    X = point.X,
                    Y = point.Y,
                    Width = defaultTexture.Width,
                    Height = defaultTexture.Height
                };
                return rectangle;
            }
        }

        public void Initialize(Vector2 position, string text, SpriteFont font, Texture2D defaultTexture, Texture2D hoverTexture = null)
        {
            this.defaultTexture = defaultTexture;
            this.hoverTexture = hoverTexture;
            this.position = position;
            this.text = text;
            this.font = font;
        }

        private bool wasPressed;

        public void Update()
        {
            wasPressed = Pressed;
            mouseState = Mouse.GetState();
            Hovered = Bounds.Contains(mouseState.Position);
            Pressed = Hovered && mouseState.LeftButton == ButtonState.Pressed;
            Clicked = Pressed && !wasPressed;
        }

        public void Draw()
        {
            if (Hovered && hoverTexture != null)
            {
                Sprites.Draw(hoverTexture, position, Color.White);
            }
            else
            {
                Sprites.Draw(defaultTexture, position, Color.White);
            }

            if (text != null)
            {
                var textMiddlePoint = font.MeasureString(text) / 2;
                var textPosition = Bounds.Center.ToVector2();
                Sprites.DrawString(font, text, textPosition, Color.Black, 0f, textMiddlePoint, 1f, SpriteEffects.None, 0f);
            }
        }*/
    }
}
