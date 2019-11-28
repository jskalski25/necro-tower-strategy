﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.ES11;

namespace Project5.GridElementsRepo.BuildingTypes
{
    public class Castel: Building
    {
        public Castel()
        {
            texture = Content.LoadTexture("img/Castel.png");
        }
    }
}
