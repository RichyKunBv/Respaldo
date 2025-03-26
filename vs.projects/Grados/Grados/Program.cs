/*using System;

class Program
{
    static void Main()
    {
        int valor;
        string n;
        bool grados;

        int operacion;

    
        {
            Console.WriteLine("Seleccione la operación: (1) Celsius  (2) farenjai (3) kevin");
            n = Console.ReadLine();
            grados = int.TryParse(n, out operacion) && (operacion == 1 || operacion == 2 || operacion == 3);


            Console.WriteLine("El grados Ingresado es " + grados);

        }

        do
        {
            Console.WriteLine("Ingrese un valor entero (entre 1 y 30):");
            n = Console.ReadLine();
            grados = int.TryParse(n, out valor) && valor >= 1 && valor <= 30;
        }
        while (!grados);

            Console.WriteLine("El Valor Ingresado es " + valor);

        {
            Console.WriteLine("Seleccione la operación: (1) Celsius  (2) farenjai (3) kevin");
            n = Console.ReadLine();
            grados = int.TryParse(n, out operacion) && (operacion == 1 || operacion == 2 || operacion == 3);


            Console.WriteLine("El grados Ingresado es " + grados);

        }
    }
} */ //esto no existe :V

using System;

public class GradosBv
{
    public double Celsius { get; set; }
    public double Kelvin { get; set; }
    public double Fahrenheit { get; set; }

    public GradosBv(double celsius)
    {
        Celsius = celsius;
        Kelvin = CelsiusAKelvin(celsius);
        Fahrenheit = CelsiusAFahrenheit(celsius);
    }

    public GradosBv(double kelvin, bool isKelvin)
    {
        if (isKelvin)
        {
            Kelvin = kelvin;
            Celsius = KelvinACelsius(kelvin);
            Fahrenheit = KelvinAFahrenheit(kelvin);
        }
    }

    public GradosBv(double fahrenheit, bool esKelvin, bool isFahrenheit)
    {
        if (isFahrenheit)
        {
            Fahrenheit = fahrenheit;
            Celsius = FahrenheitACelsius(fahrenheit);
            Kelvin = FahrenheitAKelvin(fahrenheit);
        }
    }

    public double CelsiusAKelvin(double celsius)
    {
        return celsius + 273.15;
    }

    public double CelsiusAFahrenheit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public double KelvinACelsius(double kelvin)
    {
        return kelvin - 273.15;
    }

    public double KelvinAFahrenheit(double kelvin)
    {
        return (kelvin * 9 / 5) - 459.67;
    }

    public double FahrenheitACelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }

    public double FahrenheitAKelvin(double fahrenheit)
    {
        return (((fahrenheit + 459.67) * 5) / 9);
    }

    public void DisplayResultInScale(int scaleOption)
    {
        switch (scaleOption)
        {
            case 1:
                Console.WriteLine("Resultado: " + Celsius + " grados Celsius");
                break;
            case 2:
                Console.WriteLine("Resultado: " + Kelvin + " grados Kelvin");
                break;
            case 3:
                Console.WriteLine("Resultado: " + Fahrenheit + " grados Fahrenheit");
                break;
            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Seleccione el tipo de temperatura que va a ingresar:");
        Console.WriteLine("1. Celsius");
        Console.WriteLine("2. Kelvin");
        Console.WriteLine("3. Farenjai");

        int opcion = Convert.ToInt32(Console.ReadLine());
        GradosBv converter = null;

        switch (opcion)
        {
            case 1:
                Console.WriteLine("Ingrese la temperatura en grados Celsius:");
                double celsius = Convert.ToDouble(Console.ReadLine());
                converter = new GradosBv(celsius);
                break;

            case 2:
                Console.WriteLine("Ingrese la temperatura en grados Kelvin:");
                double kelvin = Convert.ToDouble(Console.ReadLine());
                converter = new GradosBv(kelvin, true);
                break;

            case 3:
                Console.WriteLine("Ingrese la temperatura en grados Farenjai:");
                double fahrenheit = Convert.ToDouble(Console.ReadLine());
                converter = new GradosBv(fahrenheit, false, true);
                break;

            default:
                Console.WriteLine("Mi loco ponele el numero del 1 al 3. Grazias <3");
                return;
        }

        Console.WriteLine("Seleccione la escala en la que desea ver el resultado:");
        Console.WriteLine("1. Celsius");
        Console.WriteLine("2. Kelvin");
        Console.WriteLine("3. Farenjai");

        int escalaFinal = Convert.ToInt32(Console.ReadLine());

        converter.DisplayResultInScale(escalaFinal);
    }
}