using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Platform.Windows;

namespace Project5.Controls
{
    class Button: Control
    {
        private static string path = "Images/button1.png";

        public event EventHandler Click;

        private string text = "";
        private Texture buttonTexture;

        public string Text
        {
            get => text;
            set
            {
                buttonTexture = Content.CreateText((int)texture.Width, (int)texture.Height, value);
                text = value;
            }
        }

        public Button()
        {
            texture = Content.LoadTexture(path);
        }

        public Button(string text) : this()
        {
            Text = text;
        }

        internal void Render(float x, float y)
        {
            texture.Render(x, y);
            buttonTexture.Render(x, y);
        }

        internal void OnClick(Window sender, EventArgs e)
        {
            Click(sender, e);
        }
    }
}
