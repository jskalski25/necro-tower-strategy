using NecroTower.Controls;
using System.Drawing;
using System;

namespace NecroTower.States
{
    class MainMenuState : State
    {
        public event EventHandler Exit;
        public event EventHandler Start;

        private readonly Control exitButton;
        private readonly Control startButton;

        public MainMenuState()
        {
            exitButton = new Button
            {
                Text = "EXIT",
                Background = "Images/image.bmp",
                Font = new Font(FontFamily.GenericSansSerif, 16.0f)
            };

            startButton = new Button
            {
                Text = "START",
                Background = "Images/image.bmp",
                Font = new Font(FontFamily.GenericSansSerif, 16.0f)
            };

            exitButton.Click += (sender, e) =>
            {
                Exit(this, e);
            };

            startButton.Click += (sender, e) =>
            {
                Start(this, e);
            };

            controls.Add(exitButton);
            controls.Add(startButton);
        }

        public override void Resize(object sender, EventArgs e)
        {
            base.Resize(sender, e);

            var window = sender as Window;
            exitButton.X = (window.Width - exitButton.Width) / 2;
            exitButton.Y = (window.Height - exitButton.Height) / 2 + exitButton.Height / 2 + 2;

            startButton.X = (window.Width - startButton.Width) / 2;
            startButton.Y = (window.Height - startButton.Height) / 2 - startButton.Height / 2 - 2;
        }
    }
}
