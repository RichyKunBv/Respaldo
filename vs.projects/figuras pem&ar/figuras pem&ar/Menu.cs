using System;



class Menu
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("Seleccione la figura: \n1. Cuadrado/Rectángulo \n2. Triángulo");
            int opcion;

            while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2))
            {
                Console.WriteLine("Por favor, ingrese una opción válida (1 o 2): ");
            }

            Figura figura = null;
            double lado1, lado2, lado3;

            switch (opcion)
            {
                case 1:
                    lado1 = LeerLado("Ingrese el primer lado: ");
                    lado2 = LeerLado("Ingrese el segundo lado: ");
                    figura = new CuadradoRectangulo(lado1, lado2);
                    break;

                case 2:
                    lado1 = LeerLado("Ingrese el primer lado del triángulo: ");
                    lado2 = LeerLado("Ingrese el segundo lado del triángulo: ");
                    lado3 = LeerLado("Ingrese el tercer lado del triángulo: ");
                    figura = new Triangulo(lado1, lado2, lado3);
                    break;
            }

            Console.WriteLine($"Perímetro: {figura.CalcularPerimetro()}");
            Console.WriteLine($"Área: {figura.CalcularArea()}");
            Console.WriteLine($"Tipo de figura: {figura.DeterminarTipo()}");

            Console.WriteLine("\n¿Desea continuar con otra figura? (S para sí, cualquier otra tecla para finalizar)");
            continuar = Console.ReadLine().Trim().ToUpper() == "S";
        }
    }

    static double LeerLado(string mensaje)
    {
        double lado;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out lado) && lado > 0)
            {
                return lado;
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido (decimal o entero positivo).");
            }
        }
    }
}