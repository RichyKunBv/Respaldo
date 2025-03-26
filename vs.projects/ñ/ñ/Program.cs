using System;

abstract class Figura
{
    public abstract double CalcularPerimetro();
    public abstract double CalcularArea();
    public abstract string DeterminarTipo();
}

class Cuadrado : Figura
{
    public double Lado { get; set; }

    public Cuadrado(double lado)
    {
        Lado = lado;
    }

    public override double CalcularPerimetro()
    {
        return 4 * Lado;
    }

    public override double CalcularArea()
    {
        return Lado * Lado;
    }

    public override string DeterminarTipo()
    {
        return "Cuadrado";
    }
}

class Rectangulo : Figura
{
    public double Lado1 { get; set; }
    public double Lado2 { get; set; }

    public Rectangulo(double lado1, double lado2)
    {
        Lado1 = lado1;
        Lado2 = lado2;
    }

    public override double CalcularPerimetro()
    {
        return 2 * (Lado1 + Lado2);
    }

    public override double CalcularArea()
    {
        return Lado1 * Lado2;
    }

    public override string DeterminarTipo()
    {
        return "Rectángulo";
    }
}

class Triangulo : Figura
{
    public double Lado1 { get; set; }
    public double Lado2 { get; set; }
    public double Lado3 { get; set; }

    public Triangulo(double lado1, double lado2, double lado3)
    {
        Lado1 = lado1;
        Lado2 = lado2;
        Lado3 = lado3;
    }

    public override double CalcularPerimetro()
    {
        return Lado1 + Lado2 + Lado3;
    }

    public override double CalcularArea()
    {
        double semiPerimetro = CalcularPerimetro() / 2;
        return Math.Sqrt(semiPerimetro * (semiPerimetro - Lado1) * (semiPerimetro - Lado2) * (semiPerimetro - Lado3));
    }

    public override string DeterminarTipo()
    {
        if (Lado1 == Lado2 && Lado2 == Lado3)
            return "Equilátero";
        else if (Lado1 == Lado2 || Lado2 == Lado3 || Lado1 == Lado3)
            return "Isósceles";
        else
            return "Escaleno";
    }
}

class Program
{
    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            double lado1 = LeerLado("Ingrese el primer lado (debe ser mayor a 0): ", true);
            double lado2 = LeerLado("Ingrese el segundo lado (debe ser mayor a 0): ", true);
            double lado3 = LeerLado("Ingrese el tercer lado (0 para cuadrado, mayor a 0 para triángulo): ", false);

            Figura figura;

   
            if (lado3 == 0)
            {
              
                if (lado1 == lado2)
                {
                    figura = new Cuadrado(lado1);
                }
                else
                {
        
                    figura = new Rectangulo(lado1, lado2);
                }
            }
            else
            {
        
                figura = new Triangulo(lado1, lado2, lado3);
            }

            MostrarResultado(figura);

            Console.WriteLine("\n¿Desea continuar con otra figura? (S para sí, cualquier otra tecla para finalizar)");
            continuar = Console.ReadLine().Trim().ToUpper() == "S";
        }
    }

    static double LeerLado(string mensaje, bool debeSerMayorCero)
    {
        double lado;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out lado))
            {
          
                if ((debeSerMayorCero && lado > 0) || (!debeSerMayorCero))
                {
                    return lado;
                }
                else
                {
                    Console.WriteLine("Por favor, ingrese un valor mayor que 0.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }
        }
    }

    static void MostrarResultado(Figura figura)
    {
        Console.WriteLine($"Perímetro: {figura.CalcularPerimetro()}");
        Console.WriteLine($"Área: {figura.CalcularArea()}");
        Console.WriteLine($"Tipo de figura: {figura.DeterminarTipo()}");
    }
}