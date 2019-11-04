namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(800, 600, "hello world!"))
            {
                game.Run(60.0);
            }
        }
    }
}
