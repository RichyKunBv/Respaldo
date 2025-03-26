using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BaseDatos
{
    private ArrayList datos;

    public BaseDatos()
    {
        datos = new ArrayList();
    }

    public void AgregarDato(int numero)
    {
        datos.Add(numero);
    }

    protected ArrayList ObtenerDatos()
    {
        return new ArrayList(datos);
    }
}

public class Estadistica : BaseDatos
{
    public double CalcularMedia()
    {
        ArrayList datos = ObtenerDatos();
        if (datos.Count == 0) return 0;

        double suma = 0;
        foreach (int numero in datos)
        {
            suma += numero;
        }
        return suma / datos.Count;
    }

    public double CalcularMediana()
    {
        ArrayList datos = ObtenerDatos();
        if (datos.Count == 0) return 0;

        List<int> listaOrdenada = datos.Cast<int>().OrderBy(n => n).ToList();
        int mitad = listaOrdenada.Count / 2;

        if (listaOrdenada.Count % 2 == 0)
        {
            return (listaOrdenada[mitad - 1] + listaOrdenada[mitad]) / 2.0;
        }
        else
        {
            return listaOrdenada[mitad];
        }
    }

    public int CalcularModa()
    {
        ArrayList datos = ObtenerDatos();
        if (datos.Count == 0) return 0;

        var frecuencias = new Dictionary<int, int>();

        foreach (int numero in datos)
        {
            if (frecuencias.ContainsKey(numero))
                frecuencias[numero]++;
            else
                frecuencias[numero] = 1;
        }

        int moda = frecuencias.OrderByDescending(f => f.Value).First().Key;
        return moda;
    }
}

class Program
{
    static void Main()
    {
        Estadistica estadistica = new Estadistica();

        estadistica.AgregarDato(1);
        estadistica.AgregarDato(2);
        estadistica.AgregarDato(3);
        estadistica.AgregarDato(3);
        estadistica.AgregarDato(5);

        Console.WriteLine("Media: " + estadistica.CalcularMedia());
        Console.WriteLine("Mediana: " + estadistica.CalcularMediana());
        Console.WriteLine("Moda: " + estadistica.CalcularModa());
    }
}

