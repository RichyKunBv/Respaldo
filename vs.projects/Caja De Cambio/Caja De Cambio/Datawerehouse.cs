using System;

namespace CajaDeCambio.DataWarehouse
{
    // Representa una denominación de dinero, como billetes o monedas
    class Denominacion
    {
        public decimal Valor { get; } // Valor de la denominación (ej. 500, 20, 1)
        public int Cantidad { get; set; } // Cantidad disponible en inventario

        // Indica si la denominación es un billete (>= $20) o una moneda (< $20)
        public bool EsBillete => Valor >= 20;

        // Constructor que inicializa una denominación con su valor y cantidad

        /// <param name="valor"> Valor de la denominación. </param>
        /// <param name="cantidad"> Cantidad inicial en inventario. </param>
        public Denominacion(decimal valor, int cantidad)
        {
            Valor = valor;
            Cantidad = cantidad;
        }
    }
}