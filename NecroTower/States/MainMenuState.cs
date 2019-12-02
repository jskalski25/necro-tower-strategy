using NecroTower.Controls;
using System.Drawing;
using System;

namespace NecroTower.States
{
    class MainMenuState : State
    {
        public event EventHandler Exit;

        private readonly Control exitButton;

        public MainMenuState()
        {
            exitButton = new Button
            {
                Text = "EXIT",
                Background = "Images/image.bmp",
                Font = new Font(FontFamily.GenericSansSerif, 16.0f)
            };

            exitButton.Click += (sender, e) =>
            {
                Exit(this, e);
            };

            controls.Add(exitButton);
        }

        public override void Resize(object sender, EventArgs e)
        {
            base.Resize(sender, e);

            var window = sender as Window;
            exitButton.X = (window.Width - exitButton.Width) / 2;
            exitButton.Y = (window.Height - exitButton.Height) / 2;

            Console.WriteLine((window.Height - exitButton.Height) / 2);
        }
    }
}
