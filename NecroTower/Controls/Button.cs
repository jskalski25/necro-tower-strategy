using NecroTower.Graphics;
using System;
using System.Drawing;

namespace NecroTower.Controls
{
    internal class Button : Control
    {
        private Texture backgroundTexture;
        private Texture textTexture;

        public Button()
        {
            backgroundTexture = null;
            textTexture = null;

            Background = null;
            Text = null;
            Font = SystemFonts.DefaultFont;
        }

        public string Background { private get; set; }

        public string Text { private get; set; }

        public Font Font { private get; set; }

        protected void LoadBackgroundTexture(string path)
        {
            backgroundTexture = new Texture();
            backgroundTexture.LoadTextureFromFile(path);
        }

        protected void LoadTextTexture(string text)
        {
            if (backgroundTexture != null)
            {
                FreeTextTexture();

                textTexture = new Texture();

                using (var bmp = new Bitmap(backgroundTexture.Width, backgroundTexture.Height))
                {
                    using (var gfx = System.Drawing.Graphics.FromImage(bmp))
                    {
                        StringFormat format = new StringFormat
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Center
                        };

                        gfx.DrawString(text, Font, Brushes.Black, new RectangleF(0.0f, 0.0f, bmp.Width, bmp.Height), format);
                    }
                    textTexture.LoadTextureFromImage(bmp);
                }
            }
        }

        private void FreeBackgroundTexture()
        {
            if (backgroundTexture != null)
            {
                backgroundTexture.Free();
                backgroundTexture = null;
            }
        }

        private void FreeTextTexture()
        {
            if (textTexture != null)
            {
                textTexture.Free();
                textTexture = null;
            }
        }

        public override void Free()
        {
            FreeBackgroundTexture();
            FreeTextTexture();
        }

        public override void Render(object sender, EventArgs e)
        {
            base.Render(sender, e);

            backgroundTexture.Render(0.0f, 0.0f);
            textTexture.Render(0.0f, 0.0f);
        }

        public override void Load()
        {
            if (Background != null) LoadBackgroundTexture(Background);
            if (Text != null) LoadTextTexture(Text);
        }
    }
}
