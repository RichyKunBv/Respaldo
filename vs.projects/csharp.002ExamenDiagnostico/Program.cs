using System;

namespace ExamenDiagnostico
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            
            // EJERCICIO 1
            Console.WriteLine("--- Ejercicio 1 ---");

            string nombre = "Ricardo";
            int edad = 20;
            double estatura = 1.80;
            bool esEstudihambre = true;

            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Edad: {edad} años");
            Console.WriteLine($"Estatura: {estatura}m");
            Console.WriteLine($"¿Es estudiante?: {(esEstudihambre ? "Sí" : "No")}");
            Console.WriteLine();




            // EJERCICIO 2
            Console.WriteLine("--- Ejercicio 2 ---");

            Console.Write("Ingresa un número entero: ");

            if (int.TryParse(Console.ReadLine(), out int numeroUsuario))
            {
                if (numeroUsuario > 0) Console.WriteLine("El número es POSITIVO.");
                else if (numeroUsuario < 0) Console.WriteLine("El número es NEGATIVO.");
                else Console.WriteLine("El número es CERO.");
            }
            else
            {
                Console.WriteLine("Entrada no válida.");
            }
            Console.WriteLine();




            // EJERCICIO 3
            Console.WriteLine("--- Ejercicio 3 ---");

            Console.WriteLine("Ciclo FOR (1 al 10):");
            for (int i = 1; i <= 10; i++)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine("\n\nCiclo WHILE (Descendente):");
            int contador = 10;
            while (contador >= 1)
            {
                Console.Write($"{contador} ");
                contador--;
            }
            Console.WriteLine("\n");







            // EJERCICIO 4
            Console.WriteLine("--- Ejercicio 4 ---");

            Console.Write("Ingresa el primer número para sumar: ");
            int num1 = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Ingresa el segundo número para sumar: ");
            int num2 = int.Parse(Console.ReadLine() ?? "0");

            int resultado = SumarEnteros(num1, num2);
            Console.WriteLine($"El resultado de la suma es: {resultado}");
            Console.WriteLine();






            // EJERCICIO 5

            Console.WriteLine("--- Ejercicio 5 ---");

            int[] numeros = new int[5];
            int sumaTotal = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                Console.Write($"Ingresa el número {i + 1} para el arreglo: ");
                if (int.TryParse(Console.ReadLine(), out int valor))
                {
                    numeros[i] = valor;
                }
                else
                {
                    Console.WriteLine("Dato inválido, se guardará como 0.");
                    numeros[i] = 0;
                }
            }

            foreach (int num in numeros)
            {
                sumaTotal += num;
            }

            double promedio = (double)sumaTotal / numeros.Length;

            Console.WriteLine("\nResultados del Arreglo:");
            Console.WriteLine($"La suma total es: {sumaTotal}");
            Console.WriteLine($"El promedio es: {promedio:F2}");


            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();

        } 

        static int SumarEnteros(int a, int b)
        {
            return a + b;
        }

    } 
}