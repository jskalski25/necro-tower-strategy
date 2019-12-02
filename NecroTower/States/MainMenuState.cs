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
                Font = new Font(FontFamily.GenericSansSerif, 16.0f)
            };
            controls.Add(startButton);
        }
    }
}
