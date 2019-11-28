using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project5.ConfigManager;

namespace Project5
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Config config = new Config();
            config.Initialize();

            using (Window window = new Window(config.UserSettings.WindowWidth, config.UserSettings.WindowHeight, "Hello, World!"))
            {
                window.Run(60.0);
            }
        }
    }
}
