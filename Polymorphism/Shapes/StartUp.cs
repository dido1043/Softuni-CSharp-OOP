using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape shape = null;
            string type = Console.ReadLine();

            if (type == "Rectangle")
            {
                shape = new Rectangle(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
            }

            if (type == "Circle")
            {
                shape = new Circle(double.Parse(Console.ReadLine()));
            }

            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.Draw());
        }
    }
}
