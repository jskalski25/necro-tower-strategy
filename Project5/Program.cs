using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Window window = new Window())
            {
                window.Run(60.0);
            }
        }
    }
}
