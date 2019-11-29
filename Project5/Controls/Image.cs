using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5.Controls
{
    class Image : Control
    {
        public Image(string imagePath)
        {
            texture = Content.LoadTexture(imagePath);
        }
    }
}
