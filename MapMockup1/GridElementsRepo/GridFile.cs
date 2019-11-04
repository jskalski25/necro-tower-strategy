using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapMockup1.GridElementsRepo
{
    public class GridFile
    {
        public int xPos;
        public int yPos;

        public ObservableCollection<GridItem> Content;
    }
}
