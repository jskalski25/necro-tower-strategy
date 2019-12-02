using NecroTower.Controls;
using System.Drawing;

namespace NecroTower.States
{
    class MainMenuState : State
    {
        public MainMenuState()
        {
            var startButton = new Button
            {
                Text = "START",
                Background = "Images/image.bmp",
                X = 100,
                Y = 100,
                Font = new Font(FontFamily.GenericSansSerif, 16.0f)
            };

            startButton.Click += Start;

            controls.Add(startButton);
        }

        private void Start(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
