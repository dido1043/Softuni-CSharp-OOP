using System;

namespace demo
{
    class StartUp
    {
        public static void Main(string[] args)
        {
            //ConsoleDrawer cd = new ConsoleDrawer();
            IDrawer drawer = new ConsoleDrawer();
            //drawer.WriteLine("Hello");
            //drawer.WriteAtPosition(15,13, "Hello");

            Circle circle = new Circle();
            circle.Draw();
            Console.WriteLine();
            Console.WriteLine();
            Rectangle rect = new Rectangle();
            rect.DrawABox(40,5,29,10);
        }
    }
}
