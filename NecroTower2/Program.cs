using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NecroTower2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var game = new NecroTower2())
            {
                game.Run();
            }
        }
    }
}
