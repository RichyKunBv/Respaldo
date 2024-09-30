using System;

namespace Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UseTriangle triangle = new UseTriangle();

            triangle.setValueSideA(3);
            triangle.setValueSideB(4);
            triangle.setValueSideC(5);

            if (triangle.isATriangle())
            {
                Console.WriteLine("Figura: " + triangle.getNameTriangle());
                Console.WriteLine("Area: " + triangle.getArea());
                Console.WriteLine("Perimetro: " + triangle.getPerimeter());

            }
            else
            {
                Console.WriteLine("Los valores ingresados no forman un triangulo");
            }

            Console.ReadKey();
        }
    }
}
