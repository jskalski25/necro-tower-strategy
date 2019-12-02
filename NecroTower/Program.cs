namespace NecroTower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var window = new Window(800, 600, "Hello, World!"))
            {
                window.Run(60.0);
            }
        }
    }
}
