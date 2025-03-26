using CajaDeCambio.Interfaz;

namespace CajaDeCambio
{
    class Program
    {
        static void Main(string[] args)
        {
            var interfaz = new InterfazUsuario();
            interfaz.Ejecutar();
        }
    }
}