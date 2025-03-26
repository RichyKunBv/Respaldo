using System;
using CajaDeCambio.Logica;

namespace CajaDeCambio.Interfaz
{
	// Controla la interacción con el usuario
	class InterfazUsuario
	{
		private readonly SistemaCambio sistema; // Instancia de la lógica

		// Constructor que inicializa la interfaz con el sistema de cambio
		public InterfazUsuario()
		{
			sistema = new SistemaCambio();
		}

		// Inicia el ciclo principal de interacción con el usuario
		public void Ejecutar()
		{
			while (true)
			{
				Console.WriteLine("\nOpciones:");
				Console.WriteLine("-1. Mostrar estado de la caja");
				Console.WriteLine("-2. Salir");
				Console.WriteLine(" 3. Solicitar cambio");

				Console.Write("Seleccione una opción: ");
				string input = Console.ReadLine();
				if (!int.TryParse(input, out int opcion))
				{
					Console.WriteLine("La opción ingresada es incorrecta.");
					continue;
				}

				switch (opcion)
				{
					case -1:
						sistema.MostrarInventario();
						break;
					case -2:
						Console.WriteLine("Saliendo del sistema...");
						return;
					case 3:
						Console.Write("Ingrese el monto para cambio: ");
						string montoInput = Console.ReadLine();
						if (decimal.TryParse(montoInput, out decimal monto))
						{
							sistema.DarCambio(monto);
						}
						else
						{
							Console.WriteLine("La opción ingresada es incorrecta.");
						}
						break;
					default:
						Console.WriteLine("La opción ingresada es incorrecta.");
						break;
				}
			}
		}
	}
}