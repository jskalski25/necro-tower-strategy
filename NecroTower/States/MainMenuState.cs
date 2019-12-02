using NecroTower.Controls;
using System.Drawing;
using System;

namespace NecroTower.States
{
    class MainMenuState : State
    {
        public event EventHandler Exit;

        public MainMenuState()
        {
            var exitButton = new Button
            {
                Text = "EXIT",
                Background = "Images/image.bmp",
                X = 100,
                Y = 100,
                Font = new Font(FontFamily.GenericSansSerif, 16.0f)
            };

            exitButton.Click += OnStart;

            controls.Add(exitButton);
        }

        private void OnStart(object sender, EventArgs e)
        {
            Exit?.Invoke(this, e);
        }
    }
}
