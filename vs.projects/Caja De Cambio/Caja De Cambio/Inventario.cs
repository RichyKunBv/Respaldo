using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CajaDeCambio.DataWarehouse
{
    // Gestiona el inventario de denominaciones (billetes y monedas)
    // También guarda y actualiza un archivo de texto con el estado del inventario
    class Inventario
    {
        private List<Denominacion> denominaciones; // Lista de denominaciones disponibles
        private readonly string RutaArchivo; // Ruta del archivo donde se guarda el inventario

        // Constructor que inicializa las denominaciones y crea el archivo de inventario
        public Inventario()
        {
            denominaciones = new List<Denominacion>
            {
                new Denominacion(1000, 0),
                new Denominacion(500, 5),
                new Denominacion(200, 7),
                new Denominacion(100, 9),
                new Denominacion(50, 11),
                new Denominacion(20, 13),
                new Denominacion(10, 17),
                new Denominacion(5, 23),
                new Denominacion(2, 29),
                new Denominacion(1, 31)
            };
            RutaArchivo = Path.Combine(Directory.GetCurrentDirectory(), "inventario.txt");
            ActualizarArchivo();
        }

        // Devuelve la lista actual de denominaciones
        public List<Denominacion> ObtenerDenominaciones() => denominaciones;

        // Guarda el estado actual del inventario en un archivo de texto
        public void ActualizarArchivo()
        {
            try
            {
                using (var writer = new StreamWriter(RutaArchivo))
                {
                    foreach (var denom in denominaciones)
                    {
                        string tipo = denom.EsBillete ? "Billete" : "Moneda";
                        writer.WriteLine($"{tipo}: ${denom.Valor}, Cantidad: {denom.Cantidad}");
                    }
                }
                Console.WriteLine($"Inventario actualizado en {RutaArchivo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir el archivo: {ex.Message}");
            }
        }

        // Muestra el estado actual del inventario en la consola
        public void MostrarInventario()
        {
            Console.WriteLine("Estado actual de la caja:");
            foreach (var denom in denominaciones)
            {
                string tipo = denom.EsBillete ? "Billete" : "Moneda";
                Console.WriteLine($"{tipo}: ${denom.Valor}, Cantidad: {denom.Cantidad}");
            }
            ActualizarArchivo();
        }
    }
}