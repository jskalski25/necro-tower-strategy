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
        Default, Hovered, Clicked
    }

    internal class GUIButton
    {
        private MouseState mouseState;
        private Texture2D texture;
        private Vector2 position;

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

        public void Initialize(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public void Update()
        {
            mouseState = Mouse.GetState();
            if (Bounds.Contains(mouseState.Position))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    State = GUIButtonState.Clicked;
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
            spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }
    }
}
