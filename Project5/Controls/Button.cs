using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Controls
{
    class Button: Control
    {
        public Button()
        {
            texture = Content.LoadTexture("Images/button1.png");
        }
    }
}
