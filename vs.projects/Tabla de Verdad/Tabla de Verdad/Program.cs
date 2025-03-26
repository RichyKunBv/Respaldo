using System;

class Program
{
    static void Main()
    {
        int valor;
        string n;
        bool esNumero;

        do
        {
            Console.WriteLine("Ingrese un valor entero (entre 1 y 30):");
            n = Console.ReadLine();
            esNumero = int.TryParse(n, out valor) && valor >= 1 && valor <= 30;
        }
        while (!esNumero);

        Console.WriteLine("El Valor Ingresado es " + valor);

        int operacion;
        do
        {
            Console.WriteLine("Seleccione la operación: (1) AND  (2) OR");
            n = Console.ReadLine();
            esNumero = int.TryParse(n, out operacion) && (operacion == 1 || operacion == 2);
        }
        while (!esNumero);

        int combinaciones = 1 << valor; 
        Console.WriteLine("\nTabla de Verdad para " + valor + " variables:");

        for (int i = 0; i < valor; i++)
        {
            Console.Write("Var" + (i + 1) + "\t");
        }
        Console.WriteLine("Resultado"); 

        for (int i = combinaciones - 1; i >= 0; i--)
        {
            bool resultado = (operacion == 1) ? true : false; 

            for (int j = valor - 1; j >= 0; j--)
            {
                bool variable = (i & (1 << j)) != 0; 
                Console.Write(variable ? "T\t" : "F\t");

                if (operacion == 1) 
                {
                    if (!variable)
                    {
                        resultado = false; 
                    }
                }
                else
                {
                    if (variable)
                    {
                        resultado = true; 
                    }
                }
            }

            Console.WriteLine(resultado ? "True" : "False");
        }
    }
}
