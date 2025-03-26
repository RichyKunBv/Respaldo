using System;

namespace CalculadoraConBases
{
    // Clase base
    public class Calculadora
    {
        public int Base { get; set; }

        public Calculadora(int baseNumerica)
        {
            if (baseNumerica < 2 || baseNumerica > 20)
            {
                throw new ArgumentException("La base debe estar entre 2 y 20.");
            }
            Base = baseNumerica;
        }

        public virtual string ConvertirResultado(double resultado)
        {
            return $"El resultado es: {ConvertirACadenaBase(resultado)} en base {Base}.";
        }

        // Convertir un número decimal (base 10) a la base indicada
        private string ConvertirACadenaBase(double numero)
        {
            if (numero == 0)
                return "0";

            int valor = (int)numero;
            string resultado = "";

            while (valor > 0)
            {
                int digito = valor % Base;
                resultado = DigitoACharacter(digito) + resultado;
                valor /= Base;
            }

            return resultado;
        }

        // Convertir una entrada (como string) de la base indicada a base 10
        public virtual int ConvertirEntrada(string entrada)
        {
            entrada = entrada.ToUpper(); // Convertir todas las letras a mayúsculas
            int valorFinal = 0;

            foreach (char c in entrada)
            {
                int valor;
                if (char.IsDigit(c))
                {
                    valor = c - '0'; // Convertimos dígitos (0-9)
                }
                else if (c >= 'A' && c <= 'J') // Aseguramos que las letras A-J sean válidas
                {
                    valor = ConvertirLetraAValor(c); // Convertimos letras (A-J) en valores
                }
                else
                {
                    throw new FormatException($"El carácter '{c}' no es válido para la base {Base}.");
                }

                if (valor >= Base)
                {
                    throw new FormatException($"El carácter '{c}' no es válido en la base {Base}.");
                }

                // Realizamos la conversión manual del número
                valorFinal = valorFinal * Base + valor;
            }

            return valorFinal;
        }

        // Método para convertir letras a su valor correspondiente
        private int ConvertirLetraAValor(char letra)
        {
            // Los valores de las letras A-J, de acuerdo con su posición
            if (letra == 'A') return 10;
            if (letra == 'B') return 11;
            if (letra == 'C') return 12;
            if (letra == 'D') return 13;
            if (letra == 'E') return 14;
            if (letra == 'F') return 15;
            if (letra == 'G') return 16;
            if (letra == 'H') return 17;
            if (letra == 'I') return 18;
            if (letra == 'J') return 19;

            // Si no es ninguna de las anteriores, es un error
            throw new FormatException($"El carácter '{letra}' no es válido en la base {Base}.");
        }

        // Convertir el valor del dígito a su carácter correspondiente
        private string DigitoACharacter(int digito)
        {
            if (digito >= 0 && digito <= 9)
            {
                return digito.ToString();
            }
            if (digito == 10) return "A";
            if (digito == 11) return "B";
            if (digito == 12) return "C";
            if (digito == 13) return "D";
            if (digito == 14) return "E";
            if (digito == 15) return "F";
            if (digito == 16) return "G";
            if (digito == 17) return "H";
            if (digito == 18) return "I";
            if (digito == 19) return "J";

            throw new ArgumentOutOfRangeException($"El dígito {digito} no está permitido en la base {Base}.");
        }
    }

    // Clase derivada para operaciones
    public class CalculadoraConOperaciones : Calculadora
    {
        public CalculadoraConOperaciones(int baseNumerica) : base(baseNumerica) { }

        public double Sumar(double a, double b) => a + b;
        public double Restar(double a, double b) => a - b;
        public double Multiplicar(double a, double b) => a * b;
        public double Dividir(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("No se puede dividir entre cero.");
            }
            return a / b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                try
                {
                    Console.WriteLine("Bienvenido a la Calculadora con Bases.");
                    Console.Write("Ingrese la base numérica (entre 2 y 20): ");
                    int baseNumerica = int.Parse(Console.ReadLine());

                    CalculadoraConOperaciones calculadora = new CalculadoraConOperaciones(baseNumerica);

                    Console.WriteLine("\nSeleccione la operación que desea realizar:");
                    Console.WriteLine("1. Suma");
                    Console.WriteLine("2. Resta");
                    Console.WriteLine("3. Multiplicación");
                    Console.WriteLine("4. División");
                    Console.Write("Ingrese el número de la operación: ");
                    int opcion = int.Parse(Console.ReadLine());

                    if (opcion < 1 || opcion > 4)
                    {
                        throw new ArgumentException("Seleccione una operación válida entre 1 y 4.");
                    }

                    Console.Write("\nIngrese el primer número en base {0}: ", baseNumerica);
                    string entrada1 = Console.ReadLine();
                    double num1 = calculadora.ConvertirEntrada(entrada1);

                    Console.Write("Ingrese el segundo número en base {0}: ", baseNumerica);
                    string entrada2 = Console.ReadLine();
                    double num2 = calculadora.ConvertirEntrada(entrada2);

                    double resultado = 0;

                    switch (opcion)
                    {
                        case 1:
                            resultado = calculadora.Sumar(num1, num2);
                            break;
                        case 2:
                            resultado = calculadora.Restar(num1, num2);
                            break;
                        case 3:
                            resultado = calculadora.Multiplicar(num1, num2);
                            break;
                        case 4:
                            resultado = calculadora.Dividir(num1, num2);
                            break;
                    }

                    Console.WriteLine(calculadora.ConvertirResultado(resultado));

                    Console.WriteLine("\n¿Desea realizar otra operación? (s/n): ");
                    string respuesta = Console.ReadLine().ToLower();
                    if (respuesta != "s")
                    {
                        continuar = false;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ha ocurrido un error inesperado: {ex.Message}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Gracias por usar la Calculadora con Bases. ¡Adiós!");
        }
    }
}