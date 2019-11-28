using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.ES11;

namespace Project5.GridElementsRepo.BuildingTypes
{
    internal class Castle: Building
    {
        public Castle()
        {
            texture = Content.LoadTexture("img/Castle.png");
        }
    }
}
