using System;
using System.Linq;
using CajaDeCambio.DataWarehouse;

namespace CajaDeCambio.Logica
{
    // Procesa la lógica principal del sistema de cambio
    // Incluye la entrega de cambio y la consulta del inventario
    class SistemaCambio
    {
        private readonly Inventario inventario; // Referencia al inventario

        // Constructor que inicializa la lógica con el inventario disponible
        public SistemaCambio()
        {
            inventario = new Inventario();
        }

        // Calcula y entrega el cambio al usuario.

        /// <param name="monto"> Monto solicitado para cambio. </param>
        public void DarCambio(decimal monto)
        {
            if (monto <= 0 || monto == 1 || monto != Math.Floor(monto))
            {
                Console.WriteLine("El monto ingresado no es válido para dar cambio.");
                return;
            }

            var denominaciones = inventario.ObtenerDenominaciones();
            var cambio = new System.Collections.Generic.List<(decimal Valor, int Cantidad)>();
            decimal montoRestante = monto;

            foreach (var denom in denominaciones.OrderByDescending(d => d.Valor))
            {
                if (montoRestante == 0) break;

                int cantidadNecesaria = Math.Min((int)(montoRestante / denom.Valor), denom.Cantidad);
                if (cantidadNecesaria > 0)
                {
                    cambio.Add((denom.Valor, cantidadNecesaria));
                    montoRestante -= cantidadNecesaria * denom.Valor;
                    denom.Cantidad -= cantidadNecesaria;
                }
            }

            if (montoRestante > 0)
            {
                Console.WriteLine("No hay suficientes billetes y/o monedas para dar cambio.");
            }
            else
            {
                Console.WriteLine($"Cambio entregado para ${monto}:");
                foreach (var item in cambio)
                {
                    string tipo = item.Valor >= 20 ? "Billete" : "Moneda";
                    Console.WriteLine($"{tipo}: ${item.Valor}, Cantidad: {item.Cantidad}");
                }
                inventario.ActualizarArchivo();
            }
        }

        // Muestra el inventario actual de la caja
        public void MostrarInventario() => inventario.MostrarInventario();
    }
}